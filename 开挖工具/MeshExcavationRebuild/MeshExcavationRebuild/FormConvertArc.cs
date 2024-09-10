using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeshExcavationRebuild
{
    public partial class FormConvertArc : Form
    {
        public FormConvertArc(double MR)
        {
            InitializeComponent();
			this.meter_rate = MR;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000E1A8 File Offset: 0x0000C3A8
		private void CA_Click(object sender, EventArgs e)
		{
			double radius = Convert.ToDouble(this.Radius.Value);
			Func_Slope.Convert_Arc(radius, this.meter_rate);
		}

		// Token: 0x040000BA RID: 186
		public double meter_rate;
	}
}
