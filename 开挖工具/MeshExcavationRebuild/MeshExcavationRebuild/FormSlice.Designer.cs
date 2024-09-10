
namespace MeshExcavationRebuild
{
    partial class FormSlice
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
            this.labelText1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HeightMeter = new System.Windows.Forms.NumericUpDown();
            this.WidthMeter = new System.Windows.Forms.NumericUpDown();
            this.CreateMesh = new System.Windows.Forms.Button();
            this.GetLine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HeightMeter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthMeter)).BeginInit();
            this.SuspendLayout();
            // 
            // labelText1
            // 
            this.labelText1.AutoSize = true;
            this.labelText1.Location = new System.Drawing.Point(13, 9);
            this.labelText1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText1.Name = "labelText1";
            this.labelText1.Size = new System.Drawing.Size(112, 16);
            this.labelText1.TabIndex = 0;
            this.labelText1.Text = "提取区高度/米";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "提取区宽度/米";
            // 
            // HeightMeter
            // 
            this.HeightMeter.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.HeightMeter.Location = new System.Drawing.Point(132, 7);
            this.HeightMeter.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.HeightMeter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HeightMeter.Name = "HeightMeter";
            this.HeightMeter.Size = new System.Drawing.Size(120, 26);
            this.HeightMeter.TabIndex = 2;
            this.HeightMeter.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // WidthMeter
            // 
            this.WidthMeter.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.WidthMeter.Location = new System.Drawing.Point(132, 47);
            this.WidthMeter.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.WidthMeter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthMeter.Name = "WidthMeter";
            this.WidthMeter.Size = new System.Drawing.Size(120, 26);
            this.WidthMeter.TabIndex = 3;
            this.WidthMeter.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // CreateMesh
            // 
            this.CreateMesh.Location = new System.Drawing.Point(12, 79);
            this.CreateMesh.Name = "CreateMesh";
            this.CreateMesh.Size = new System.Drawing.Size(240, 30);
            this.CreateMesh.TabIndex = 4;
            this.CreateMesh.Text = "三维剪切";
            this.CreateMesh.UseVisualStyleBackColor = true;
            this.CreateMesh.Click += new System.EventHandler(this.CreateMesh_Click);
            // 
            // GetLine
            // 
            this.GetLine.Location = new System.Drawing.Point(11, 115);
            this.GetLine.Name = "GetLine";
            this.GetLine.Size = new System.Drawing.Size(240, 30);
            this.GetLine.TabIndex = 5;
            this.GetLine.Text = "提取剖面线";
            this.GetLine.UseVisualStyleBackColor = true;
            this.GetLine.Click += new System.EventHandler(this.GetLine_Click);
            // 
            // FormSlice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 154);
            this.Controls.Add(this.GetLine);
            this.Controls.Add(this.CreateMesh);
            this.Controls.Add(this.WidthMeter);
            this.Controls.Add(this.HeightMeter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelText1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormSlice";
            this.Text = "提取剖面线";
            this.Load += new System.EventHandler(this.FormSlice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeightMeter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthMeter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelText1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown HeightMeter;
        private System.Windows.Forms.NumericUpDown WidthMeter;
        private System.Windows.Forms.Button CreateMesh;
        private System.Windows.Forms.Button GetLine;
    }
}