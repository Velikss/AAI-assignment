using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment.goaldriven
{
    public enum Status
    {
        failed = 0,
        complete = 1,
        active  = 2,
        inactive = 3

    }
    public abstract class Goal
    {
        // failed = 0, complete = 1, active = 2, inactive = 3
        public int status;
        public void Activate() { }
        public int Process() { return 0; }
        public void Terminate() { }
        public bool HandleMessage() {  }

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
