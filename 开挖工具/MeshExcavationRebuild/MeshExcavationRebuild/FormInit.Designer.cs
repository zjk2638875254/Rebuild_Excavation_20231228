
namespace MeshExcavationRebuild
{
    partial class FormInit
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
            this.PanelCenter = new System.Windows.Forms.Panel();
            this.cz = new System.Windows.Forms.NumericUpDown();
            this.cy = new System.Windows.Forms.NumericUpDown();
            this.cx = new System.Windows.Forms.NumericUpDown();
            this.labelText3 = new System.Windows.Forms.Label();
            this.labelText2 = new System.Windows.Forms.Label();
            this.labelText1 = new System.Windows.Forms.Label();
            this.LockPoint = new System.Windows.Forms.Button();
            this.SendPoint = new System.Windows.Forms.Button();
            this.Point_Output = new System.Windows.Forms.Label();
            this.labelText4 = new System.Windows.Forms.Label();
            this.BaseHeight = new System.Windows.Forms.NumericUpDown();
            this.LockHeight = new System.Windows.Forms.Button();
            this.PanelHeight = new System.Windows.Forms.Panel();
            this.PanelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseHeight)).BeginInit();
            this.PanelHeight.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelCenter
            // 
            this.PanelCenter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelCenter.Controls.Add(this.cz);
            this.PanelCenter.Controls.Add(this.cy);
            this.PanelCenter.Controls.Add(this.cx);
            this.PanelCenter.Controls.Add(this.labelText3);
            this.PanelCenter.Controls.Add(this.labelText2);
            this.PanelCenter.Controls.Add(this.labelText1);
            this.PanelCenter.Location = new System.Drawing.Point(13, 13);
            this.PanelCenter.Margin = new System.Windows.Forms.Padding(4);
            this.PanelCenter.Name = "PanelCenter";
            this.PanelCenter.Size = new System.Drawing.Size(169, 94);
            this.PanelCenter.TabIndex = 0;
            // 
            // cz
            // 
            this.cz.Location = new System.Drawing.Point(34, 63);
            this.cz.Name = "cz";
            this.cz.Size = new System.Drawing.Size(120, 26);
            this.cz.TabIndex = 5;
            this.cz.ValueChanged += new System.EventHandler(this.cz_ValueChanged);
            // 
            // cy
            // 
            this.cy.Location = new System.Drawing.Point(34, 32);
            this.cy.Name = "cy";
            this.cy.Size = new System.Drawing.Size(120, 26);
            this.cy.TabIndex = 4;
            this.cy.ValueChanged += new System.EventHandler(this.cy_ValueChanged);
            // 
            // cx
            // 
            this.cx.Location = new System.Drawing.Point(34, 2);
            this.cx.Name = "cx";
            this.cx.Size = new System.Drawing.Size(120, 26);
            this.cx.TabIndex = 3;
            this.cx.ValueChanged += new System.EventHandler(this.cx_ValueChanged);
            // 
            // labelText3
            // 
            this.labelText3.AutoSize = true;
            this.labelText3.Location = new System.Drawing.Point(4, 65);
            this.labelText3.Name = "labelText3";
            this.labelText3.Size = new System.Drawing.Size(24, 16);
            this.labelText3.TabIndex = 2;
            this.labelText3.Text = "Z:";
            // 
            // labelText2
            // 
            this.labelText2.AutoSize = true;
            this.labelText2.Location = new System.Drawing.Point(4, 34);
            this.labelText2.Name = "labelText2";
            this.labelText2.Size = new System.Drawing.Size(24, 16);
            this.labelText2.TabIndex = 1;
            this.labelText2.Text = "Y:";
            // 
            // labelText1
            // 
            this.labelText1.AutoSize = true;
            this.labelText1.Location = new System.Drawing.Point(4, 4);
            this.labelText1.Name = "labelText1";
            this.labelText1.Size = new System.Drawing.Size(24, 16);
            this.labelText1.TabIndex = 0;
            this.labelText1.Text = "X:";
            // 
            // LockPoint
            // 
            this.LockPoint.Location = new System.Drawing.Point(13, 115);
            this.LockPoint.Name = "LockPoint";
            this.LockPoint.Size = new System.Drawing.Size(169, 30);
            this.LockPoint.TabIndex = 1;
            this.LockPoint.Text = "锁定锚点";
            this.LockPoint.UseVisualStyleBackColor = true;
            this.LockPoint.Click += new System.EventHandler(this.LockPoint_Click);
            // 
            // SendPoint
            // 
            this.SendPoint.Location = new System.Drawing.Point(13, 151);
            this.SendPoint.Name = "SendPoint";
            this.SendPoint.Size = new System.Drawing.Size(169, 30);
            this.SendPoint.TabIndex = 2;
            this.SendPoint.Text = "确认锚点";
            this.SendPoint.UseVisualStyleBackColor = true;
            this.SendPoint.Click += new System.EventHandler(this.SendPoint_Click);
            // 
            // Point_Output
            // 
            this.Point_Output.AutoSize = true;
            this.Point_Output.Location = new System.Drawing.Point(189, 13);
            this.Point_Output.Name = "Point_Output";
            this.Point_Output.Size = new System.Drawing.Size(144, 16);
            this.Point_Output.TabIndex = 3;
            this.Point_Output.Text = "当前状况：Default";
            // 
            // labelText4
            // 
            this.labelText4.AutoSize = true;
            this.labelText4.Location = new System.Drawing.Point(3, 8);
            this.labelText4.Name = "labelText4";
            this.labelText4.Size = new System.Drawing.Size(72, 16);
            this.labelText4.TabIndex = 4;
            this.labelText4.Text = "高程/米:";
            // 
            // BaseHeight
            // 
            this.BaseHeight.DecimalPlaces = 2;
            this.BaseHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.BaseHeight.Location = new System.Drawing.Point(81, 6);
            this.BaseHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.BaseHeight.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.BaseHeight.Name = "BaseHeight";
            this.BaseHeight.Size = new System.Drawing.Size(120, 26);
            this.BaseHeight.TabIndex = 5;
            // 
            // LockHeight
            // 
            this.LockHeight.Location = new System.Drawing.Point(3, 38);
            this.LockHeight.Name = "LockHeight";
            this.LockHeight.Size = new System.Drawing.Size(198, 30);
            this.LockHeight.TabIndex = 6;
            this.LockHeight.Text = "设置底面高程";
            this.LockHeight.UseVisualStyleBackColor = true;
            this.LockHeight.Click += new System.EventHandler(this.LockHeight_Click);
            // 
            // PanelHeight
            // 
            this.PanelHeight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelHeight.Controls.Add(this.labelText4);
            this.PanelHeight.Controls.Add(this.LockHeight);
            this.PanelHeight.Controls.Add(this.BaseHeight);
            this.PanelHeight.Location = new System.Drawing.Point(192, 102);
            this.PanelHeight.Name = "PanelHeight";
            this.PanelHeight.Size = new System.Drawing.Size(206, 79);
            this.PanelHeight.TabIndex = 7;
            // 
            // FormInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 191);
            this.Controls.Add(this.PanelHeight);
            this.Controls.Add(this.Point_Output);
            this.Controls.Add(this.SendPoint);
            this.Controls.Add(this.LockPoint);
            this.Controls.Add(this.PanelCenter);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormInit";
            this.Text = "初始化-参数设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Input_Load);
            this.PanelCenter.ResumeLayout(false);
            this.PanelCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaseHeight)).EndInit();
            this.PanelHeight.ResumeLayout(false);
            this.PanelHeight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelCenter;
        private System.Windows.Forms.NumericUpDown cz;
        private System.Windows.Forms.NumericUpDown cy;
        private System.Windows.Forms.NumericUpDown cx;
        private System.Windows.Forms.Label labelText3;
        private System.Windows.Forms.Label labelText2;
        private System.Windows.Forms.Label labelText1;
        private System.Windows.Forms.Button LockPoint;
        private System.Windows.Forms.Button SendPoint;
        private System.Windows.Forms.Label Point_Output;
        private System.Windows.Forms.Label labelText4;
        private System.Windows.Forms.NumericUpDown BaseHeight;
        private System.Windows.Forms.Button LockHeight;
        private System.Windows.Forms.Panel PanelHeight;
    }
}