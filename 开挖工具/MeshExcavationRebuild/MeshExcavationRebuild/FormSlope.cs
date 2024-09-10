using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Bentley.GeometryNET;
namespace MeshExcavationRebuild
{
    public partial class FormSlope : Form
    {
        public FormSlope(DPoint3d cp, double b_height, double MR)
        {
			this.ele_center = cp;
			this.base_height = b_height;
			this.meter_rate = MR;
			InitializeComponent();
        }

		// Token: 0x06000076 RID: 118 RVA: 0x0000BBC4 File Offset: 0x00009DC4
		private void relative_Click(object sender, EventArgs e)
		{
			Func_Slope.BaseLine_Relative(Convert.ToDouble(this.Relative.Value), Convert.ToDouble(this.RelativeRate.Value), this.meter_rate, this.ele_center);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000BBFC File Offset: 0x00009DFC
		private void absolute_Click(object sender, EventArgs e)
		{
			Func_Slope.BaseLine_Absolute(Convert.ToDouble(this.Absolute.Value), Convert.ToDouble(this.AbsoluteRate.Value), this.meter_rate, this.ele_center);
		}

        // Token: 0x06000078 RID: 120 RVA: 0x0000BC6B File Offset: 0x00009E6B
        private void relative_height_Click(object sender, EventArgs e)
		{
			Func_Slope.BaseLine_Relative90(Convert.ToDouble(this.Relative.Value), this.meter_rate, this.ele_center);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000BC90 File Offset: 0x00009E90
		private void absolute_height_Click(object sender, EventArgs e)
		{
			Func_Slope.BaseLine_Absolute90(Convert.ToDouble(this.Absolute.Value), this.meter_rate, this.ele_center);
		}

        // Token: 0x0600007A RID: 122 RVA: 0x0000BCFB File Offset: 0x00009EFB
        private void slope_once_Click(object sender, EventArgs e)
		{
			Func_Slope.HorseLine_Slope(Convert.ToDouble(this.HorseWidth.Value), this.meter_rate, this.ele_center);
		}

        // Token: 0x0600007B RID: 123 RVA: 0x0000BD20 File Offset: 0x00009F20
        private void MultiHorse_Click(object sender, EventArgs e)
		{
			double width = Convert.ToDouble(this.MultiHorseWidth.Value);
			double height = Convert.ToDouble(this.MultiHorseHeight.Value);
			double rate = Convert.ToDouble(this.MultiHorseRate.Value);
			double level = Convert.ToDouble(this.MultiHorseLevel.Value);
			Func_Slope.Multy_HorseLine(width, height, rate, level, this.meter_rate, this.ele_center);
		}

		// Token: 0x04000080 RID: 128
		private DPoint3d ele_center;

		// Token: 0x04000081 RID: 129
		private double base_height;

		// Token: 0x04000082 RID: 130
		private double meter_rate;
	}
}
