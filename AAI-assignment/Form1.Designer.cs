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
            this.menuHost = new System.Windows.Forms.Integration.ElementHost();
            this.menu = new AAI_assignment.MenuOverlay(this.world);
            this.menuButton = new System.Windows.Forms.Button();
            this.dbPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbPanel1
            // 
            this.dbPanel1.BackColor = System.Drawing.Color.White;
            this.dbPanel1.Controls.Add(this.menuHost);
            this.dbPanel1.Controls.Add(this.menuButton);
            this.dbPanel1.Location = new System.Drawing.Point(0, 0);
            this.dbPanel1.Name = "dbPanel1";
            this.dbPanel1.Size = new System.Drawing.Size(1920, 1080);
            this.dbPanel1.TabIndex = 0;
            this.dbPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.dbPanel1_Paint);
            this.dbPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dbPanel1_MouseClick);
            // 
            // menuHost
            // 
            this.menuHost.Location = new System.Drawing.Point(12, 32);
            this.menuHost.Name = "menuHost";
            this.menuHost.Size = new System.Drawing.Size(1484, 503);
            this.menuHost.TabIndex = 1;
            this.menuHost.Text = "elementHost1";
            this.menuHost.Visible = false;
            this.menuHost.Child = this.menu;
            // 
            // menuButton
            // 
            this.menuButton.Location = new System.Drawing.Point(12, 3);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(75, 23);
            this.menuButton.TabIndex = 0;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.button1_Click);
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
            this.ResumeLayout(false);

        }

        #endregion

        private DBPanel dbPanel1;
        private System.Windows.Forms.Button menuButton;

        private System.Windows.Forms.Integration.ElementHost menuHost;
        private MenuOverlay menu;
    }
}

