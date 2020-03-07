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
            ((System.ComponentModel.ISupportInitialize)(this.entityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // dbPanel1
            // 
            this.dbPanel1.BackColor = System.Drawing.Color.White;
            this.dbPanel1.Controls.Add(this.dbPanel2);
            this.dbPanel1.Controls.Add(this.menuButton);
            this.dbPanel1.Location = new System.Drawing.Point(0, 0);
            this.dbPanel1.Name = "dbPanel1";
            this.dbPanel1.Size = new System.Drawing.Size(1920, 1080);
            this.dbPanel1.TabIndex = 0;
            this.dbPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.dbPanel1_Paint);
            this.dbPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dbPanel1_MouseClick);
            // 
            // dbPanel2
            // 
            this.dbPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dbPanel2.Controls.Add(this.label1);
            this.dbPanel2.Controls.Add(this.entityUpDown);
            this.dbPanel2.Controls.Add(this.alignmentBox);
            this.dbPanel2.Controls.Add(this.cohesionBox);
            this.dbPanel2.Controls.Add(this.flockingBox);
            this.dbPanel2.Controls.Add(this.seekBox);
            this.dbPanel2.Controls.Add(this.seperationBox);
            this.dbPanel2.Controls.Add(this.arriveBox);
            this.dbPanel2.Controls.Add(this.wanderingBox);
            this.dbPanel2.Location = new System.Drawing.Point(12, 32);
            this.dbPanel2.Name = "dbPanel2";
            this.dbPanel2.Size = new System.Drawing.Size(515, 219);
            this.dbPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Entities";
            // 
            // entityUpDown
            // 
            this.entityUpDown.Location = new System.Drawing.Point(172, 14);
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
            // alignmentBox
            // 
            this.alignmentBox.AutoSize = true;
            this.alignmentBox.Location = new System.Drawing.Point(13, 37);
            this.alignmentBox.Name = "alignmentBox";
            this.alignmentBox.Size = new System.Drawing.Size(72, 17);
            this.alignmentBox.TabIndex = 5;
            this.alignmentBox.Text = "Alignment";
            this.alignmentBox.UseVisualStyleBackColor = true;
            this.alignmentBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // cohesionBox
            // 
            this.cohesionBox.AutoSize = true;
            this.cohesionBox.Location = new System.Drawing.Point(13, 60);
            this.cohesionBox.Name = "cohesionBox";
            this.cohesionBox.Size = new System.Drawing.Size(70, 17);
            this.cohesionBox.TabIndex = 4;
            this.cohesionBox.Text = "Cohesion";
            this.cohesionBox.UseVisualStyleBackColor = true;
            this.cohesionBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // flockingBox
            // 
            this.flockingBox.AutoSize = true;
            this.flockingBox.Location = new System.Drawing.Point(13, 83);
            this.flockingBox.Name = "flockingBox";
            this.flockingBox.Size = new System.Drawing.Size(66, 17);
            this.flockingBox.TabIndex = 3;
            this.flockingBox.Text = "Flocking";
            this.flockingBox.UseVisualStyleBackColor = true;
            this.flockingBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // seekBox
            // 
            this.seekBox.AutoSize = true;
            this.seekBox.Location = new System.Drawing.Point(13, 106);
            this.seekBox.Name = "seekBox";
            this.seekBox.Size = new System.Drawing.Size(65, 17);
            this.seekBox.TabIndex = 2;
            this.seekBox.Text = "Seeking";
            this.seekBox.UseVisualStyleBackColor = true;
            this.seekBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // seperationBox
            // 
            this.seperationBox.AutoSize = true;
            this.seperationBox.Location = new System.Drawing.Point(13, 129);
            this.seperationBox.Name = "seperationBox";
            this.seperationBox.Size = new System.Drawing.Size(77, 17);
            this.seperationBox.TabIndex = 1;
            this.seperationBox.Text = "Seperation";
            this.seperationBox.UseVisualStyleBackColor = true;
            this.seperationBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // arriveBox
            // 
            this.arriveBox.AutoSize = true;
            this.arriveBox.Location = new System.Drawing.Point(12, 14);
            this.arriveBox.Name = "arriveBox";
            this.arriveBox.Size = new System.Drawing.Size(53, 17);
            this.arriveBox.TabIndex = 0;
            this.arriveBox.Text = "Arrive";
            this.arriveBox.UseVisualStyleBackColor = true;
            this.arriveBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // wanderingBox
            // 
            this.wanderingBox.AutoSize = true;
            this.wanderingBox.Location = new System.Drawing.Point(12, 152);
            this.wanderingBox.Name = "wanderingBox";
            this.wanderingBox.Size = new System.Drawing.Size(78, 17);
            this.wanderingBox.TabIndex = 0;
            this.wanderingBox.Text = "Wandering";
            this.wanderingBox.UseVisualStyleBackColor = true;
            this.wanderingBox.CheckedChanged += new System.EventHandler(this.behaviourBox_CheckedChanged);
            // 
            // menuButton
            // 
            this.menuButton.Location = new System.Drawing.Point(12, 3);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(75, 23);
            this.menuButton.TabIndex = 0;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.dbPanel1);
            this.Name = "Form1";
            this.Text = "Steering";
            this.dbPanel1.ResumeLayout(false);
            this.dbPanel2.ResumeLayout(false);
            this.dbPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entityUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        private void entityCount_Scroll(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
    }
}

