namespace HookFromV2
{
    partial class Graphs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graphs));
            this.chart1 = new LiveCharts.WinForms.CartesianChart();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.label_workTime = new MaterialSkin.Controls.MaterialLabel();
            this.button_filter = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.label_name = new MaterialSkin.Controls.MaterialLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.label_date = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialCheckBox1 = new MaterialSkin.Controls.MaterialCheckBox();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Location = new System.Drawing.Point(12, 47);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(611, 253);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 320);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(190, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "You have been working for:";
            // 
            // label_workTime
            // 
            this.label_workTime.AutoSize = true;
            this.label_workTime.BackColor = System.Drawing.Color.Transparent;
            this.label_workTime.Depth = 0;
            this.label_workTime.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_workTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_workTime.Location = new System.Drawing.Point(208, 320);
            this.label_workTime.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_workTime.Name = "label_workTime";
            this.label_workTime.Size = new System.Drawing.Size(74, 19);
            this.label_workTime.TabIndex = 4;
            this.label_workTime.Text = "Loading...";
            // 
            // button_filter
            // 
            this.button_filter.AutoSize = true;
            this.button_filter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_filter.BackColor = System.Drawing.Color.DimGray;
            this.button_filter.Depth = 0;
            this.button_filter.Location = new System.Drawing.Point(640, 253);
            this.button_filter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button_filter.MouseState = MaterialSkin.MouseState.HOVER;
            this.button_filter.Name = "button_filter";
            this.button_filter.Primary = false;
            this.button_filter.Size = new System.Drawing.Size(55, 36);
            this.button_filter.TabIndex = 7;
            this.button_filter.Text = "Filter";
            this.button_filter.UseVisualStyleBackColor = false;
            this.button_filter.Click += new System.EventHandler(this.button_filter_Click);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(640, 282);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(55, 3);
            this.materialDivider1.TabIndex = 8;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Depth = 0;
            this.label_name.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_name.Location = new System.Drawing.Point(12, 25);
            this.label_name.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(74, 19);
            this.label_name.TabIndex = 9;
            this.label_name.Text = "Loading...";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Mistakes Count",
            "Optimal typing speed",
            "Typing Speed",
            "Time it takes to fix mistakes"});
            this.comboBox1.Location = new System.Drawing.Point(683, 78);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(629, 117);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(44, 19);
            this.materialLabel3.TabIndex = 11;
            this.materialLabel3.Text = "Date:";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Depth = 0;
            this.label_date.Font = new System.Drawing.Font("Roboto", 11F);
            this.label_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_date.Location = new System.Drawing.Point(679, 117);
            this.label_date.MouseState = MaterialSkin.MouseState.HOVER;
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(16, 19);
            this.label_date.TabIndex = 12;
            this.label_date.Text = "_";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(628, 80);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(45, 19);
            this.materialLabel4.TabIndex = 13;
            this.materialLabel4.Text = "Type:";
            // 
            // materialCheckBox1
            // 
            this.materialCheckBox1.AutoSize = true;
            this.materialCheckBox1.Checked = true;
            this.materialCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.materialCheckBox1.Depth = 0;
            this.materialCheckBox1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox1.Location = new System.Drawing.Point(626, 173);
            this.materialCheckBox1.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox1.Name = "materialCheckBox1";
            this.materialCheckBox1.Ripple = true;
            this.materialCheckBox1.Size = new System.Drawing.Size(207, 30);
            this.materialCheckBox1.TabIndex = 14;
            this.materialCheckBox1.Text = "Acccount for mistakes count";
            this.materialCheckBox1.UseVisualStyleBackColor = true;
            this.materialCheckBox1.CheckedChanged += new System.EventHandler(this.materialCheckBox1_CheckedChanged);
            // 
            // Graphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1021, 427);
            this.Controls.Add(this.materialCheckBox1);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.button_filter);
            this.Controls.Add(this.label_workTime);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Graphs";
            this.Text = "Graphs";
            this.Load += new System.EventHandler(this.Graphs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart chart1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel label_workTime;
        private MaterialSkin.Controls.MaterialFlatButton button_filter;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialLabel label_name;
        private System.Windows.Forms.ComboBox comboBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel label_date;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox1;
    }
}