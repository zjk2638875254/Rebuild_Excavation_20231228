
namespace MeshExcavationRebuild
{
    partial class FormConvertArc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelText2 = new System.Windows.Forms.Label();
            this.CA = new System.Windows.Forms.Button();
            this.Radius = new System.Windows.Forms.NumericUpDown();
            this.labelText1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Radius)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelText2);
            this.panel1.Controls.Add(this.CA);
            this.panel1.Controls.Add(this.Radius);
            this.panel1.Controls.Add(this.labelText1);
            this.panel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(16, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 104);
            this.panel1.TabIndex = 1;
            // 
            // labelText2
            // 
            this.labelText2.AutoSize = true;
            this.labelText2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelText2.Location = new System.Drawing.Point(206, 16);
            this.labelText2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText2.Name = "labelText2";
            this.labelText2.Size = new System.Drawing.Size(24, 16);
            this.labelText2.TabIndex = 7;
            this.labelText2.Text = "米";
            // 
            // CA
            // 
            this.CA.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CA.Location = new System.Drawing.Point(4, 56);
            this.CA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CA.Name = "CA";
            this.CA.Size = new System.Drawing.Size(226, 30);
            this.CA.TabIndex = 6;
            this.CA.Text = "倒角";
            this.CA.UseVisualStyleBackColor = true;
            this.CA.Click += new System.EventHandler(this.CA_Click);
            // 
            // Radius
            // 
            this.Radius.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Radius.Location = new System.Drawing.Point(84, 14);
            this.Radius.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(114, 26);
            this.Radius.TabIndex = 5;
            // 
            // labelText1
            // 
            this.labelText1.AutoSize = true;
            this.labelText1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelText1.Location = new System.Drawing.Point(4, 16);
            this.labelText1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelText1.Name = "labelText1";
            this.labelText1.Size = new System.Drawing.Size(72, 16);
            this.labelText1.TabIndex = 4;
            this.labelText1.Text = "倒角半径";
            // 
            // FormConvertArc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 127);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormConvertArc";
            this.Text = "圆弧倒角";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Radius)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelText2;
        private System.Windows.Forms.Button CA;
        private System.Windows.Forms.NumericUpDown Radius;
        private System.Windows.Forms.Label labelText1;
    }
}