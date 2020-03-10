using AAI_assignment.behaviour;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAI_assignment
{
    public partial class Form1 : Form
    {
        public World world;
        System.Timers.Timer timer;
        public const float timeDelta = 0.8f;
        
        public Form1()
        {
            InitializeComponent();

            world = new World(w: dbPanel1.Width, h: dbPanel1.Height);
            
            timer = new System.Timers.Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 20;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            world.Update(timeDelta);
            dbPanel1.Invalidate();
        }

        private void dbPanel1_Paint(object sender, PaintEventArgs e)
        {
            world.Render(e.Graphics);
        }
        
        private void dbPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            world.Target.Pos = new Vector2D(e.X, e.Y);
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            if (this.dbPanel2.Visible)
                this.dbPanel2.Visible = false;
            else
            {
                this.dbPanel2.Visible = true;
            }

        }

        private void behaviourBox_CheckedChanged(object sender, EventArgs e)
        {
            WorldParameters.alignment = alignmentBox.Checked;
            WorldParameters.arrive = arriveBox.Checked;
            WorldParameters.cohesion = cohesionBox.Checked;
            WorldParameters.flocking = flockingBox.Checked;
            WorldParameters.seek = seekBox.Checked;
            WorldParameters.separation = seperationBox.Checked;
            WorldParameters.wandering = wanderingBox.Checked;
            WorldParameters.obstacleSeparation = obstacleSeperationBox.Checked;

            for (int i = 0; world.Entities.Count > i; i++)
            {
                world.Entities[i].SB.Clear();

                if (WorldParameters.alignment)
                    world.Entities[i].SB.Add(new AlignmentBehaviour(world.Entities[i], WorldParameters.AlignmentRadius, world.Entities, WorldParameters.AlignmentForce));
                if (WorldParameters.arrive)
                    world.Entities[i].SB.Add(new ArriveBehaviour(world.Entities[i], WorldParameters.decel));
                if (WorldParameters.cohesion)
                    world.Entities[i].SB.Add(new CohesionBehaviour(world.Entities[i], WorldParameters.CohesionRadius, world.Entities, WorldParameters.CohesionForce));
                if (WorldParameters.flocking)
                    world.Entities[i].SB.Add(new FlockingBehaviour(world.Entities[i], WorldParameters.FlockingCohesionRadius, WorldParameters.FlockingSeperationRadius, WorldParameters.FlockingAlignmentRadius, world.Entities, WorldParameters.FlockingCohesionForce, WorldParameters.FlockingSeperationForce, WorldParameters.FlockingAlignmentForce));
                if (WorldParameters.seek)
                    world.Entities[i].SB.Add(new SeekBehaviour(world.Entities[i]));
                if (WorldParameters.separation)
                    world.Entities[i].SB.Add(new SeparationBehaviour(world.Entities[i], WorldParameters.SeparationRadius, world.Entities, WorldParameters.SeparationForce));
                if (WorldParameters.wandering)
                    world.Entities[i].SB.Add(new WanderingBehaviour(world.Entities[i]));
                if (WorldParameters.obstacleSeparation)
                    world.Entities[i].SB.Add(new ObstacleSeparationBehaviour(world.Entities[i], WorldParameters.ObstacleScale + WorldParameters.ObstacleSeperationRadius, world.Obstacles, WorldParameters.ObstacleSeperationForce));
            }

        }

        private void entityUpDown_ValueChanged(object sender, EventArgs e)
        {
            int current = WorldParameters.EntityCount;

            if (current > (int)entityUpDown.Value) world.RemoveEntities(current - (int)entityUpDown.Value); else world.AddEntities((int)entityUpDown.Value - current);

            WorldParameters.EntityCount = (int)entityUpDown.Value;
        }

        private void speedSlider_Scroll(object sender, EventArgs e)
        {
            WorldParameters.EntityMaxSpeed = speedSlider.Value;
            speedLabel.Text = "Max speed: " + WorldParameters.EntityMaxSpeed;
            world.UpdateSpeed();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            WorldParameters.EntityScale = scaleSlider.Value;
            world.UpdateScale();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            WorldParameters.ObstacleScale = obstacleScaleSlider.Value;
            world.UpdateObstacleScale();
        }
    }
}
