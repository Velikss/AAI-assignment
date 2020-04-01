using System;
using System.Drawing;

namespace AAI_assignment
{
    class DestroyGoal : AtomicGoal
    {
        public Agent agent;

        public DestroyGoal(Agent a)
        {
            this.agent = a;
        }

        public override void Activate()
        {
            this.status = 2;
            agent.Target.Attackers.Add(agent);
        }

        public bool HandleMessage()
        {
            throw new NotImplementedException();
        }

        public override int Process()
        {
            // if inactive, activate goal
            if (status == 3)
            {
                Activate();
            }

            // if target destroyed, set status to complete
            if (agent.Target.Dead)
            {
                agent.Target.Attackers.Remove(agent);
                status = 1;
            }
            else
            {
                // color to red (attacking)
                agent.DebugColor = Color.Red;
            }

            // if target is out of range the destroying has failed
            if (Vector2D.DistanceSquared(agent.Pos, agent.Target.Pos) > 2000)
            {
                status = 0;
            }

            return status;
        }

        public override void Terminate()
        {
            agent.Target.Attackers.Remove(agent);
        }

        public override string ToString()
        {
            return "Destroy";
        }
    }
}
