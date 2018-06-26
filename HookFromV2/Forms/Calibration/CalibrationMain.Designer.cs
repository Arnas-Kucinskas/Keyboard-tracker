namespace HookFromV2
{
    partial class CalibrationMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationMain));
            this.btn_test = new MaterialSkin.Controls.MaterialFlatButton();
            this.btn_auto = new MaterialSkin.Controls.MaterialFlatButton();
            this.btn_manual = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.materialDivider3 = new MaterialSkin.Controls.MaterialDivider();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.label_userLevel = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // btn_test
            // 
            this.btn_test.AutoSize = true;
            this.btn_test.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_test.Depth = 0;
            this.btn_test.Location = new System.Drawing.Point(95, 162);
            this.btn_test.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_test.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_test.Name = "btn_test";
            this.btn_test.Primary = false;
            this.btn_test.Size = new System.Drawing.Size(135, 36);
            this.btn_test.TabIndex = 0;
            this.btn_test.Text = "Calibration test";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // btn_auto
            // 
            this.btn_auto.AutoSize = true;
            this.btn_auto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_auto.Depth = 0;
            this.btn_auto.Location = new System.Drawing.Point(13, 114);
            this.btn_auto.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_auto.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_auto.Name = "btn_auto";
            this.btn_auto.Primary = false;
            this.btn_auto.Size = new System.Drawing.Size(293, 36);
            this.btn_auto.TabIndex = 1;
            this.btn_auto.Text = "Automatic calibration(Recommended)";
            this.btn_auto.UseVisualStyleBackColor = true;
            this.btn_auto.Click += new System.EventHandler(this.btn_auto_Click);
            // 
            // btn_manual
            // 
            this.btn_manual.AutoSize = true;
            this.btn_manual.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_manual.Depth = 0;
            this.btn_manual.Location = new System.Drawing.Point(84, 210);
            this.btn_manual.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_manual.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_manual.Name = "btn_manual";
            this.btn_manual.Primary = false;
            this.btn_manual.Size = new System.Drawing.Size(159, 36);
            this.btn_manual.TabIndex = 2;
            this.btn_manual.Text = "Manual calibration";
            this.btn_manual.UseVisualStyleBackColor = true;
            this.btn_manual.Click += new System.EventHandler(this.btn_manual_Click);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.SystemColors.Highlight;
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(95, 195);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(135, 3);
            this.materialDivider1.TabIndex = 3;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.SystemColors.Highlight;
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(13, 147);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(293, 3);
            this.materialDivider2.TabIndex = 4;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // materialDivider3
            // 
            this.materialDivider3.BackColor = System.Drawing.SystemColors.Highlight;
            this.materialDivider3.Depth = 0;
            this.materialDivider3.Location = new System.Drawing.Point(84, 243);
            this.materialDivider3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider3.Name = "materialDivider3";
            this.materialDivider3.Size = new System.Drawing.Size(159, 3);
            this.materialDivider3.TabIndex = 5;
            this.materialDivider3.Text = "materialDivider3";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 72);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(125, 19);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Curent user level:";
            // 
            // label_userLevel
            // 
            this.label_userLevel.AutoSize = true;
            this.label_userLevel.BackColor = System.Drawing.Color.Transparent;
            this.label_userLevel.Depth = 0;
            this.label_userLevel.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_userLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_userLevel.Location = new System.Drawing.Point(159, 72);
            this.label_userLevel.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_userLevel.Name = "label_userLevel";
            this.label_userLevel.Size = new System.Drawing.Size(16, 19);
            this.label_userLevel.TabIndex = 7;
            this.label_userLevel.Text = "_";
            // 
            // CalibrationMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 279);
            this.Controls.Add(this.label_userLevel);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialDivider3);
            this.Controls.Add(this.materialDivider2);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.btn_manual);
            this.Controls.Add(this.btn_auto);
            this.Controls.Add(this.btn_test);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CalibrationMain";
            this.Text = "Calibration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalibrationMain_FormClosing);
            this.Load += new System.EventHandler(this.CalibrationMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton btn_test;
        private MaterialSkin.Controls.MaterialFlatButton btn_auto;
        private MaterialSkin.Controls.MaterialFlatButton btn_manual;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private MaterialSkin.Controls.MaterialDivider materialDivider3;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel label_userLevel;
    }
}