using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAI_assignment.behaviour;

namespace AAI_assignment
{
    class SeekAndDestroy_Goal : CompositeGoal
    {
        public Stack<Goal> SubGoals;

        public Agent agent;

        public SeekAndDestroy_Goal(Agent a)
        {
            this.agent = a;
            this.SubGoals = new Stack<Goal>();
        }

        public void Activate()
        {
            // Set most desirable target
            agent.Target = agent.FindMostDesirableTarget();

            // engage in seeking behaviour
            agent.SteeringBehaviour = new SeekBehaviour(agent, agent.Target.Pos);

            // set status to active (2)
            status = 2;

            agent.VColor = Color.Yellow;
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
                agent.VColor = Color.Red;
                ProcessSubGoals();

                // if no subgoals left, start seeking new target
                if (ProcessSubGoals() == 1)
                    Activate();
            }

            // check if target is within damage distance
            if (Vector2D.DistanceSquared(agent.Pos, agent.Target.Pos) < 100)
            {
                status = 1;
                DestroyGoal g = new DestroyGoal(this.agent);
                AddSubgoal(g);
            }

            return status;
        }

        public void Terminate()
        {
            throw new NotImplementedException();
        }

        public void AddSubgoal(Goal g)
        {
            SubGoals.Push(g);
        }

        public void RemoveAllSubgoals()
        {
            foreach (Goal g in SubGoals)
                g.Terminate();

            SubGoals.Clear();
        }

        public int ProcessSubGoals()
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
    }
}
