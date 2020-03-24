using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;
using ComboBox = System.Windows.Forms.ComboBox;
using Control = System.Windows.Forms.Control;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Controls.Panel;

namespace AAI_assignment
{
    public partial class Form1 : Form
    {
        public World world;
        System.Timers.Timer timer;
        public const float timeDelta = 0.8f;
        public int defaultWidth = 1920, defaultHeight = 980;
        public List<Control> ControlList = new List<Control>(); 

        public Form1()
        {
            InitializeComponent();
            //PrepareSliderPanel();
            PopulateBehaviourBox();

            world = new World(w: worldPanel.Width, h: worldPanel.Height);

            timer = new System.Timers.Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 20;
            timer.Enabled = true;

        }

        private void PopulateBehaviourBox()
        {
            behaviourBox.Items.Add("Arrive");
            behaviourBox.Items.Add("Alignment");
            behaviourBox.Items.Add("Cohesion");
            behaviourBox.Items.Add("Seek");
            behaviourBox.Items.Add("Separation");
            behaviourBox.Items.Add("Wandering");
            behaviourBox.Items.Add("Obstacle Separation");
            behaviourBox.Items.Add("Flocking");
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            world.Update(timeDelta);
            worldPanel.Invalidate();
        }

        private void PrepareSliderPanel(string behaviour)
        {
            var fields = typeof(WorldParameters).GetFields();
            int index = 0;
            int box = 30;
            foreach (var field in fields)
            {
                if (field.Name.Contains(behaviour.Split()[0]) && (field.Name.Contains("Force") || field.Name.Contains("Radius")))
                {
                    Label l = new Label();
                    l.Text = field.Name.ToString();
                    l.Left = 5;
                    l.Top = index * 65 + 10 + box;
                    l.Size = new System.Drawing.Size(150, 15);
                    sliderPage.Controls.Add(l);
                    ControlList.Add(l);
                    if (field.FieldType.Equals(typeof(float)) || field.FieldType.Equals(typeof(int)))
                    {
                        TrackBar bar = new TrackBar();
                        bar.Left = 5;
                        bar.Width = 200;
                        bar.Top = index * 65 + 25 + box;
                        bar.Minimum = 0;
                        bar.Maximum = 100;
                        bar.TickStyle = TickStyle.None;
                        bar.Name = field.Name;
                        bar.ValueChanged += (object sender, EventArgs e) =>
                        {
                            Console.WriteLine(bar.Name + WorldParameters.FlockingSepForce);
                            fields.First(o => o.Name == bar.Name).SetValue(null, bar.Value);
                        };
                        bar.Value = Convert.ToInt32(field.GetValue(null));
                        sliderPage.Controls.Add(bar);
                        ControlList.Add(l);
                    }
                    else
                    {
                        //throw new Exception("non implemented type.");
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
            WorldParameters.separation = separationBox.Checked;
            WorldParameters.wandering = wanderingBox.Checked;
            WorldParameters.obstacleSeparation = obstacleSeparationBox.Checked;

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

        private void behaviourBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sliderPage.Controls.Clear();
            sliderPage.Controls.Add(behaviourBox);
            PrepareSliderPanel(behaviourBox.SelectedItem.ToString());
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
