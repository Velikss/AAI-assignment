using System;

namespace AAI_assignment
{
    public abstract class AtomicGoal : Goal
    {
        public override void Activate()
        {
            throw new NotImplementedException();
        }

        public bool HandleMessage()
        {
            throw new NotImplementedException();
        }

        public override int Process()
        {
            throw new NotImplementedException();
        }

        public override void Terminate()
        {
            throw new NotImplementedException();
        }
    }
}
