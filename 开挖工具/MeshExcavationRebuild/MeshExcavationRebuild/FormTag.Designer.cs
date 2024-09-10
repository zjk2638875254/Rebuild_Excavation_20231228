
namespace MeshExcavationRebuild
{
    partial class FormTag
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.EcValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EcName = new System.Windows.Forms.ComboBox();
            this.AddProperty = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OutputPoints = new System.Windows.Forms.Button();
            this.TagPoints = new System.Windows.Forms.Button();
            this.TagHeight = new System.Windows.Forms.Button();
            this.TagPobi = new System.Windows.Forms.Button();
            this.StyleFont = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.PlaceExcel = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.EcValue);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.EcName);
            this.panel3.Controls.Add(this.AddProperty);
            this.panel3.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel3.Location = new System.Drawing.Point(16, 345);
            this.panel3.Margin = new System.Windows.Forms.Padding(7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(201, 154);
            this.panel3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "内容";
            // 
            // EcValue
            // 
            this.EcValue.Location = new System.Drawing.Point(9, 62);
            this.EcValue.Margin = new System.Windows.Forms.Padding(4);
            this.EcValue.Name = "EcValue";
            this.EcValue.Size = new System.Drawing.Size(128, 28);
            this.EcValue.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "名称";
            // 
            // EcName
            // 
            this.EcName.FormattingEnabled = true;
            this.EcName.Location = new System.Drawing.Point(9, 21);
            this.EcName.Margin = new System.Windows.Forms.Padding(4);
            this.EcName.Name = "EcName";
            this.EcName.Size = new System.Drawing.Size(128, 26);
            this.EcName.TabIndex = 5;
            // 
            // AddProperty
            // 
            this.AddProperty.Location = new System.Drawing.Point(7, 101);
            this.AddProperty.Margin = new System.Windows.Forms.Padding(7);
            this.AddProperty.Name = "AddProperty";
            this.AddProperty.Size = new System.Drawing.Size(184, 40);
            this.AddProperty.TabIndex = 4;
            this.AddProperty.Text = "添加属性";
            this.AddProperty.UseVisualStyleBackColor = true;
            this.AddProperty.Click += new System.EventHandler(this.AddProperty_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.PlaceExcel);
            this.panel2.Controls.Add(this.OutputPoints);
            this.panel2.Controls.Add(this.TagPoints);
            this.panel2.Controls.Add(this.TagHeight);
            this.panel2.Controls.Add(this.TagPobi);
            this.panel2.Font = new System.Drawing.Font("华文仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(16, 54);
            this.panel2.Margin = new System.Windows.Forms.Padding(7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(201, 277);
            this.panel2.TabIndex = 6;
            // 
            // OutputPoints
            // 
            this.OutputPoints.Location = new System.Drawing.Point(9, 169);
            this.OutputPoints.Margin = new System.Windows.Forms.Padding(7);
            this.OutputPoints.Name = "OutputPoints";
            this.OutputPoints.Size = new System.Drawing.Size(182, 40);
            this.OutputPoints.TabIndex = 3;
            this.OutputPoints.Text = "输出控制点";
            this.OutputPoints.UseVisualStyleBackColor = true;
            this.OutputPoints.Click += new System.EventHandler(this.OutputPoints_Click);
            // 
            // TagPoints
            // 
            this.TagPoints.Location = new System.Drawing.Point(9, 115);
            this.TagPoints.Margin = new System.Windows.Forms.Padding(7);
            this.TagPoints.Name = "TagPoints";
            this.TagPoints.Size = new System.Drawing.Size(182, 40);
            this.TagPoints.TabIndex = 2;
            this.TagPoints.Text = "标注控制点";
            this.TagPoints.UseVisualStyleBackColor = true;
            this.TagPoints.Click += new System.EventHandler(this.TagPoints_Click);
            // 
            // TagHeight
            // 
            this.TagHeight.Location = new System.Drawing.Point(9, 61);
            this.TagHeight.Margin = new System.Windows.Forms.Padding(7);
            this.TagHeight.Name = "TagHeight";
            this.TagHeight.Size = new System.Drawing.Size(182, 40);
            this.TagHeight.TabIndex = 1;
            this.TagHeight.Text = "标注高程";
            this.TagHeight.UseVisualStyleBackColor = true;
            this.TagHeight.Click += new System.EventHandler(this.TagHeight_Click);
            // 
            // TagPobi
            // 
            this.TagPobi.Location = new System.Drawing.Point(9, 7);
            this.TagPobi.Margin = new System.Windows.Forms.Padding(7);
            this.TagPobi.Name = "TagPobi";
            this.TagPobi.Size = new System.Drawing.Size(182, 40);
            this.TagPobi.TabIndex = 0;
            this.TagPobi.Text = "标注坡比";
            this.TagPobi.UseVisualStyleBackColor = true;
            this.TagPobi.Click += new System.EventHandler(this.button2_Click);
            // 
            // StyleFont
            // 
            this.StyleFont.FormattingEnabled = true;
            this.StyleFont.Location = new System.Drawing.Point(16, 16);
            this.StyleFont.Margin = new System.Windows.Forms.Padding(7);
            this.StyleFont.Name = "StyleFont";
            this.StyleFont.Size = new System.Drawing.Size(150, 24);
            this.StyleFont.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "格式";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 526);
            this.button1.Margin = new System.Windows.Forms.Padding(7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "T1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(91, 526);
            this.button2.Margin = new System.Windows.Forms.Padding(7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 40);
            this.button2.TabIndex = 8;
            this.button2.Text = "T2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(159, 526);
            this.button3.Margin = new System.Windows.Forms.Padding(7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 40);
            this.button3.TabIndex = 9;
            this.button3.Text = "T3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PlaceExcel
            // 
            this.PlaceExcel.Location = new System.Drawing.Point(9, 223);
            this.PlaceExcel.Margin = new System.Windows.Forms.Padding(7);
            this.PlaceExcel.Name = "PlaceExcel";
            this.PlaceExcel.Size = new System.Drawing.Size(182, 40);
            this.PlaceExcel.TabIndex = 4;
            this.PlaceExcel.Text = "放置坐标表";
            this.PlaceExcel.UseVisualStyleBackColor = true;
            this.PlaceExcel.Click += new System.EventHandler(this.PlaceExcel_Click);
            // 
            // FormTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 512);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.StyleFont);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTag";
            this.Text = "标注界面";
            this.Load += new System.EventHandler(this.Form_Tag_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EcValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox EcName;
        private System.Windows.Forms.Button AddProperty;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button OutputPoints;
        private System.Windows.Forms.Button TagPoints;
        private System.Windows.Forms.Button TagHeight;
        private System.Windows.Forms.Button TagPobi;
        private System.Windows.Forms.ComboBox StyleFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button PlaceExcel;
    }
}