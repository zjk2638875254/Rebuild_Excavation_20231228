
namespace MeshExcavationRebuild
{
    partial class FormSlope
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
            this.labelText4 = new System.Windows.Forms.Label();
            this.Absolute = new System.Windows.Forms.NumericUpDown();
            this.AbsoluteSlope = new System.Windows.Forms.Button();
            this.LandText1 = new System.Windows.Forms.Label();
            this.labelText2 = new System.Windows.Forms.Label();
            this.Absolute90Slope = new System.Windows.Forms.Button();
            this.labelText5 = new System.Windows.Forms.Label();
            this.Relative90Slope = new System.Windows.Forms.Button();
            this.labelText6 = new System.Windows.Forms.Label();
            this.Relative = new System.Windows.Forms.NumericUpDown();
            this.RelativeSlope = new System.Windows.Forms.Button();
            this.labelText3 = new System.Windows.Forms.Label();
            this.AbsoluteRate = new System.Windows.Forms.NumericUpDown();
            this.RelativeRate = new System.Windows.Forms.NumericUpDown();
            this.labelText7 = new System.Windows.Forms.Label();
            this.labelText8 = new System.Windows.Forms.Label();
            this.labelText10 = new System.Windows.Forms.Label();
            this.HorseWidth = new System.Windows.Forms.NumericUpDown();
            this.HorseSlopeSIngle = new System.Windows.Forms.Button();
            this.labelText9 = new System.Windows.Forms.Label();
            this.labelText11 = new System.Windows.Forms.Label();
            this.labelText13 = new System.Windows.Forms.Label();
            this.MultiHorseWidth = new System.Windows.Forms.NumericUpDown();
            this.HorseSlopeMulti = new System.Windows.Forms.Button();
            this.labelText12 = new System.Windows.Forms.Label();
            this.labelText14 = new System.Windows.Forms.Label();
            this.MultiHorseHeight = new System.Windows.Forms.NumericUpDown();
            this.MultiHorseRate = new System.Windows.Forms.NumericUpDown();
            this.labelText15 = new System.Windows.Forms.Label();
            this.MultiHorseLevel = new System.Windows.Forms.NumericUpDown();
            this.labelText16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Absolute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Relative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AbsoluteRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RelativeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HorseWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiHorseWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiHorseHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiHorseRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiHorseLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // labelText4
            // 
            this.labelText4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelText4.Location = new System.Drawing.Point(11, 133);
            this.labelText4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText4.Name = "labelText4";
            this.labelText4.Size = new System.Drawing.Size(248, 2);
            this.labelText4.TabIndex = 22;
            this.labelText4.Text = "分割线";
            // 
            // Absolute
            // 
            this.Absolute.DecimalPlaces = 2;
            this.Absolute.Location = new System.Drawing.Point(99, 37);
            this.Absolute.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.Absolute.Name = "Absolute";
            this.Absolute.Size = new System.Drawing.Size(161, 26);
            this.Absolute.TabIndex = 20;
            // 
            // AbsoluteSlope
            // 
            this.AbsoluteSlope.Location = new System.Drawing.Point(11, 100);
            this.AbsoluteSlope.Name = "AbsoluteSlope";
            this.AbsoluteSlope.Size = new System.Drawing.Size(100, 25);
            this.AbsoluteSlope.TabIndex = 14;
            this.AbsoluteSlope.Text = "高程放坡";
            this.AbsoluteSlope.UseVisualStyleBackColor = true;
            this.AbsoluteSlope.Click += new System.EventHandler(this.absolute_Click);
            // 
            // LandText1
            // 
            this.LandText1.AutoSize = true;
            this.LandText1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LandText1.Location = new System.Drawing.Point(9, 9);
            this.LandText1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LandText1.Name = "LandText1";
            this.LandText1.Size = new System.Drawing.Size(212, 16);
            this.LandText1.TabIndex = 12;
            this.LandText1.Text = "高程放坡：放坡至指定高度";
            // 
            // labelText2
            // 
            this.labelText2.AutoSize = true;
            this.labelText2.Location = new System.Drawing.Point(9, 39);
            this.labelText2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText2.Name = "labelText2";
            this.labelText2.Size = new System.Drawing.Size(80, 16);
            this.labelText2.TabIndex = 24;
            this.labelText2.Text = "高程/米：";
            // 
            // Absolute90Slope
            // 
            this.Absolute90Slope.Location = new System.Drawing.Point(140, 100);
            this.Absolute90Slope.Name = "Absolute90Slope";
            this.Absolute90Slope.Size = new System.Drawing.Size(120, 25);
            this.Absolute90Slope.TabIndex = 25;
            this.Absolute90Slope.Text = "高程放坡-直坡";
            this.Absolute90Slope.UseVisualStyleBackColor = true;
            this.Absolute90Slope.Click += new System.EventHandler(this.absolute_height_Click);
            // 
            // labelText5
            // 
            this.labelText5.AutoSize = true;
            this.labelText5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelText5.Location = new System.Drawing.Point(9, 151);
            this.labelText5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText5.Name = "labelText5";
            this.labelText5.Size = new System.Drawing.Size(263, 16);
            this.labelText5.TabIndex = 26;
            this.labelText5.Text = "高差放坡：以指定高度差进行放坡";
            // 
            // Relative90Slope
            // 
            this.Relative90Slope.Location = new System.Drawing.Point(136, 238);
            this.Relative90Slope.Name = "Relative90Slope";
            this.Relative90Slope.Size = new System.Drawing.Size(120, 25);
            this.Relative90Slope.TabIndex = 30;
            this.Relative90Slope.Text = "高差放坡-直坡";
            this.Relative90Slope.UseVisualStyleBackColor = true;
            this.Relative90Slope.Click += new System.EventHandler(this.relative_height_Click);
            // 
            // labelText6
            // 
            this.labelText6.AutoSize = true;
            this.labelText6.Location = new System.Drawing.Point(9, 176);
            this.labelText6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText6.Name = "labelText6";
            this.labelText6.Size = new System.Drawing.Size(80, 16);
            this.labelText6.TabIndex = 29;
            this.labelText6.Text = "高差/米：";
            // 
            // Relative
            // 
            this.Relative.DecimalPlaces = 2;
            this.Relative.Location = new System.Drawing.Point(95, 174);
            this.Relative.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Relative.Name = "Relative";
            this.Relative.Size = new System.Drawing.Size(161, 26);
            this.Relative.TabIndex = 28;
            // 
            // RelativeSlope
            // 
            this.RelativeSlope.Location = new System.Drawing.Point(11, 238);
            this.RelativeSlope.Name = "RelativeSlope";
            this.RelativeSlope.Size = new System.Drawing.Size(100, 25);
            this.RelativeSlope.TabIndex = 27;
            this.RelativeSlope.Text = "高差放坡";
            this.RelativeSlope.UseVisualStyleBackColor = true;
            this.RelativeSlope.Click += new System.EventHandler(this.relative_Click);
            // 
            // labelText3
            // 
            this.labelText3.AutoSize = true;
            this.labelText3.Location = new System.Drawing.Point(9, 70);
            this.labelText3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText3.Name = "labelText3";
            this.labelText3.Size = new System.Drawing.Size(64, 16);
            this.labelText3.TabIndex = 31;
            this.labelText3.Text = "坡比 1:";
            // 
            // AbsoluteRate
            // 
            this.AbsoluteRate.DecimalPlaces = 4;
            this.AbsoluteRate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.AbsoluteRate.Location = new System.Drawing.Point(99, 68);
            this.AbsoluteRate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AbsoluteRate.Name = "AbsoluteRate";
            this.AbsoluteRate.Size = new System.Drawing.Size(161, 26);
            this.AbsoluteRate.TabIndex = 32;
            // 
            // RelativeRate
            // 
            this.RelativeRate.DecimalPlaces = 4;
            this.RelativeRate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.RelativeRate.Location = new System.Drawing.Point(95, 206);
            this.RelativeRate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RelativeRate.Name = "RelativeRate";
            this.RelativeRate.Size = new System.Drawing.Size(161, 26);
            this.RelativeRate.TabIndex = 34;
            // 
            // labelText7
            // 
            this.labelText7.AutoSize = true;
            this.labelText7.Location = new System.Drawing.Point(9, 208);
            this.labelText7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText7.Name = "labelText7";
            this.labelText7.Size = new System.Drawing.Size(64, 16);
            this.labelText7.TabIndex = 33;
            this.labelText7.Text = "坡比 1:";
            // 
            // labelText8
            // 
            this.labelText8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelText8.Location = new System.Drawing.Point(11, 279);
            this.labelText8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText8.Name = "labelText8";
            this.labelText8.Size = new System.Drawing.Size(248, 2);
            this.labelText8.TabIndex = 35;
            this.labelText8.Text = "分割线";
            // 
            // labelText10
            // 
            this.labelText10.AutoSize = true;
            this.labelText10.Location = new System.Drawing.Point(9, 317);
            this.labelText10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText10.Name = "labelText10";
            this.labelText10.Size = new System.Drawing.Size(112, 16);
            this.labelText10.TabIndex = 39;
            this.labelText10.Text = "马道宽度/米：";
            // 
            // HorseWidth
            // 
            this.HorseWidth.DecimalPlaces = 3;
            this.HorseWidth.Location = new System.Drawing.Point(136, 315);
            this.HorseWidth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.HorseWidth.Name = "HorseWidth";
            this.HorseWidth.Size = new System.Drawing.Size(120, 26);
            this.HorseWidth.TabIndex = 38;
            // 
            // HorseSlopeSIngle
            // 
            this.HorseSlopeSIngle.Location = new System.Drawing.Point(12, 349);
            this.HorseSlopeSIngle.Name = "HorseSlopeSIngle";
            this.HorseSlopeSIngle.Size = new System.Drawing.Size(244, 25);
            this.HorseSlopeSIngle.TabIndex = 37;
            this.HorseSlopeSIngle.Text = "马道放坡";
            this.HorseSlopeSIngle.UseVisualStyleBackColor = true;
            this.HorseSlopeSIngle.Click += new System.EventHandler(this.slope_once_Click);
            // 
            // labelText9
            // 
            this.labelText9.AutoSize = true;
            this.labelText9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelText9.Location = new System.Drawing.Point(9, 292);
            this.labelText9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText9.Name = "labelText9";
            this.labelText9.Size = new System.Drawing.Size(76, 16);
            this.labelText9.TabIndex = 36;
            this.labelText9.Text = "马道放坡";
            // 
            // labelText11
            // 
            this.labelText11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelText11.Location = new System.Drawing.Point(8, 386);
            this.labelText11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText11.Name = "labelText11";
            this.labelText11.Size = new System.Drawing.Size(248, 2);
            this.labelText11.TabIndex = 41;
            this.labelText11.Text = "分割线";
            // 
            // labelText13
            // 
            this.labelText13.AutoSize = true;
            this.labelText13.Location = new System.Drawing.Point(8, 425);
            this.labelText13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText13.Name = "labelText13";
            this.labelText13.Size = new System.Drawing.Size(112, 16);
            this.labelText13.TabIndex = 45;
            this.labelText13.Text = "马道宽度/米：";
            // 
            // MultiHorseWidth
            // 
            this.MultiHorseWidth.DecimalPlaces = 3;
            this.MultiHorseWidth.Location = new System.Drawing.Point(135, 423);
            this.MultiHorseWidth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.MultiHorseWidth.Name = "MultiHorseWidth";
            this.MultiHorseWidth.Size = new System.Drawing.Size(120, 26);
            this.MultiHorseWidth.TabIndex = 44;
            // 
            // HorseSlopeMulti
            // 
            this.HorseSlopeMulti.Location = new System.Drawing.Point(3, 551);
            this.HorseSlopeMulti.Name = "HorseSlopeMulti";
            this.HorseSlopeMulti.Size = new System.Drawing.Size(252, 25);
            this.HorseSlopeMulti.TabIndex = 43;
            this.HorseSlopeMulti.Text = "多级马道放坡";
            this.HorseSlopeMulti.UseVisualStyleBackColor = true;
            this.HorseSlopeMulti.Click += new System.EventHandler(this.MultiHorse_Click);
            // 
            // labelText12
            // 
            this.labelText12.AutoSize = true;
            this.labelText12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelText12.Location = new System.Drawing.Point(8, 400);
            this.labelText12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText12.Name = "labelText12";
            this.labelText12.Size = new System.Drawing.Size(110, 16);
            this.labelText12.TabIndex = 42;
            this.labelText12.Text = "多级马道放坡";
            // 
            // labelText14
            // 
            this.labelText14.AutoSize = true;
            this.labelText14.Location = new System.Drawing.Point(9, 457);
            this.labelText14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText14.Name = "labelText14";
            this.labelText14.Size = new System.Drawing.Size(80, 16);
            this.labelText14.TabIndex = 46;
            this.labelText14.Text = "高差/米：";
            // 
            // MultiHorseHeight
            // 
            this.MultiHorseHeight.DecimalPlaces = 2;
            this.MultiHorseHeight.Location = new System.Drawing.Point(94, 455);
            this.MultiHorseHeight.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.MultiHorseHeight.Name = "MultiHorseHeight";
            this.MultiHorseHeight.Size = new System.Drawing.Size(161, 26);
            this.MultiHorseHeight.TabIndex = 47;
            // 
            // MultiHorseRate
            // 
            this.MultiHorseRate.DecimalPlaces = 4;
            this.MultiHorseRate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.MultiHorseRate.Location = new System.Drawing.Point(95, 487);
            this.MultiHorseRate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MultiHorseRate.Name = "MultiHorseRate";
            this.MultiHorseRate.Size = new System.Drawing.Size(161, 26);
            this.MultiHorseRate.TabIndex = 49;
            // 
            // labelText15
            // 
            this.labelText15.AutoSize = true;
            this.labelText15.Location = new System.Drawing.Point(9, 489);
            this.labelText15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText15.Name = "labelText15";
            this.labelText15.Size = new System.Drawing.Size(64, 16);
            this.labelText15.TabIndex = 48;
            this.labelText15.Text = "坡比 1:";
            // 
            // MultiHorseLevel
            // 
            this.MultiHorseLevel.Location = new System.Drawing.Point(94, 519);
            this.MultiHorseLevel.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.MultiHorseLevel.Name = "MultiHorseLevel";
            this.MultiHorseLevel.Size = new System.Drawing.Size(161, 26);
            this.MultiHorseLevel.TabIndex = 51;
            // 
            // labelText16
            // 
            this.labelText16.AutoSize = true;
            this.labelText16.Location = new System.Drawing.Point(9, 521);
            this.labelText16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText16.Name = "labelText16";
            this.labelText16.Size = new System.Drawing.Size(56, 16);
            this.labelText16.TabIndex = 50;
            this.labelText16.Text = "级数：";
            // 
            // FormSlope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 607);
            this.Controls.Add(this.MultiHorseLevel);
            this.Controls.Add(this.labelText16);
            this.Controls.Add(this.MultiHorseRate);
            this.Controls.Add(this.labelText15);
            this.Controls.Add(this.MultiHorseHeight);
            this.Controls.Add(this.labelText14);
            this.Controls.Add(this.labelText13);
            this.Controls.Add(this.MultiHorseWidth);
            this.Controls.Add(this.HorseSlopeMulti);
            this.Controls.Add(this.labelText12);
            this.Controls.Add(this.labelText11);
            this.Controls.Add(this.labelText10);
            this.Controls.Add(this.HorseWidth);
            this.Controls.Add(this.HorseSlopeSIngle);
            this.Controls.Add(this.labelText9);
            this.Controls.Add(this.labelText8);
            this.Controls.Add(this.RelativeRate);
            this.Controls.Add(this.labelText7);
            this.Controls.Add(this.AbsoluteRate);
            this.Controls.Add(this.labelText3);
            this.Controls.Add(this.Relative90Slope);
            this.Controls.Add(this.labelText6);
            this.Controls.Add(this.Relative);
            this.Controls.Add(this.RelativeSlope);
            this.Controls.Add(this.labelText5);
            this.Controls.Add(this.Absolute90Slope);
            this.Controls.Add(this.labelText2);
            this.Controls.Add(this.labelText4);
            this.Controls.Add(this.Absolute);
            this.Controls.Add(this.AbsoluteSlope);
            this.Controls.Add(this.LandText1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSlope";
            this.Text = "放坡";
            ((System.ComponentModel.ISupportInitialize)(this.Absolute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Relative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AbsoluteRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RelativeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HorseWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiHorseWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiHorseHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiHorseRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiHorseLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelText4;
        private System.Windows.Forms.NumericUpDown Absolute;
        private System.Windows.Forms.Button AbsoluteSlope;
        private System.Windows.Forms.Label LandText1;
        private System.Windows.Forms.Label labelText2;
        private System.Windows.Forms.Button Absolute90Slope;
        private System.Windows.Forms.Label labelText5;
        private System.Windows.Forms.Button Relative90Slope;
        private System.Windows.Forms.Label labelText6;
        private System.Windows.Forms.NumericUpDown Relative;
        private System.Windows.Forms.Button RelativeSlope;
        private System.Windows.Forms.Label labelText3;
        private System.Windows.Forms.NumericUpDown AbsoluteRate;
        private System.Windows.Forms.NumericUpDown RelativeRate;
        private System.Windows.Forms.Label labelText7;
        private System.Windows.Forms.Label labelText8;
        private System.Windows.Forms.Label labelText10;
        private System.Windows.Forms.NumericUpDown HorseWidth;
        private System.Windows.Forms.Button HorseSlopeSIngle;
        private System.Windows.Forms.Label labelText9;
        private System.Windows.Forms.Label labelText11;
        private System.Windows.Forms.Label labelText13;
        private System.Windows.Forms.NumericUpDown MultiHorseWidth;
        private System.Windows.Forms.Button HorseSlopeMulti;
        private System.Windows.Forms.Label labelText12;
        private System.Windows.Forms.Label labelText14;
        private System.Windows.Forms.NumericUpDown MultiHorseHeight;
        private System.Windows.Forms.NumericUpDown MultiHorseRate;
        private System.Windows.Forms.Label labelText15;
        private System.Windows.Forms.NumericUpDown MultiHorseLevel;
        private System.Windows.Forms.Label labelText16;
    }
}