using System;
using System.Linq;
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
            PrepareSliderPanel();

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

        private void PrepareSliderPanel()
        {
            var fields = typeof(WorldParameters).GetFields();
            int index = 0;
            foreach (var field in fields)
            {
                if (field.Name.Contains("Force") || field.Name.Contains("Radius"))
                {

                    Label l = new Label();
                    l.Text = field.Name.ToString();
                    l.Left = 5;
                    l.Top = index * 65 + 10;
                    l.Size = new System.Drawing.Size(150, 15);
                    sliderPage.Controls.Add(l);

                    if (field.FieldType.Equals(typeof(float)) || field.FieldType.Equals(typeof(int)))
                    {
                        TrackBar bar = new TrackBar();
                        bar.Left = 5;
                        bar.Top = index * 65 + 25;
                        bar.Minimum = 0;
                        bar.Maximum = 100;
                        bar.TickStyle = TickStyle.None;
                        bar.Name = field.Name;
                        bar.ValueChanged += (object sender, EventArgs e) =>
                        {
                            Console.WriteLine(bar.Name + WorldParameters.FlockingSeparationForce);
                            fields.First(o => o.Name == bar.Name).SetValue(null, bar.Value);
                        };
                        bar.Value = Convert.ToInt32(field.GetValue(null));
                        sliderPage.Controls.Add(bar);
                    }
                    else
                    {
                        throw new Exception("non implemented type.");
                    }
                    index++;
                }
            }
        }

        private void dbPanel1_Paint(object sender, PaintEventArgs e)
        {
            world.Render(e.Graphics);
        }

        private void dbPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            //world.Target.Pos = new Vector2D(e.X, e.Y);
            world.PathFinding(e.X, e.Y);
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
            try
            {
                this.menuPanel.Height = this.Height - 100;
                this.worldPanel.Height = this.Height;
                this.world.Height = this.Height;

                this.worldPanel.Width = this.Width;
                this.world.Width = this.Width;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"Could not resize ({this.Width} x {this.Height})");
            }
        }
    }
}
