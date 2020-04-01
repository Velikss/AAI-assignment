namespace AAI_assignment
{
    public enum Status
    {
        failed = 0,
        complete = 1,
        active = 2,
        inactive = 3

    }
    public abstract class Goal
    {
        // failed = 0, complete = 1, active = 2, inactive = 3
        public int status = 3;
        public virtual void Activate() { }
        public virtual int Process() { return 0; }
        public virtual void Terminate() { }

        public bool HandleMessage()
        {
            return true;
        }

        public bool IsActive()
        {
            bool result = (status == 2) ? true : false;

            return result;
        }

        public bool IsInactive()
        {
            bool result = (status == 3) ? true : false;

            return result;
        }

        public bool HasFailed()
        {
            bool result = (status == 0) ? true : false;

            return result;
        }

        public bool IsComplete()
        {
            bool result = (status == 1) ? true : false;

            return result;
        }
    }
}
