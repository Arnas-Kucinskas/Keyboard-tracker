namespace HookFromV2
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.userLevelTimer = new System.Windows.Forms.Timer(this.components);
            this.btn_tracking = new MaterialSkin.Controls.MaterialFlatButton();
            this.btn_help = new MaterialSkin.Controls.MaterialFlatButton();
            this.btn_calibrate = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialDivider4 = new MaterialSkin.Controls.MaterialDivider();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.label_analysis = new MaterialSkin.Controls.MaterialLabel();
            this.label_tracking = new MaterialSkin.Controls.MaterialLabel();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.debug_label = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // userLevelTimer
            // 
            this.userLevelTimer.Tick += new System.EventHandler(this.userLevelTimer_Tick);
            // 
            // btn_tracking
            // 
            this.btn_tracking.AutoSize = true;
            this.btn_tracking.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_tracking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_tracking.Depth = 0;
            this.btn_tracking.ForeColor = System.Drawing.Color.Red;
            this.btn_tracking.Location = new System.Drawing.Point(13, 140);
            this.btn_tracking.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_tracking.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_tracking.Name = "btn_tracking";
            this.btn_tracking.Primary = false;
            this.btn_tracking.Size = new System.Drawing.Size(125, 36);
            this.btn_tracking.TabIndex = 24;
            this.btn_tracking.Text = "Start tracking";
            this.btn_tracking.UseVisualStyleBackColor = false;
            this.btn_tracking.Click += new System.EventHandler(this.btn_tracking_Click);
            // 
            // btn_help
            // 
            this.btn_help.AutoSize = true;
            this.btn_help.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_help.BackColor = System.Drawing.Color.Transparent;
            this.btn_help.Depth = 0;
            this.btn_help.Location = new System.Drawing.Point(13, 245);
            this.btn_help.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_help.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_help.Name = "btn_help";
            this.btn_help.Primary = false;
            this.btn_help.Size = new System.Drawing.Size(46, 36);
            this.btn_help.TabIndex = 25;
            this.btn_help.Text = "Help";
            this.btn_help.UseVisualStyleBackColor = false;
            this.btn_help.Click += new System.EventHandler(this.btn_help_Click);
            // 
            // btn_calibrate
            // 
            this.btn_calibrate.AutoSize = true;
            this.btn_calibrate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_calibrate.BackColor = System.Drawing.Color.Transparent;
            this.btn_calibrate.Depth = 0;
            this.btn_calibrate.Location = new System.Drawing.Point(13, 197);
            this.btn_calibrate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_calibrate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_calibrate.Name = "btn_calibrate";
            this.btn_calibrate.Primary = false;
            this.btn_calibrate.Size = new System.Drawing.Size(84, 36);
            this.btn_calibrate.TabIndex = 26;
            this.btn_calibrate.Text = "Calibrate";
            this.btn_calibrate.UseVisualStyleBackColor = false;
            this.btn_calibrate.Click += new System.EventHandler(this.btn_calibrate_Click);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(13, 185);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(336, 3);
            this.materialDivider1.TabIndex = 27;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HookFromV2.Properties.Resources.Screenshot_11;
            this.pictureBox1.Location = new System.Drawing.Point(268, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 53);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Location = new System.Drawing.Point(13, 83);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(88, 36);
            this.materialFlatButton1.TabIndex = 37;
            this.materialFlatButton1.Text = "Statistics";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // materialDivider4
            // 
            this.materialDivider4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.materialDivider4.Depth = 0;
            this.materialDivider4.Location = new System.Drawing.Point(12, 128);
            this.materialDivider4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider4.Name = "materialDivider4";
            this.materialDivider4.Size = new System.Drawing.Size(336, 3);
            this.materialDivider4.TabIndex = 39;
            this.materialDivider4.Text = "materialDivider4";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(171, 205);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(161, 19);
            this.materialLabel3.TabIndex = 40;
            this.materialLabel3.Text = "CALIBRATE PROGRAM";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(295, 253);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(37, 19);
            this.materialLabel4.TabIndex = 41;
            this.materialLabel4.Text = "FAQ";
            // 
            // label_analysis
            // 
            this.label_analysis.AutoSize = true;
            this.label_analysis.BackColor = System.Drawing.Color.Transparent;
            this.label_analysis.Depth = 0;
            this.label_analysis.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_analysis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_analysis.Location = new System.Drawing.Point(207, 95);
            this.label_analysis.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_analysis.Name = "label_analysis";
            this.label_analysis.Size = new System.Drawing.Size(132, 19);
            this.label_analysis.TabIndex = 42;
            this.label_analysis.Text = "CHECK ANALYSIS";
            // 
            // label_tracking
            // 
            this.label_tracking.BackColor = System.Drawing.Color.Transparent;
            this.label_tracking.CausesValidation = false;
            this.label_tracking.Depth = 0;
            this.label_tracking.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_tracking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_tracking.Location = new System.Drawing.Point(207, 148);
            this.label_tracking.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_tracking.Name = "label_tracking";
            this.label_tracking.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_tracking.Size = new System.Drawing.Size(129, 28);
            this.label_tracking.TabIndex = 36;
            this.label_tracking.Text = "NOT TRACKING ✘";
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.BackColor = System.Drawing.Color.Transparent;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Location = new System.Drawing.Point(13, 293);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(53, 36);
            this.materialFlatButton2.TabIndex = 43;
            this.materialFlatButton2.Text = "Reset";
            this.materialFlatButton2.UseVisualStyleBackColor = false;
            this.materialFlatButton2.Click += new System.EventHandler(this.materialFlatButton2_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(203, 301);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(128, 19);
            this.materialLabel1.TabIndex = 44;
            this.materialLabel1.Text = "RESET PROGRAM";
            // 
            // debug_label
            // 
            this.debug_label.AutoSize = true;
            this.debug_label.BackColor = System.Drawing.Color.Transparent;
            this.debug_label.Depth = 0;
            this.debug_label.Font = new System.Drawing.Font("Roboto", 11F);
            this.debug_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.debug_label.Location = new System.Drawing.Point(128, 262);
            this.debug_label.MouseState = MaterialSkin.MouseState.HOVER;
            this.debug_label.Name = "debug_label";
            this.debug_label.Size = new System.Drawing.Size(37, 19);
            this.debug_label.TabIndex = 45;
            this.debug_label.Text = "FAQ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 343);
            this.Controls.Add(this.debug_label);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.label_analysis);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialDivider4);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.label_tracking);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.btn_calibrate);
            this.Controls.Add(this.btn_help);
            this.Controls.Add(this.btn_tracking);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer userLevelTimer;
        private MaterialSkin.Controls.MaterialFlatButton btn_tracking;
        private MaterialSkin.Controls.MaterialFlatButton btn_help;
        private MaterialSkin.Controls.MaterialFlatButton btn_calibrate;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialDivider materialDivider4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel label_analysis;
        public MaterialSkin.Controls.MaterialLabel label_tracking;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel debug_label;
    }
}

