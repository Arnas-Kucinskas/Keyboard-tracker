namespace HookFromV2
{
    partial class MainAnalysisForm
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabMistakes = new System.Windows.Forms.TabPage();
            this.tabHeatMap = new System.Windows.Forms.TabPage();
            this.tabSpeed = new System.Windows.Forms.TabPage();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabMistakes);
            this.tabMain.Controls.Add(this.tabHeatMap);
            this.tabMain.Controls.Add(this.tabSpeed);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(854, 388);
            this.tabMain.TabIndex = 0;
            // 
            // tabMistakes
            // 
            this.tabMistakes.Location = new System.Drawing.Point(4, 22);
            this.tabMistakes.Name = "tabMistakes";
            this.tabMistakes.Padding = new System.Windows.Forms.Padding(3);
            this.tabMistakes.Size = new System.Drawing.Size(846, 362);
            this.tabMistakes.TabIndex = 0;
            this.tabMistakes.Text = "Mistakes";
            this.tabMistakes.UseVisualStyleBackColor = true;
        
            // 
            // tabHeatMap
            // 
            this.tabHeatMap.Location = new System.Drawing.Point(4, 22);
            this.tabHeatMap.Name = "tabHeatMap";
            this.tabHeatMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabHeatMap.Size = new System.Drawing.Size(846, 362);
            this.tabHeatMap.TabIndex = 1;
            this.tabHeatMap.Text = "HeatMap";
            this.tabHeatMap.UseVisualStyleBackColor = true;
          
            // 
            // tabSpeed
            // 
            this.tabSpeed.Location = new System.Drawing.Point(4, 22);
            this.tabSpeed.Name = "tabSpeed";
            this.tabSpeed.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpeed.Size = new System.Drawing.Size(846, 362);
            this.tabSpeed.TabIndex = 2;
            this.tabSpeed.Text = "Line graphs";
            this.tabSpeed.UseVisualStyleBackColor = true;
            // 
            // MainAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 389);
            this.Controls.Add(this.tabMain);
            this.IsMdiContainer = true;
            this.Name = "MainAnalysisForm";
            this.Text = "MainAnalysisForm";
            this.Load += new System.EventHandler(this.MainAnalysisForm_Load);
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabMistakes;
        private System.Windows.Forms.TabPage tabHeatMap;
        private System.Windows.Forms.TabPage tabSpeed;
    }
}