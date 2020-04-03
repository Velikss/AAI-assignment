using System;
using System.Drawing;

namespace AAI_assignment
{
    class DestroyGoal : AtomicGoal
    {
        public Agent Agent;

        public DestroyGoal(Agent a)
        {
            this.Agent = a;
        }

        public override void Activate()
        {
            this.Status = 2;
            Agent.Target.Attackers.Add(Agent);
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

            // if target destroyed, set Status to complete
            if (Agent.Target.Dead)
            {
                Agent.Target.Attackers.Remove(Agent);
                Status = 1;
            }
            else
            {
                // color to red (attacking)
                Agent.DebugColor = Color.Red;
            }

            // if target is out of range the destroying has failed
            if (Vector2D.DistanceSquared(Agent.Pos, Agent.Target.Pos) > 2000)
            {
                Status = 0;
            }

            return Status;
        }

        public override void Terminate()
        {
            Agent.Target.Attackers.Remove(Agent);
        }

        public override string ToString()
        {
            return "Destroy";
        }
    }
}
