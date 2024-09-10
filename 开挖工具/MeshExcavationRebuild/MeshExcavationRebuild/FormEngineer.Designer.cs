
namespace MeshExcavationRebuild
{
    partial class FormEngineer
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
            this.ExportMessage = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.FeRadius = new System.Windows.Forms.ComboBox();
            this.CountFe = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.FeLen = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CountSoil = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Soil = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CountZH = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Len = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Local = new System.Windows.Forms.NumericUpDown();
            this.Partition = new System.Windows.Forms.Button();
            this.ExcavationExport = new System.Windows.Forms.Button();
            this.SetMessage = new System.Windows.Forms.Button();
            this.ExcavationSet = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FeLen)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Soil)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Len)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Local)).BeginInit();
            this.SuspendLayout();
            // 
            // ExportMessage
            // 
            this.ExportMessage.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExportMessage.Location = new System.Drawing.Point(16, 458);
            this.ExportMessage.Margin = new System.Windows.Forms.Padding(4);
            this.ExportMessage.Name = "ExportMessage";
            this.ExportMessage.Size = new System.Drawing.Size(135, 30);
            this.ExportMessage.TabIndex = 24;
            this.ExportMessage.Text = "支护信息导出";
            this.ExportMessage.UseVisualStyleBackColor = true;
            this.ExportMessage.Click += new System.EventHandler(this.ExportMessage_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.FeRadius);
            this.panel3.Controls.Add(this.CountFe);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.FeLen);
            this.panel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel3.Location = new System.Drawing.Point(16, 301);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(288, 149);
            this.panel3.TabIndex = 26;
            // 
            // FeRadius
            // 
            this.FeRadius.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FeRadius.FormattingEnabled = true;
            this.FeRadius.Location = new System.Drawing.Point(4, 71);
            this.FeRadius.Margin = new System.Windows.Forms.Padding(4);
            this.FeRadius.Name = "FeRadius";
            this.FeRadius.Size = new System.Drawing.Size(160, 26);
            this.FeRadius.TabIndex = 13;
            // 
            // CountFe
            // 
            this.CountFe.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CountFe.Location = new System.Drawing.Point(4, 105);
            this.CountFe.Margin = new System.Windows.Forms.Padding(4);
            this.CountFe.Name = "CountFe";
            this.CountFe.Size = new System.Drawing.Size(274, 30);
            this.CountFe.TabIndex = 7;
            this.CountFe.Text = "计算钢筋量";
            this.CountFe.UseVisualStyleBackColor = true;
            this.CountFe.Click += new System.EventHandler(this.CountFe_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("华文仿宋", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(92, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "钢筋网计算";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(172, 74);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "钢筋直径(mm)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(168, 37);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 18);
            this.label9.TabIndex = 7;
            this.label9.Text = "钢筋间排距(m)";
            // 
            // FeLen
            // 
            this.FeLen.DecimalPlaces = 3;
            this.FeLen.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FeLen.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.FeLen.Location = new System.Drawing.Point(4, 35);
            this.FeLen.Margin = new System.Windows.Forms.Padding(4);
            this.FeLen.Name = "FeLen";
            this.FeLen.Size = new System.Drawing.Size(129, 28);
            this.FeLen.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.CountSoil);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.Soil);
            this.panel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(16, 173);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 120);
            this.panel2.TabIndex = 25;
            // 
            // CountSoil
            // 
            this.CountSoil.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CountSoil.Location = new System.Drawing.Point(4, 73);
            this.CountSoil.Margin = new System.Windows.Forms.Padding(4);
            this.CountSoil.Name = "CountSoil";
            this.CountSoil.Size = new System.Drawing.Size(274, 30);
            this.CountSoil.TabIndex = 7;
            this.CountSoil.Text = "计算喷混量";
            this.CountSoil.UseVisualStyleBackColor = true;
            this.CountSoil.Click += new System.EventHandler(this.CountSoil_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("华文仿宋", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(92, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "喷混量计算";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(161, 39);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 18);
            this.label7.TabIndex = 7;
            this.label7.Text = "混凝土厚度(cm)";
            // 
            // Soil
            // 
            this.Soil.DecimalPlaces = 3;
            this.Soil.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Soil.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Soil.Location = new System.Drawing.Point(4, 37);
            this.Soil.Margin = new System.Windows.Forms.Padding(4);
            this.Soil.Name = "Soil";
            this.Soil.Size = new System.Drawing.Size(129, 28);
            this.Soil.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.CountZH);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Len);
            this.panel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(16, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 113);
            this.panel1.TabIndex = 23;
            // 
            // CountZH
            // 
            this.CountZH.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CountZH.Location = new System.Drawing.Point(4, 70);
            this.CountZH.Margin = new System.Windows.Forms.Padding(4);
            this.CountZH.Name = "CountZH";
            this.CountZH.Size = new System.Drawing.Size(274, 30);
            this.CountZH.TabIndex = 7;
            this.CountZH.Text = "计算支护量";
            this.CountZH.UseVisualStyleBackColor = true;
            this.CountZH.Click += new System.EventHandler(this.CountZH_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("华文仿宋", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(92, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "锚杆量计算";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(152, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "横向拉筋间距(m)";
            // 
            // Len
            // 
            this.Len.DecimalPlaces = 3;
            this.Len.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Len.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Len.Location = new System.Drawing.Point(4, 34);
            this.Len.Margin = new System.Windows.Forms.Padding(4);
            this.Len.Name = "Len";
            this.Len.Size = new System.Drawing.Size(129, 28);
            this.Len.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(91, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "区号(1-99)";
            // 
            // Local
            // 
            this.Local.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Local.Location = new System.Drawing.Point(16, 16);
            this.Local.Margin = new System.Windows.Forms.Padding(4);
            this.Local.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.Local.Name = "Local";
            this.Local.Size = new System.Drawing.Size(67, 28);
            this.Local.TabIndex = 21;
            // 
            // Partition
            // 
            this.Partition.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Partition.Location = new System.Drawing.Point(182, 11);
            this.Partition.Margin = new System.Windows.Forms.Padding(4);
            this.Partition.Name = "Partition";
            this.Partition.Size = new System.Drawing.Size(122, 30);
            this.Partition.TabIndex = 20;
            this.Partition.Text = "划分支护区";
            this.Partition.UseVisualStyleBackColor = true;
            this.Partition.Click += new System.EventHandler(this.Partition_Click);
            // 
            // ExcavationExport
            // 
            this.ExcavationExport.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExcavationExport.Location = new System.Drawing.Point(16, 496);
            this.ExcavationExport.Margin = new System.Windows.Forms.Padding(4);
            this.ExcavationExport.Name = "ExcavationExport";
            this.ExcavationExport.Size = new System.Drawing.Size(135, 30);
            this.ExcavationExport.TabIndex = 27;
            this.ExcavationExport.Text = "开挖信息导出";
            this.ExcavationExport.UseVisualStyleBackColor = true;
            this.ExcavationExport.Click += new System.EventHandler(this.ExcavationExport_Click);
            // 
            // SetMessage
            // 
            this.SetMessage.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetMessage.Location = new System.Drawing.Point(169, 458);
            this.SetMessage.Margin = new System.Windows.Forms.Padding(4);
            this.SetMessage.Name = "SetMessage";
            this.SetMessage.Size = new System.Drawing.Size(135, 30);
            this.SetMessage.TabIndex = 28;
            this.SetMessage.Text = "支护信息放置";
            this.SetMessage.UseVisualStyleBackColor = true;
            this.SetMessage.Click += new System.EventHandler(this.SetMessage_Click);
            // 
            // ExcavationSet
            // 
            this.ExcavationSet.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExcavationSet.Location = new System.Drawing.Point(169, 496);
            this.ExcavationSet.Margin = new System.Windows.Forms.Padding(4);
            this.ExcavationSet.Name = "ExcavationSet";
            this.ExcavationSet.Size = new System.Drawing.Size(135, 30);
            this.ExcavationSet.TabIndex = 29;
            this.ExcavationSet.Text = "开挖信息放置";
            this.ExcavationSet.UseVisualStyleBackColor = true;
            this.ExcavationSet.Click += new System.EventHandler(this.ExcavationSet_Click);
            // 
            // FormEngineer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 532);
            this.Controls.Add(this.ExcavationSet);
            this.Controls.Add(this.SetMessage);
            this.Controls.Add(this.ExcavationExport);
            this.Controls.Add(this.ExportMessage);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Local);
            this.Controls.Add(this.Partition);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEngineer";
            this.Text = "支护量计算";
            this.Load += new System.EventHandler(this.Form_Engineer_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FeLen)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Soil)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Len)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Local)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExportMessage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox FeRadius;
        private System.Windows.Forms.Button CountFe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown FeLen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button CountSoil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Soil;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CountZH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Len;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Local;
        private System.Windows.Forms.Button Partition;
        private System.Windows.Forms.Button ExcavationExport;
        private System.Windows.Forms.Button SetMessage;
        private System.Windows.Forms.Button ExcavationSet;
    }
}