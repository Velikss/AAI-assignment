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
        public int defaultWidth = 1920, defaultHeight = 980;

        public Form1()
        {
            InitializeComponent();

            world = new World(w: worldPanel.Width, h: worldPanel.Height);

            timer = new System.Timers.Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 20;
            timer.Enabled = true;

        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            world.Update(timeDelta);
            worldPanel.Invalidate();
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
            if (this.menuPanel.Visible)
                this.menuPanel.Visible = false;
            else
            {
                this.menuPanel.Visible = true;
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

            world.RefreshBehaviours();

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

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.menuPanel.Height = this.Height;
            this.worldPanel.Height = this.Height;
            this.world.Height = this.Height;

            this.worldPanel.Width = this.Width;
            this.world.Width = this.Width;

        }
    }
}
