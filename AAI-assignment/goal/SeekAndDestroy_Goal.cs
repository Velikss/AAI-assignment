using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AAI_assignment
{
    class SeekAndDestroy_Goal : CompositeGoal
    {
        public Agent agent;

        public SeekAndDestroy_Goal(Agent a)
        {
            this.agent = a;
            this.SubGoals = new Stack<Goal>();
        }

        public override void Activate()
        {
            // set debug to yellow (seeking)
            agent.DebugColor = Color.Yellow;

            // Set most desirable target
            agent.Target = agent.FindMostDesirableTarget();

            if (agent.Target != null)
            {
                // refresh behaviors
                agent.RefreshBehaviours();

                // set status to active (2)
                status = 2;

            }
            else
            {
                agent.DefaultColor = Color.Gold;
            }
        }

        public bool HandleMessage()
        {
            throw new NotImplementedException();
        }

        public override int Process()
        {
            // if inactive, activate goal
            if (status == 3)
                Activate();

            // if completed, process sub goals
            if (status == 1)
            {
                ProcessSubGoals();

                // if no subgoals left, start seeking new target
                if (ProcessSubGoals() == 1)
                    status = 3;

            }

            // if active, check if goal is reached
            if (status == 2)
            {
                // check if current target is still most desirable target
                if (agent.Target != agent.FindMostDesirableTarget())
                {
                    Activate();
                }

                // check if target is within damage distance
                if (Vector2D.DistanceSquared(agent.Pos, agent.Target.Pos) < 1000)
                {
                    status = 1;
                    DestroyGoal g = new DestroyGoal(this.agent);
                    AddSubgoal(g);
                }
            // check if target is still allive
            if (agent.Target.Dead)
                status = 1;

            }
            return status;
        }

        public override void AddSubgoal(Goal g)
        {
            SubGoals.Push(g);
        }

        public override void RemoveAllSubgoals()
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
                // grab the status of the frontmost goal
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
            RemoveAllSubgoals();
        }


        public override string ToString()
        {
            return "Seek";
        }
    }
}
