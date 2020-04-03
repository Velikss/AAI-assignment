using System;
using System.Drawing;

namespace AAI_assignment
{
    class WanderGoal : AtomicGoal
    {
        public Agent Agent;

        public WanderGoal(Agent a)
        {
            this.Agent = a;
        }

        public override void Activate()
        {
            this.Status = 2;
            Agent.RefreshBehaviours(false, true);
            Agent.DebugColor = Color.Green;
        }

        public bool HandleMessage()
        {
            throw new NotImplementedException();
        }

        public override int Process()
        {
            // if inactive, activate goal
            if (Status == 3)
            {
                Activate();
            }

            // if target can be found, wander is complete
            if (Agent.FindMostDesirableTarget() != null)
            {
                Status = 1;
            }

            return Status;
        }

        public override void Terminate()
        {
            Agent.RefreshBehaviours(false, false);
        }

        public override string ToString()
        {
            return "Wander";
        }
    }
}
