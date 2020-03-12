using System;
using System.Drawing;

namespace AAI_assignment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuPanel = new System.Windows.Forms.TabControl();
            this.behaviourPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.obstacleScaleSlider = new System.Windows.Forms.TrackBar();
            this.arriveBox = new System.Windows.Forms.CheckBox();
            this.scaleSlider = new System.Windows.Forms.TrackBar();
            this.alignmentBox = new System.Windows.Forms.CheckBox();
            this.speedSlider = new System.Windows.Forms.TrackBar();
            this.cohesionBox = new System.Windows.Forms.CheckBox();
            this.speedLabel = new System.Windows.Forms.Label();
            this.seekBox = new System.Windows.Forms.CheckBox();
            this.entityUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.obstacleSeperationBox = new System.Windows.Forms.CheckBox();
            this.seperationBox = new System.Windows.Forms.CheckBox();
            this.flockingBox = new System.Windows.Forms.CheckBox();
            this.wanderingBox = new System.Windows.Forms.CheckBox();
            this.sliderPage = new System.Windows.Forms.TabPage();
            this.worldPanel = new AAI_assignment.DBPanel();
            this.menuPanel.SuspendLayout();
            this.behaviourPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obstacleScaleSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.behaviourPage);
            this.menuPanel.Controls.Add(this.sliderPage);
            this.menuPanel.Location = new System.Drawing.Point(3, 11);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.SelectedIndex = 0;
            this.menuPanel.Size = new System.Drawing.Size(254, 768);
            this.menuPanel.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.behaviourPage.Controls.Add(this.label3);
            this.behaviourPage.Controls.Add(this.label2);
            this.behaviourPage.Controls.Add(this.obstacleScaleSlider);
            this.behaviourPage.Controls.Add(this.arriveBox);
            this.behaviourPage.Controls.Add(this.scaleSlider);
            this.behaviourPage.Controls.Add(this.alignmentBox);
            this.behaviourPage.Controls.Add(this.speedSlider);
            this.behaviourPage.Controls.Add(this.cohesionBox);
            this.behaviourPage.Controls.Add(this.speedLabel);
            this.behaviourPage.Controls.Add(this.seekBox);
            this.behaviourPage.Controls.Add(this.entityUpDown);
            this.behaviourPage.Controls.Add(this.label1);
            this.behaviourPage.Controls.Add(this.obstacleSeperationBox);
            this.behaviourPage.Controls.Add(this.seperationBox);
            this.behaviourPage.Controls.Add(this.flockingBox);
            this.behaviourPage.Controls.Add(this.wanderingBox);
            this.behaviourPage.Location = new System.Drawing.Point(4, 22);
            this.behaviourPage.Name = "tabPage1";
            this.behaviourPage.Padding = new System.Windows.Forms.Padding(3);
            this.behaviourPage.Size = new System.Drawing.Size(246, 742);
            this.behaviourPage.TabIndex = 0;
            this.behaviourPage.Text = "Behaviour";
            this.behaviourPage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Obstacle size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Entity size";
            // 
            // obstacleScaleSlider
            // 
            this.obstacleScaleSlider.Location = new System.Drawing.Point(8, 347);
            this.obstacleScaleSlider.Margin = new System.Windows.Forms.Padding(2);
            this.obstacleScaleSlider.Maximum = 500;
            this.obstacleScaleSlider.Minimum = 5;
            this.obstacleScaleSlider.Name = "obstacleScaleSlider";
            this.obstacleScaleSlider.Size = new System.Drawing.Size(222, 45);
            this.obstacleScaleSlider.TabIndex = 12;
            this.obstacleScaleSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.obstacleScaleSlider.Value = 30;
            this.obstacleScaleSlider.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // arriveBox
            // 
            this.arriveBox.AutoSize = true;
            this.arriveBox.Location = new System.Drawing.Point(6, 6);
            this.arriveBox.Name = "arriveBox";
            this.arriveBox.Size = new System.Drawing.Size(53, 17);
            this.arriveBox.TabIndex = 0;
            this.arriveBox.Text = "Arrive";
            this.arriveBox.UseVisualStyleBackColor = true;
            this.arriveBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // scaleSlider
            // 
            this.scaleSlider.Location = new System.Drawing.Point(8, 276);
            this.scaleSlider.Margin = new System.Windows.Forms.Padding(2);
            this.scaleSlider.Maximum = 300;
            this.scaleSlider.Minimum = 4;
            this.scaleSlider.Name = "scaleSlider";
            this.scaleSlider.Size = new System.Drawing.Size(222, 45);
            this.scaleSlider.TabIndex = 11;
            this.scaleSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.scaleSlider.Value = 4;
            this.scaleSlider.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // alignmentBox
            // 
            this.alignmentBox.AutoSize = true;
            this.alignmentBox.Location = new System.Drawing.Point(6, 29);
            this.alignmentBox.Name = "alignmentBox";
            this.alignmentBox.Size = new System.Drawing.Size(72, 17);
            this.alignmentBox.TabIndex = 5;
            this.alignmentBox.Text = "Alignment";
            this.alignmentBox.UseVisualStyleBackColor = true;
            this.alignmentBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // speedSlider
            // 
            this.speedSlider.Location = new System.Drawing.Point(8, 215);
            this.speedSlider.Maximum = 500;
            this.speedSlider.Minimum = 10;
            this.speedSlider.Name = "speedSlider";
            this.speedSlider.Size = new System.Drawing.Size(222, 45);
            this.speedSlider.TabIndex = 10;
            this.speedSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.speedSlider.Value = 50;
            this.speedSlider.Scroll += new System.EventHandler(this.speedSlider_Scroll);
            // 
            // cohesionBox
            // 
            this.cohesionBox.AutoSize = true;
            this.cohesionBox.Location = new System.Drawing.Point(6, 52);
            this.cohesionBox.Name = "cohesionBox";
            this.cohesionBox.Size = new System.Drawing.Size(70, 17);
            this.cohesionBox.TabIndex = 4;
            this.cohesionBox.Text = "Cohesion";
            this.cohesionBox.UseVisualStyleBackColor = true;
            this.cohesionBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(72, 199);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(65, 13);
            this.speedLabel.TabIndex = 9;
            this.speedLabel.Text = "Max speed: ";
            // 
            // seekBox
            // 
            this.seekBox.AutoSize = true;
            this.seekBox.Location = new System.Drawing.Point(6, 75);
            this.seekBox.Name = "seekBox";
            this.seekBox.Size = new System.Drawing.Size(65, 17);
            this.seekBox.TabIndex = 2;
            this.seekBox.Text = "Seeking";
            this.seekBox.UseVisualStyleBackColor = true;
            this.seekBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // entityUpDown
            // 
            this.entityUpDown.Location = new System.Drawing.Point(143, 6);
            this.entityUpDown.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.entityUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.entityUpDown.Name = "entityUpDown";
            this.entityUpDown.Size = new System.Drawing.Size(87, 20);
            this.entityUpDown.TabIndex = 6;
            this.entityUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.entityUpDown.ValueChanged += new System.EventHandler(this.entityUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Entities";
            // 
            // obstacleSeperationBox
            // 
            this.obstacleSeperationBox.AutoSize = true;
            this.obstacleSeperationBox.Location = new System.Drawing.Point(6, 143);
            this.obstacleSeperationBox.Name = "obstacleSeperationBox";
            this.obstacleSeperationBox.Size = new System.Drawing.Size(122, 17);
            this.obstacleSeperationBox.TabIndex = 8;
            this.obstacleSeperationBox.Text = "Obstacle Seperation";
            this.obstacleSeperationBox.UseVisualStyleBackColor = true;
            this.obstacleSeperationBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // seperationBox
            // 
            this.seperationBox.AutoSize = true;
            this.seperationBox.Location = new System.Drawing.Point(6, 98);
            this.seperationBox.Name = "seperationBox";
            this.seperationBox.Size = new System.Drawing.Size(77, 17);
            this.seperationBox.TabIndex = 1;
            this.seperationBox.Text = "Seperation";
            this.seperationBox.UseVisualStyleBackColor = true;
            this.seperationBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // flockingBox
            // 
            this.flockingBox.AutoSize = true;
            this.flockingBox.Location = new System.Drawing.Point(5, 166);
            this.flockingBox.Name = "flockingBox";
            this.flockingBox.Size = new System.Drawing.Size(66, 17);
            this.flockingBox.TabIndex = 3;
            this.flockingBox.Text = "Flocking";
            this.flockingBox.UseVisualStyleBackColor = true;
            this.flockingBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // wanderingBox
            // 
            this.wanderingBox.AutoSize = true;
            this.wanderingBox.Location = new System.Drawing.Point(6, 120);
            this.wanderingBox.Name = "wanderingBox";
            this.wanderingBox.Size = new System.Drawing.Size(78, 17);
            this.wanderingBox.TabIndex = 0;
            this.wanderingBox.Text = "Wandering";
            this.wanderingBox.UseVisualStyleBackColor = true;
            this.wanderingBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // sliderPage
            // 
            this.sliderPage.AutoScroll = true;
            this.sliderPage.Location = new System.Drawing.Point(4, 22);
            this.sliderPage.Name = "sliderPage";
            this.sliderPage.Padding = new System.Windows.Forms.Padding(3);
            this.sliderPage.Size = new System.Drawing.Size(246, 742);
            this.sliderPage.TabIndex = 1;
            this.sliderPage.Text = "Forces";
            this.sliderPage.UseVisualStyleBackColor = true;
            // 
            // worldPanel
            // 
            this.worldPanel.BackColor = System.Drawing.Color.White;
            this.worldPanel.Location = new System.Drawing.Point(260, 0);
            this.worldPanel.Name = "worldPanel";
            this.worldPanel.Size = new System.Drawing.Size(1640, 980);
            this.worldPanel.TabIndex = 0;
            this.worldPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.dbPanel1_Paint);
            this.worldPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dbPanel1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.worldPanel);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Steering";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuPanel.ResumeLayout(false);
            this.behaviourPage.ResumeLayout(false);
            this.behaviourPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obstacleScaleSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DBPanel worldPanel;
        private System.Windows.Forms.CheckBox alignmentBox;
        private System.Windows.Forms.CheckBox arriveBox;
        private System.Windows.Forms.CheckBox cohesionBox;
        private System.Windows.Forms.CheckBox flockingBox;
        private System.Windows.Forms.CheckBox seekBox;
        private System.Windows.Forms.CheckBox seperationBox;
        private System.Windows.Forms.CheckBox wanderingBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown entityUpDown;
        private System.Windows.Forms.CheckBox obstacleSeperationBox;
        private System.Windows.Forms.TrackBar speedSlider;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.TrackBar scaleSlider;
        private System.Windows.Forms.TrackBar obstacleScaleSlider;
        private System.Windows.Forms.TabControl menuPanel;
        private System.Windows.Forms.TabPage behaviourPage;
        private System.Windows.Forms.TabPage sliderPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

