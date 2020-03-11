using AAI_assignment.entity;

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
