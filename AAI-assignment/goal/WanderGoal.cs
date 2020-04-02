using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment
{
    class WanderGoal : AtomicGoal
    {
        public Agent agent;

        public WanderGoal(Agent a)
        {
            this.agent = a;
        }

        public override void Activate()
        {
            this.status = 2;
            agent.RefreshBehaviours(false, true);
            agent.DebugColor = Color.Green;
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

            // if target can be found, wander is complete
            if(agent.FindMostDesirableTarget() != null)
            {
                status = 1;
            }

            return status;
        }

        public override void Terminate()
        {
            agent.RefreshBehaviours(false, false);
        }

        public override string ToString()
        {
            return "Wander";
        }
    }
}
