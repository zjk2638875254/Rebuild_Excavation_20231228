namespace MeshExcavation
{
	// Token: 0x02000003 RID: 3
	public partial class Form_EightView : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002978 File Offset: 0x00000B78
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000029B0 File Offset: 0x00000BB0
		private void InitializeComponent()
		{
			this.CreateSection = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label13 = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label15 = new global::System.Windows.Forms.Label();
			this.label16 = new global::System.Windows.Forms.Label();
			this.P4Z = new global::System.Windows.Forms.NumericUpDown();
			this.P4Y = new global::System.Windows.Forms.NumericUpDown();
			this.P4X = new global::System.Windows.Forms.NumericUpDown();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.P3Z = new global::System.Windows.Forms.NumericUpDown();
			this.P3Y = new global::System.Windows.Forms.NumericUpDown();
			this.P3X = new global::System.Windows.Forms.NumericUpDown();
			this.label5 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.P2Z = new global::System.Windows.Forms.NumericUpDown();
			this.P2Y = new global::System.Windows.Forms.NumericUpDown();
			this.P2X = new global::System.Windows.Forms.NumericUpDown();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.P1Z = new global::System.Windows.Forms.NumericUpDown();
			this.P1Y = new global::System.Windows.Forms.NumericUpDown();
			this.P1X = new global::System.Windows.Forms.NumericUpDown();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.P4Z).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.P4Y).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.P4X).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.P3Z).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.P3Y).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.P3X).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.P2Z).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.P2Y).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.P2X).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.P1Z).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.P1Y).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.P1X).BeginInit();
			base.SuspendLayout();
			this.CreateSection.Font = new global::System.Drawing.Font("宋体", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.CreateSection.Location = new global::System.Drawing.Point(255, 179);
			this.CreateSection.Name = "CreateSection";
			this.CreateSection.Size = new global::System.Drawing.Size(134, 36);
			this.CreateSection.TabIndex = 3;
			this.CreateSection.Text = "构造剖面";
			this.CreateSection.UseVisualStyleBackColor = true;
			this.CreateSection.Click += new global::System.EventHandler(this.CreateSection_Click);
			this.panel1.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.label13);
			this.panel1.Controls.Add(this.label14);
			this.panel1.Controls.Add(this.label15);
			this.panel1.Controls.Add(this.label16);
			this.panel1.Controls.Add(this.P4Z);
			this.panel1.Controls.Add(this.P4Y);
			this.panel1.Controls.Add(this.P4X);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.label12);
			this.panel1.Controls.Add(this.P3Z);
			this.panel1.Controls.Add(this.P3Y);
			this.panel1.Controls.Add(this.P3X);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.P2Z);
			this.panel1.Controls.Add(this.P2Y);
			this.panel1.Controls.Add(this.P2X);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.P1Z);
			this.panel1.Controls.Add(this.P1Y);
			this.panel1.Controls.Add(this.P1X);
			this.panel1.Location = new global::System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(628, 180);
			this.panel1.TabIndex = 2;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label13.Location = new global::System.Drawing.Point(464, 129);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(26, 21);
			this.label13.TabIndex = 27;
			this.label13.Text = "Z:";
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label14.Location = new global::System.Drawing.Point(307, 129);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(26, 21);
			this.label14.TabIndex = 26;
			this.label14.Text = "Y:";
			this.label15.AutoSize = true;
			this.label15.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label15.Location = new global::System.Drawing.Point(150, 129);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(27, 21);
			this.label15.TabIndex = 25;
			this.label15.Text = "X:";
			this.label16.AutoSize = true;
			this.label16.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label16.Location = new global::System.Drawing.Point(4, 129);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(152, 21);
			this.label16.TabIndex = 24;
			this.label16.Text = "截面顶点4（米）";
			this.P4Z.DecimalPlaces = 3;
			this.P4Z.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.P4Z.Location = new global::System.Drawing.Point(495, 127);
			global::System.Windows.Forms.NumericUpDown p4Z = this.P4Z;
			int[] array = new int[4];
			array[0] = 20000000;
			p4Z.Maximum = new decimal(array);
			this.P4Z.Minimum = new decimal(new int[]
			{
				20000000,
				0,
				0,
				int.MinValue
			});
			this.P4Z.Name = "P4Z";
			this.P4Z.Size = new global::System.Drawing.Size(120, 32);
			this.P4Z.TabIndex = 23;
			this.P4Y.DecimalPlaces = 3;
			this.P4Y.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.P4Y.Location = new global::System.Drawing.Point(337, 127);
			global::System.Windows.Forms.NumericUpDown p4Y = this.P4Y;
			int[] array2 = new int[4];
			array2[0] = 100000000;
			p4Y.Maximum = new decimal(array2);
			this.P4Y.Minimum = new decimal(new int[]
			{
				100000000,
				0,
				0,
				int.MinValue
			});
			this.P4Y.Name = "P4Y";
			this.P4Y.Size = new global::System.Drawing.Size(120, 32);
			this.P4Y.TabIndex = 22;
			this.P4X.DecimalPlaces = 3;
			this.P4X.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.P4X.Location = new global::System.Drawing.Point(181, 127);
			global::System.Windows.Forms.NumericUpDown p4X = this.P4X;
			int[] array3 = new int[4];
			array3[0] = 2000000;
			p4X.Maximum = new decimal(array3);
			this.P4X.Minimum = new decimal(new int[]
			{
				2000000,
				0,
				0,
				int.MinValue
			});
			this.P4X.Name = "P4X";
			this.P4X.Size = new global::System.Drawing.Size(119, 32);
			this.P4X.TabIndex = 21;
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label9.Location = new global::System.Drawing.Point(464, 92);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(26, 21);
			this.label9.TabIndex = 20;
			this.label9.Text = "Z:";
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label10.Location = new global::System.Drawing.Point(306, 92);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(26, 21);
			this.label10.TabIndex = 19;
			this.label10.Text = "Y:";
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label11.Location = new global::System.Drawing.Point(150, 92);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(27, 21);
			this.label11.TabIndex = 18;
			this.label11.Text = "X:";
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label12.Location = new global::System.Drawing.Point(4, 92);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(152, 21);
			this.label12.TabIndex = 17;
			this.label12.Text = "截面顶点3（米）";
			this.P3Z.DecimalPlaces = 3;
			this.P3Z.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.P3Z.Location = new global::System.Drawing.Point(495, 90);
			global::System.Windows.Forms.NumericUpDown p3Z = this.P3Z;
			int[] array4 = new int[4];
			array4[0] = 2000000;
			p3Z.Maximum = new decimal(array4);
			this.P3Z.Minimum = new decimal(new int[]
			{
				2000000,
				0,
				0,
				int.MinValue
			});
			this.P3Z.Name = "P3Z";
			this.P3Z.Size = new global::System.Drawing.Size(120, 32);
			this.P3Z.TabIndex = 16;
			this.P3Y.DecimalPlaces = 3;
			this.P3Y.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.P3Y.Location = new global::System.Drawing.Point(337, 90);
			global::System.Windows.Forms.NumericUpDown p3Y = this.P3Y;
			int[] array5 = new int[4];
			array5[0] = 2000000;
			p3Y.Maximum = new decimal(array5);
			this.P3Y.Minimum = new decimal(new int[]
			{
				2000000,
				0,
				0,
				int.MinValue
			});
			this.P3Y.Name = "P3Y";
			this.P3Y.Size = new global::System.Drawing.Size(120, 32);
			this.P3Y.TabIndex = 15;
			this.P3X.DecimalPlaces = 3;
			this.P3X.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.P3X.Location = new global::System.Drawing.Point(181, 90);
			global::System.Windows.Forms.NumericUpDown p3X = this.P3X;
			int[] array6 = new int[4];
			array6[0] = 2000000;
			p3X.Maximum = new decimal(array6);
			this.P3X.Minimum = new decimal(new int[]
			{
				2000000,
				0,
				0,
				int.MinValue
			});
			this.P3X.Name = "P3X";
			this.P3X.Size = new global::System.Drawing.Size(119, 32);
			this.P3X.TabIndex = 14;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label5.Location = new global::System.Drawing.Point(463, 53);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(26, 21);
			this.label5.TabIndex = 13;
			this.label5.Text = "Z:";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label6.Location = new global::System.Drawing.Point(306, 55);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(26, 21);
			this.label6.TabIndex = 12;
			this.label6.Text = "Y:";
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label7.Location = new global::System.Drawing.Point(149, 55);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(27, 21);
			this.label7.TabIndex = 11;
			this.label7.Text = "X:";
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label8.Location = new global::System.Drawing.Point(4, 55);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(152, 21);
			this.label8.TabIndex = 10;
			this.label8.Text = "截面顶点2（米）";
			this.P2Z.DecimalPlaces = 3;
			this.P2Z.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.P2Z.Location = new global::System.Drawing.Point(495, 51);
			global::System.Windows.Forms.NumericUpDown p2Z = this.P2Z;
			int[] array7 = new int[4];
			array7[0] = 2000000;
			p2Z.Maximum = new decimal(array7);
			this.P2Z.Minimum = new decimal(new int[]
			{
				2000000,
				0,
				0,
				int.MinValue
			});
			this.P2Z.Name = "P2Z";
			this.P2Z.Size = new global::System.Drawing.Size(120, 32);
			this.P2Z.TabIndex = 9;
			this.P2Y.DecimalPlaces = 3;
			this.P2Y.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.P2Y.Location = new global::System.Drawing.Point(337, 53);
			global::System.Windows.Forms.NumericUpDown p2Y = this.P2Y;
			int[] array8 = new int[4];
			array8[0] = 2000000;
			p2Y.Maximum = new decimal(array8);
			this.P2Y.Minimum = new decimal(new int[]
			{
				2000000,
				0,
				0,
				int.MinValue
			});
			this.P2Y.Name = "P2Y";
			this.P2Y.Size = new global::System.Drawing.Size(120, 32);
			this.P2Y.TabIndex = 8;
			this.P2X.DecimalPlaces = 3;
			this.P2X.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.P2X.Location = new global::System.Drawing.Point(181, 51);
			global::System.Windows.Forms.NumericUpDown p2X = this.P2X;
			int[] array9 = new int[4];
			array9[0] = 2000000;
			p2X.Maximum = new decimal(array9);
			this.P2X.Minimum = new decimal(new int[]
			{
				2000000,
				0,
				0,
				int.MinValue
			});
			this.P2X.Name = "P2X";
			this.P2X.Size = new global::System.Drawing.Size(119, 32);
			this.P2X.TabIndex = 7;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label4.Location = new global::System.Drawing.Point(463, 16);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(26, 21);
			this.label4.TabIndex = 6;
			this.label4.Text = "Z:";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label3.Location = new global::System.Drawing.Point(305, 17);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(26, 21);
			this.label3.TabIndex = 5;
			this.label3.Text = "Y:";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label2.Location = new global::System.Drawing.Point(149, 17);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(27, 21);
			this.label2.TabIndex = 4;
			this.label2.Text = "X:";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.label1.Location = new global::System.Drawing.Point(4, 17);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(152, 21);
			this.label1.TabIndex = 3;
			this.label1.Text = "截面顶点1（米）";
			this.P1Z.DecimalPlaces = 3;
			this.P1Z.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.P1Z.Location = new global::System.Drawing.Point(495, 15);
			global::System.Windows.Forms.NumericUpDown p1Z = this.P1Z;
			int[] array10 = new int[4];
			array10[0] = 2000000;
			p1Z.Maximum = new decimal(array10);
			this.P1Z.Minimum = new decimal(new int[]
			{
				2000000,
				0,
				0,
				int.MinValue
			});
			this.P1Z.Name = "P1Z";
			this.P1Z.Size = new global::System.Drawing.Size(120, 32);
			this.P1Z.TabIndex = 2;
			this.P1Y.DecimalPlaces = 3;
			this.P1Y.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.P1Y.Location = new global::System.Drawing.Point(337, 14);
			global::System.Windows.Forms.NumericUpDown p1Y = this.P1Y;
			int[] array11 = new int[4];
			array11[0] = 2000000;
			p1Y.Maximum = new decimal(array11);
			this.P1Y.Minimum = new decimal(new int[]
			{
				2000000,
				0,
				0,
				int.MinValue
			});
			this.P1Y.Name = "P1Y";
			this.P1Y.Size = new global::System.Drawing.Size(120, 32);
			this.P1Y.TabIndex = 1;
			this.P1X.DecimalPlaces = 3;
			this.P1X.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			this.P1X.Location = new global::System.Drawing.Point(182, 14);
			global::System.Windows.Forms.NumericUpDown p1X = this.P1X;
			int[] array12 = new int[4];
			array12[0] = 2000000;
			p1X.Maximum = new decimal(array12);
			this.P1X.Minimum = new decimal(new int[]
			{
				2000000,
				0,
				0,
				int.MinValue
			});
			this.P1X.Name = "P1X";
			this.P1X.Size = new global::System.Drawing.Size(119, 32);
			this.P1X.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(10f, 21f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(654, 221);
			base.Controls.Add(this.CreateSection);
			base.Controls.Add(this.panel1);
			this.Font = new global::System.Drawing.Font("华文仿宋", 14.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new global::System.Windows.Forms.Padding(5);
			base.Name = "Form_EightView";
			this.Text = "提取八视图";
			base.Load += new global::System.EventHandler(this.Form_EightView_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.P4Z).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.P4Y).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.P4X).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.P3Z).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.P3Y).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.P3X).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.P2Z).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.P2Y).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.P2X).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.P1Z).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.P1Y).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.P1X).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000003 RID: 3
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.Button CreateSection;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.Label label15;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.Label label16;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.NumericUpDown P4Z;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.NumericUpDown P4Y;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.NumericUpDown P4X;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.Label label9;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.NumericUpDown P3Z;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.NumericUpDown P3Y;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.NumericUpDown P3X;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.NumericUpDown P2Z;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.NumericUpDown P2Y;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.NumericUpDown P2X;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Label label4;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.NumericUpDown P1Z;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.NumericUpDown P1Y;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.NumericUpDown P1X;
	}
}
