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
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.worldPanel = new AAI_assignment.DBPanel();
            this.menuPanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obstacleScaleSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.tabPage1);
            this.menuPanel.Controls.Add(this.tabPage2);
            this.menuPanel.Location = new System.Drawing.Point(4, 13);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.SelectedIndex = 0;
            this.menuPanel.Size = new System.Drawing.Size(339, 945);
            this.menuPanel.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.obstacleScaleSlider);
            this.tabPage1.Controls.Add(this.arriveBox);
            this.tabPage1.Controls.Add(this.scaleSlider);
            this.tabPage1.Controls.Add(this.alignmentBox);
            this.tabPage1.Controls.Add(this.speedSlider);
            this.tabPage1.Controls.Add(this.cohesionBox);
            this.tabPage1.Controls.Add(this.speedLabel);
            this.tabPage1.Controls.Add(this.seekBox);
            this.tabPage1.Controls.Add(this.entityUpDown);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.obstacleSeperationBox);
            this.tabPage1.Controls.Add(this.seperationBox);
            this.tabPage1.Controls.Add(this.flockingBox);
            this.tabPage1.Controls.Add(this.wanderingBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(331, 916);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Behaviour";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 398);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Obstacle size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 324);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Entity size";
            // 
            // obstacleScaleSlider
            // 
            this.obstacleScaleSlider.Location = new System.Drawing.Point(11, 427);
            this.obstacleScaleSlider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.obstacleScaleSlider.Maximum = 500;
            this.obstacleScaleSlider.Minimum = 5;
            this.obstacleScaleSlider.Name = "obstacleScaleSlider";
            this.obstacleScaleSlider.Size = new System.Drawing.Size(296, 56);
            this.obstacleScaleSlider.TabIndex = 12;
            this.obstacleScaleSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.obstacleScaleSlider.Value = 30;
            this.obstacleScaleSlider.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // arriveBox
            // 
            this.arriveBox.AutoSize = true;
            this.arriveBox.Location = new System.Drawing.Point(8, 7);
            this.arriveBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.arriveBox.Name = "arriveBox";
            this.arriveBox.Size = new System.Drawing.Size(67, 21);
            this.arriveBox.TabIndex = 0;
            this.arriveBox.Text = "Arrive";
            this.arriveBox.UseVisualStyleBackColor = true;
            this.arriveBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // scaleSlider
            // 
            this.scaleSlider.Location = new System.Drawing.Point(11, 340);
            this.scaleSlider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scaleSlider.Maximum = 300;
            this.scaleSlider.Minimum = 4;
            this.scaleSlider.Name = "scaleSlider";
            this.scaleSlider.Size = new System.Drawing.Size(296, 56);
            this.scaleSlider.TabIndex = 11;
            this.scaleSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.scaleSlider.Value = 4;
            this.scaleSlider.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // alignmentBox
            // 
            this.alignmentBox.AutoSize = true;
            this.alignmentBox.Location = new System.Drawing.Point(8, 36);
            this.alignmentBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.alignmentBox.Name = "alignmentBox";
            this.alignmentBox.Size = new System.Drawing.Size(92, 21);
            this.alignmentBox.TabIndex = 5;
            this.alignmentBox.Text = "Alignment";
            this.alignmentBox.UseVisualStyleBackColor = true;
            this.alignmentBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // speedSlider
            // 
            this.speedSlider.Location = new System.Drawing.Point(11, 265);
            this.speedSlider.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.speedSlider.Maximum = 500;
            this.speedSlider.Minimum = 10;
            this.speedSlider.Name = "speedSlider";
            this.speedSlider.Size = new System.Drawing.Size(296, 56);
            this.speedSlider.TabIndex = 10;
            this.speedSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.speedSlider.Value = 50;
            this.speedSlider.Scroll += new System.EventHandler(this.speedSlider_Scroll);
            // 
            // cohesionBox
            // 
            this.cohesionBox.AutoSize = true;
            this.cohesionBox.Location = new System.Drawing.Point(8, 64);
            this.cohesionBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cohesionBox.Name = "cohesionBox";
            this.cohesionBox.Size = new System.Drawing.Size(89, 21);
            this.cohesionBox.TabIndex = 4;
            this.cohesionBox.Text = "Cohesion";
            this.cohesionBox.UseVisualStyleBackColor = true;
            this.cohesionBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(96, 245);
            this.speedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(84, 17);
            this.speedLabel.TabIndex = 9;
            this.speedLabel.Text = "Max speed: ";
            // 
            // seekBox
            // 
            this.seekBox.AutoSize = true;
            this.seekBox.Location = new System.Drawing.Point(8, 92);
            this.seekBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.seekBox.Name = "seekBox";
            this.seekBox.Size = new System.Drawing.Size(81, 21);
            this.seekBox.TabIndex = 2;
            this.seekBox.Text = "Seeking";
            this.seekBox.UseVisualStyleBackColor = true;
            this.seekBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // entityUpDown
            // 
            this.entityUpDown.Location = new System.Drawing.Point(191, 7);
            this.entityUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Entities";
            // 
            // obstacleSeperationBox
            // 
            this.obstacleSeperationBox.AutoSize = true;
            this.obstacleSeperationBox.Location = new System.Drawing.Point(8, 176);
            this.obstacleSeperationBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.obstacleSeperationBox.Name = "obstacleSeperationBox";
            this.obstacleSeperationBox.Size = new System.Drawing.Size(159, 21);
            this.obstacleSeperationBox.TabIndex = 8;
            this.obstacleSeperationBox.Text = "Obstacle Seperation";
            this.obstacleSeperationBox.UseVisualStyleBackColor = true;
            this.obstacleSeperationBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // seperationBox
            // 
            this.seperationBox.AutoSize = true;
            this.seperationBox.Location = new System.Drawing.Point(8, 121);
            this.seperationBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.seperationBox.Name = "seperationBox";
            this.seperationBox.Size = new System.Drawing.Size(99, 21);
            this.seperationBox.TabIndex = 1;
            this.seperationBox.Text = "Seperation";
            this.seperationBox.UseVisualStyleBackColor = true;
            this.seperationBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // flockingBox
            // 
            this.flockingBox.AutoSize = true;
            this.flockingBox.Location = new System.Drawing.Point(7, 204);
            this.flockingBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flockingBox.Name = "flockingBox";
            this.flockingBox.Size = new System.Drawing.Size(82, 21);
            this.flockingBox.TabIndex = 3;
            this.flockingBox.Text = "Flocking";
            this.flockingBox.UseVisualStyleBackColor = true;
            this.flockingBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // wanderingBox
            // 
            this.wanderingBox.AutoSize = true;
            this.wanderingBox.Location = new System.Drawing.Point(8, 148);
            this.wanderingBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wanderingBox.Name = "wanderingBox";
            this.wanderingBox.Size = new System.Drawing.Size(99, 21);
            this.wanderingBox.TabIndex = 0;
            this.wanderingBox.Text = "Wandering";
            this.wanderingBox.UseVisualStyleBackColor = true;
            this.wanderingBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(331, 916);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Forces";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // worldPanel
            // 
            this.worldPanel.BackColor = System.Drawing.Color.White;
            this.worldPanel.Location = new System.Drawing.Point(347, 0);
            this.worldPanel.Margin = new System.Windows.Forms.Padding(4);
            this.worldPanel.Name = "worldPanel";
            this.worldPanel.Size = new System.Drawing.Size(2186, 1206);
            this.worldPanel.TabIndex = 0;
            this.worldPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.dbPanel1_Paint);
            this.worldPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dbPanel1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.worldPanel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Steering";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuPanel.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

