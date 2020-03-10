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
            this.dbPanel1 = new AAI_assignment.DBPanel();
            this.dbPanel2 = new AAI_assignment.DBPanel();
            this.obstacleScaleSlider = new System.Windows.Forms.TrackBar();
            this.scaleSlider = new System.Windows.Forms.TrackBar();
            this.speedSlider = new System.Windows.Forms.TrackBar();
            this.speedLabel = new System.Windows.Forms.Label();
            this.obstacleSeperationBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.entityUpDown = new System.Windows.Forms.NumericUpDown();
            this.alignmentBox = new System.Windows.Forms.CheckBox();
            this.cohesionBox = new System.Windows.Forms.CheckBox();
            this.flockingBox = new System.Windows.Forms.CheckBox();
            this.seekBox = new System.Windows.Forms.CheckBox();
            this.seperationBox = new System.Windows.Forms.CheckBox();
            this.arriveBox = new System.Windows.Forms.CheckBox();
            this.wanderingBox = new System.Windows.Forms.CheckBox();
            this.menuButton = new System.Windows.Forms.Button();
            this.dbPanel1.SuspendLayout();
            this.dbPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obstacleScaleSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // dbPanel1
            // 
            this.dbPanel1.BackColor = System.Drawing.Color.White;
            this.dbPanel1.Controls.Add(this.dbPanel2);
            this.dbPanel1.Controls.Add(this.menuButton);
            this.dbPanel1.Location = new System.Drawing.Point(0, 0);
            this.dbPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.dbPanel1.Name = "dbPanel1";
            this.dbPanel1.Size = new System.Drawing.Size(2560, 1329);
            this.dbPanel1.TabIndex = 0;
            this.dbPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.dbPanel1_Paint);
            this.dbPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dbPanel1_MouseClick);
            // 
            // dbPanel2
            // 
            this.dbPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dbPanel2.Controls.Add(this.obstacleScaleSlider);
            this.dbPanel2.Controls.Add(this.scaleSlider);
            this.dbPanel2.Controls.Add(this.speedSlider);
            this.dbPanel2.Controls.Add(this.speedLabel);
            this.dbPanel2.Controls.Add(this.obstacleSeperationBox);
            this.dbPanel2.Controls.Add(this.label1);
            this.dbPanel2.Controls.Add(this.entityUpDown);
            this.dbPanel2.Controls.Add(this.alignmentBox);
            this.dbPanel2.Controls.Add(this.cohesionBox);
            this.dbPanel2.Controls.Add(this.flockingBox);
            this.dbPanel2.Controls.Add(this.seekBox);
            this.dbPanel2.Controls.Add(this.seperationBox);
            this.dbPanel2.Controls.Add(this.arriveBox);
            this.dbPanel2.Controls.Add(this.wanderingBox);
            this.dbPanel2.Location = new System.Drawing.Point(16, 39);
            this.dbPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.dbPanel2.Name = "dbPanel2";
            this.dbPanel2.Size = new System.Drawing.Size(801, 518);
            this.dbPanel2.TabIndex = 1;
            // 
            // obstacleScaleSlider
            // 
            this.obstacleScaleSlider.Location = new System.Drawing.Point(148, 129);
            this.obstacleScaleSlider.Maximum = 500;
            this.obstacleScaleSlider.Minimum = 5;
            this.obstacleScaleSlider.Name = "obstacleScaleSlider";
            this.obstacleScaleSlider.Size = new System.Drawing.Size(197, 56);
            this.obstacleScaleSlider.TabIndex = 12;
            this.obstacleScaleSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.obstacleScaleSlider.Value = 30;
            this.obstacleScaleSlider.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // scaleSlider
            // 
            this.scaleSlider.Location = new System.Drawing.Point(148, 55);
            this.scaleSlider.Maximum = 300;
            this.scaleSlider.Minimum = 4;
            this.scaleSlider.Name = "scaleSlider";
            this.scaleSlider.Size = new System.Drawing.Size(197, 56);
            this.scaleSlider.TabIndex = 11;
            this.scaleSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.scaleSlider.Value = 4;
            this.scaleSlider.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // speedSlider
            // 
            this.speedSlider.Location = new System.Drawing.Point(488, 11);
            this.speedSlider.Margin = new System.Windows.Forms.Padding(4);
            this.speedSlider.Maximum = 500;
            this.speedSlider.Minimum = 10;
            this.speedSlider.Name = "speedSlider";
            this.speedSlider.Size = new System.Drawing.Size(280, 56);
            this.speedSlider.TabIndex = 10;
            this.speedSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.speedSlider.Value = 50;
            this.speedSlider.Scroll += new System.EventHandler(this.speedSlider_Scroll);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(382, 18);
            this.speedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(84, 17);
            this.speedLabel.TabIndex = 9;
            this.speedLabel.Text = "Max speed: ";
            // 
            // obstacleSeperationBox
            // 
            this.obstacleSeperationBox.AutoSize = true;
            this.obstacleSeperationBox.Location = new System.Drawing.Point(16, 187);
            this.obstacleSeperationBox.Margin = new System.Windows.Forms.Padding(4);
            this.obstacleSeperationBox.Name = "obstacleSeperationBox";
            this.obstacleSeperationBox.Size = new System.Drawing.Size(159, 21);
            this.obstacleSeperationBox.TabIndex = 8;
            this.obstacleSeperationBox.Text = "Obstacle Seperation";
            this.obstacleSeperationBox.UseVisualStyleBackColor = true;
            this.obstacleSeperationBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Entities";
            // 
            // entityUpDown
            // 
            this.entityUpDown.Location = new System.Drawing.Point(219, 16);
            this.entityUpDown.Margin = new System.Windows.Forms.Padding(4);
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
            this.entityUpDown.Size = new System.Drawing.Size(116, 22);
            this.entityUpDown.TabIndex = 6;
            this.entityUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.entityUpDown.ValueChanged += new System.EventHandler(this.entityUpDown_ValueChanged);
            // 
            // alignmentBox
            // 
            this.alignmentBox.AutoSize = true;
            this.alignmentBox.Location = new System.Drawing.Point(16, 46);
            this.alignmentBox.Margin = new System.Windows.Forms.Padding(4);
            this.alignmentBox.Name = "alignmentBox";
            this.alignmentBox.Size = new System.Drawing.Size(92, 21);
            this.alignmentBox.TabIndex = 5;
            this.alignmentBox.Text = "Alignment";
            this.alignmentBox.UseVisualStyleBackColor = true;
            this.alignmentBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // cohesionBox
            // 
            this.cohesionBox.AutoSize = true;
            this.cohesionBox.Location = new System.Drawing.Point(16, 74);
            this.cohesionBox.Margin = new System.Windows.Forms.Padding(4);
            this.cohesionBox.Name = "cohesionBox";
            this.cohesionBox.Size = new System.Drawing.Size(89, 21);
            this.cohesionBox.TabIndex = 4;
            this.cohesionBox.Text = "Cohesion";
            this.cohesionBox.UseVisualStyleBackColor = true;
            this.cohesionBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // flockingBox
            // 
            this.flockingBox.AutoSize = true;
            this.flockingBox.Location = new System.Drawing.Point(16, 215);
            this.flockingBox.Margin = new System.Windows.Forms.Padding(4);
            this.flockingBox.Name = "flockingBox";
            this.flockingBox.Size = new System.Drawing.Size(82, 21);
            this.flockingBox.TabIndex = 3;
            this.flockingBox.Text = "Flocking";
            this.flockingBox.UseVisualStyleBackColor = true;
            this.flockingBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // seekBox
            // 
            this.seekBox.AutoSize = true;
            this.seekBox.Location = new System.Drawing.Point(16, 102);
            this.seekBox.Margin = new System.Windows.Forms.Padding(4);
            this.seekBox.Name = "seekBox";
            this.seekBox.Size = new System.Drawing.Size(81, 21);
            this.seekBox.TabIndex = 2;
            this.seekBox.Text = "Seeking";
            this.seekBox.UseVisualStyleBackColor = true;
            this.seekBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // seperationBox
            // 
            this.seperationBox.AutoSize = true;
            this.seperationBox.Location = new System.Drawing.Point(16, 130);
            this.seperationBox.Margin = new System.Windows.Forms.Padding(4);
            this.seperationBox.Name = "seperationBox";
            this.seperationBox.Size = new System.Drawing.Size(99, 21);
            this.seperationBox.TabIndex = 1;
            this.seperationBox.Text = "Seperation";
            this.seperationBox.UseVisualStyleBackColor = true;
            this.seperationBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // arriveBox
            // 
            this.arriveBox.AutoSize = true;
            this.arriveBox.Location = new System.Drawing.Point(16, 17);
            this.arriveBox.Margin = new System.Windows.Forms.Padding(4);
            this.arriveBox.Name = "arriveBox";
            this.arriveBox.Size = new System.Drawing.Size(67, 21);
            this.arriveBox.TabIndex = 0;
            this.arriveBox.Text = "Arrive";
            this.arriveBox.UseVisualStyleBackColor = true;
            this.arriveBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // wanderingBox
            // 
            this.wanderingBox.AutoSize = true;
            this.wanderingBox.Location = new System.Drawing.Point(16, 159);
            this.wanderingBox.Margin = new System.Windows.Forms.Padding(4);
            this.wanderingBox.Name = "wanderingBox";
            this.wanderingBox.Size = new System.Drawing.Size(99, 21);
            this.wanderingBox.TabIndex = 0;
            this.wanderingBox.Text = "Wandering";
            this.wanderingBox.UseVisualStyleBackColor = true;
            this.wanderingBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // menuButton
            // 
            this.menuButton.Location = new System.Drawing.Point(16, 4);
            this.menuButton.Margin = new System.Windows.Forms.Padding(4);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(100, 28);
            this.menuButton.TabIndex = 0;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.dbPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Steering";
            this.dbPanel1.ResumeLayout(false);
            this.dbPanel2.ResumeLayout(false);
            this.dbPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obstacleScaleSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DBPanel dbPanel1;
        private System.Windows.Forms.Button menuButton;
        private DBPanel dbPanel2;
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
    }
}

