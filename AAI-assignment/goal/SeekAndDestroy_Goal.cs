using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AAI_assignment
{
    class SeekAndDestroy_Goal : CompositeGoal
    {
        public Agent Agent;

        public SeekAndDestroy_Goal(Agent a)
        {
            this.Agent = a;
            this.SubGoals = new Stack<Goal>();
        }

        public override void Activate()
        {
            // set debug to yellow (seeking)
            Agent.DebugColor = Color.Yellow;

            // Set most desirable target
            Agent.Target = Agent.FindMostDesirableTarget();

            if (Agent.Target != null)
            {
                // refresh behaviors
                Agent.RefreshBehaviours(true, false);

                // set Status to active (2)
                Status = 2;

            }
            else
            {
                // no target found so we either won or we can start wandering to come closer to other targets
                if (WorldParameters.AlliveAgents == 1)
                    Agent.DefaultColor = Color.Gold;
                else
                {
                    AddSubGoal(new WanderGoal(Agent));
                    Status = 1;
                }

            }
        }

        public bool HandleMessage()
        {
            throw new NotImplementedException();
        }

        public override int Process()
        {
            // if inactive, activate goal
            if (Status == 3)
                Activate();

            // if completed, process sub goals
            if (Status == 1)
            {
                ProcessSubGoals();

                // if no subgoals left, start seeking new target
                if (ProcessSubGoals() == 1)
                    Status = 3;

            }

            // if active, check if goal is reached
            if (Status == 2)
            {
                // check if current target is still most desirable target
                if (Agent.Target != Agent.FindMostDesirableTarget())
                {
                    Activate();
                }

                // check if target is still allive
                if (Agent.Target.Dead)
                    Status = 1;
                else
                {
                    // check if target is within damage distance
                    if (Vector2D.DistanceSquared(Agent.Pos, Agent.Target.Pos) < 1000)
                    {
                        Status = 1;
                        DestroyGoal g = new DestroyGoal(this.Agent);
                        AddSubGoal(g);
                    }
                }
            }
            return Status;
        }

        public override void AddSubGoal(Goal g)
        {
            SubGoals.Push(g);
        }

        public override void RemoveAllSubGoals()
        {
            foreach (Goal g in SubGoals)
                g.Terminate();

            SubGoals.Clear();
        }

        public override int ProcessSubGoals()
        {
            // remove all completed and failed goals from the front
            while (SubGoals.Count != 0 && (SubGoals.Peek().IsComplete() || SubGoals.Peek().HasFailed()))
                SubGoals.Pop().Terminate();

            // if any subgoals remain, start processing
            if (SubGoals.Count != 0)
            {
                // grab the Status of the frontmost goal
                int StatusOfSubGoals = SubGoals.Peek().Process();

                // we have to test for the special case where the frontmost subgoal reports completed and the subgoal list contains additional goals
                if (StatusOfSubGoals == 1 && SubGoals.Count() > 1)
                    return 2;

                return StatusOfSubGoals;
            }
            // no more subgoals to proces - return 1 / completed
            else
            {
                return 1;
            }
        }

        public override void Terminate()
        {
            RemoveAllSubGoals();
        }


        public override string ToString()
        {
            return "Seek";
        }
    }
}
