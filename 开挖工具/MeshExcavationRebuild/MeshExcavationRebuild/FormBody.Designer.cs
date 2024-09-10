
namespace MeshExcavationRebuild
{
    partial class FormBody
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
            this.LandId = new System.Windows.Forms.Label();
            this.ExcavationId = new System.Windows.Forms.Label();
            this.LockLand = new System.Windows.Forms.Button();
            this.LockExcavatio = new System.Windows.Forms.Button();
            this.Calculate = new System.Windows.Forms.Button();
            this.GetBlock = new System.Windows.Forms.Button();
            this.GetLine = new System.Windows.Forms.Button();
            this.Simplify = new System.Windows.Forms.Button();
            this.SimplifyPara = new System.Windows.Forms.NumericUpDown();
            this.SimplyText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SimplifyPobi = new System.Windows.Forms.NumericUpDown();
            this.PobiText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SimplifyPara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SimplifyPobi)).BeginInit();
            this.SuspendLayout();
            // 
            // LandId
            // 
            this.LandId.AutoSize = true;
            this.LandId.Location = new System.Drawing.Point(17, 17);
            this.LandId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LandId.Name = "LandId";
            this.LandId.Size = new System.Drawing.Size(104, 16);
            this.LandId.TabIndex = 0;
            this.LandId.Text = "地形：未锁定";
            // 
            // ExcavationId
            // 
            this.ExcavationId.AutoSize = true;
            this.ExcavationId.Location = new System.Drawing.Point(17, 53);
            this.ExcavationId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ExcavationId.Name = "ExcavationId";
            this.ExcavationId.Size = new System.Drawing.Size(120, 16);
            this.ExcavationId.TabIndex = 1;
            this.ExcavationId.Text = "开挖面：未锁定";
            // 
            // LockLand
            // 
            this.LockLand.Location = new System.Drawing.Point(144, 12);
            this.LockLand.Name = "LockLand";
            this.LockLand.Size = new System.Drawing.Size(100, 25);
            this.LockLand.TabIndex = 2;
            this.LockLand.Text = "锁定地形";
            this.LockLand.UseVisualStyleBackColor = true;
            this.LockLand.Click += new System.EventHandler(this.LockLand_Click);
            // 
            // LockExcavatio
            // 
            this.LockExcavatio.Location = new System.Drawing.Point(144, 49);
            this.LockExcavatio.Name = "LockExcavatio";
            this.LockExcavatio.Size = new System.Drawing.Size(100, 25);
            this.LockExcavatio.TabIndex = 3;
            this.LockExcavatio.Text = "锁定开挖面";
            this.LockExcavatio.UseVisualStyleBackColor = true;
            this.LockExcavatio.Click += new System.EventHandler(this.LockExcavation_Click);
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(20, 103);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(224, 25);
            this.Calculate.TabIndex = 4;
            this.Calculate.Text = "开挖量计算";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // GetBlock
            // 
            this.GetBlock.Location = new System.Drawing.Point(20, 134);
            this.GetBlock.Name = "GetBlock";
            this.GetBlock.Size = new System.Drawing.Size(100, 25);
            this.GetBlock.TabIndex = 5;
            this.GetBlock.Text = "提取开挖区";
            this.GetBlock.UseVisualStyleBackColor = true;
            this.GetBlock.Click += new System.EventHandler(this.GetBlock_Click);
            // 
            // GetLine
            // 
            this.GetLine.Location = new System.Drawing.Point(144, 134);
            this.GetLine.Name = "GetLine";
            this.GetLine.Size = new System.Drawing.Size(100, 25);
            this.GetLine.TabIndex = 6;
            this.GetLine.Text = "提取边界线";
            this.GetLine.UseVisualStyleBackColor = true;
            this.GetLine.Click += new System.EventHandler(this.GetLineString_Click);
            // 
            // Simplify
            // 
            this.Simplify.Location = new System.Drawing.Point(20, 254);
            this.Simplify.Name = "Simplify";
            this.Simplify.Size = new System.Drawing.Size(224, 25);
            this.Simplify.TabIndex = 7;
            this.Simplify.Text = "简化边界线";
            this.Simplify.UseVisualStyleBackColor = true;
            this.Simplify.Click += new System.EventHandler(this.SimplifyLine_Click);
            // 
            // SimplifyPara
            // 
            this.SimplifyPara.DecimalPlaces = 2;
            this.SimplifyPara.Location = new System.Drawing.Point(20, 190);
            this.SimplifyPara.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.SimplifyPara.Name = "SimplifyPara";
            this.SimplifyPara.Size = new System.Drawing.Size(120, 26);
            this.SimplifyPara.TabIndex = 8;
            // 
            // SimplyText
            // 
            this.SimplyText.AutoSize = true;
            this.SimplyText.Location = new System.Drawing.Point(172, 192);
            this.SimplyText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SimplyText.Name = "SimplyText";
            this.SimplyText.Size = new System.Drawing.Size(72, 16);
            this.SimplyText.TabIndex = 9;
            this.SimplyText.Text = "简化参数";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(-10, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 2);
            this.label1.TabIndex = 10;
            this.label1.Text = "地形：未锁定";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(-10, 177);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 2);
            this.label2.TabIndex = 11;
            this.label2.Text = "地形：未锁定";
            // 
            // SimplifyPobi
            // 
            this.SimplifyPobi.DecimalPlaces = 2;
            this.SimplifyPobi.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.SimplifyPobi.Location = new System.Drawing.Point(20, 222);
            this.SimplifyPobi.Name = "SimplifyPobi";
            this.SimplifyPobi.Size = new System.Drawing.Size(120, 26);
            this.SimplifyPobi.TabIndex = 12;
            // 
            // PobiText
            // 
            this.PobiText.AutoSize = true;
            this.PobiText.Location = new System.Drawing.Point(172, 224);
            this.PobiText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PobiText.Name = "PobiText";
            this.PobiText.Size = new System.Drawing.Size(72, 16);
            this.PobiText.TabIndex = 13;
            this.PobiText.Text = "原始坡比";
            // 
            // FormBody
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 287);
            this.Controls.Add(this.PobiText);
            this.Controls.Add(this.SimplifyPobi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SimplyText);
            this.Controls.Add(this.SimplifyPara);
            this.Controls.Add(this.Simplify);
            this.Controls.Add(this.GetLine);
            this.Controls.Add(this.GetBlock);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.LockExcavatio);
            this.Controls.Add(this.LockLand);
            this.Controls.Add(this.ExcavationId);
            this.Controls.Add(this.LandId);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormBody";
            this.Text = "三维处理";
            this.Load += new System.EventHandler(this.FormBody_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SimplifyPara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SimplifyPobi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LandId;
        private System.Windows.Forms.Label ExcavationId;
        private System.Windows.Forms.Button LockLand;
        private System.Windows.Forms.Button LockExcavatio;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Button GetBlock;
        private System.Windows.Forms.Button GetLine;
        private System.Windows.Forms.Button Simplify;
        private System.Windows.Forms.NumericUpDown SimplifyPara;
        private System.Windows.Forms.Label SimplyText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown SimplifyPobi;
        private System.Windows.Forms.Label PobiText;
    }
}