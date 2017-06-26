namespace launcher
{
    partial class PlayersOnline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersOnline));
            this.lblExit = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.picNext = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.picSide = new System.Windows.Forms.PictureBox();
            this.picClass = new System.Windows.Forms.PictureBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.picBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.lblExit.Location = new System.Drawing.Point(283, -2);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(18, 21);
            this.lblExit.TabIndex = 15;
            this.lblExit.Text = "x";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.lblTitle.Location = new System.Drawing.Point(21, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(137, 22);
            this.lblTitle.TabIndex = 17;
            this.lblTitle.Text = "Online Players";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.lblInfo.Location = new System.Drawing.Point(-2, 390);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 15);
            this.lblInfo.TabIndex = 19;
            
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblName.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblName.Location = new System.Drawing.Point(43, 44);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(50, 20);
            this.lblName.TabIndex = 21;
            this.lblName.Text = "Jeakz";
            this.lblName.Visible = false;
            // 
            // picSide
            // 
            this.picSide.BackColor = System.Drawing.Color.Transparent;
            this.picSide.Image = global::launcher.Properties.Resources.horde;
            this.picSide.Location = new System.Drawing.Point(265, 42);
            this.picSide.Name = "picSide";
            this.picSide.Size = new System.Drawing.Size(25, 25);
            this.picSide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSide.TabIndex = 22;
            this.picSide.TabStop = false;
            this.picSide.Visible = false;
            // 
            // picClass
            // 
            this.picClass.BackColor = System.Drawing.Color.Transparent;
            this.picClass.Image = global::launcher.Properties.Resources.warrior;
            this.picClass.Location = new System.Drawing.Point(12, 42);
            this.picClass.Name = "picClass";
            this.picClass.Size = new System.Drawing.Size(25, 25);
            this.picClass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClass.TabIndex = 23;
            this.picClass.TabStop = false;
            this.picClass.Visible = false;
            // 
            // lblLevel
            // 
            this.lblLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLevel.AutoSize = true;
            this.lblLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblLevel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLevel.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblLevel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLevel.Location = new System.Drawing.Point(237, 44);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(25, 20);
            this.lblLevel.TabIndex = 24;
            this.lblLevel.Text = "80";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblLevel.Visible = false;
            // 
            // PlayersOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::launcher.Properties.Resources.settings_form;
            this.ClientSize = new System.Drawing.Size(302, 404);
            this.Controls.Add(this.picBack);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.picClass);
            this.Controls.Add(this.picSide);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picNext);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlayersOnline";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Online Players";
            this.Load += new System.EventHandler(this.Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.PictureBox picNext;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picSide;
        private System.Windows.Forms.PictureBox picClass;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.PictureBox picBack;
    }
}