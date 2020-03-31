using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment
{
    class DestroyGoal : AtomicGoal
    {
        public Agent agent;

        public DestroyGoal(Agent a)
        {
            this.agent = a;
        }

        public void Activate()
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
            if (agent.Target.Health <= 0)
                status = 1;
            else
            {
                // color to red (attacking)
                agent.DebugColor = Color.Red;
            }

            return status;
        }

        public void Terminate()
        {
            agent.Target.Attackers.Remove(agent);
        }
    }
}
