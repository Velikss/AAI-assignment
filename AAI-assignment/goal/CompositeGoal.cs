using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment
{
    public abstract class CompositeGoal : Goal
    {
        public Stack<Goal> SubGoals;

        public void Activate()
        {
            throw new NotImplementedException();
        }       

        public bool HandleMessage()
        {
            throw new NotImplementedException();
        }

        public override int Process()
        {
            int status = SubGoals.Pop().Process();

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
            while(SubGoals.Count != 0 && (SubGoals.Peek().IsComplete() || SubGoals.Peek().HasFailed()))
                SubGoals.Pop().Terminate();

            // if any subgoals remain, start processing
            if(SubGoals.Count != 0)
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
