﻿using AAI_assignment.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment
{
    public abstract class SteeringBehaviour
    {
        public MovingEntity ME { get; set; }
        public abstract Vector2D Calculate();

        public SteeringBehaviour(MovingEntity me)
        {
            ME = me;
        }
    }

    
}
