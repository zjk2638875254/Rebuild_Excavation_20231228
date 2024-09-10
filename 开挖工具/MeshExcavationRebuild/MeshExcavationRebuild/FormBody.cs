using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.Interop.MicroStationDGN;
using Bentley.MstnPlatformNET;
using Bentley.MstnPlatformNET.InteropServices;
using self_define;

namespace MeshExcavationRebuild
{
    public partial class FormBody : Form
    {
        public FormBody(double rate)
        {
			this.meter_rate = rate;
			InitializeComponent();
        }

        private void FormBody_Load(object sender, EventArgs e)
        {

        }

		// Token: 0x06000057 RID: 87 RVA: 0x00009A68 File Offset: 0x00007C68
		private void Calculate_Click(object sender, EventArgs e)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			long land_id = Convert.ToInt64(this.LandId.Text);
			long excavation_id = Convert.ToInt64(this.ExcavationId.Text);
			bool flag = land_id == 0L || excavation_id == 0L;
			if (flag)
			{
				MessageBox.Show("请锁定岩面和开挖面");
			}
			else
			{
				Bentley.DgnPlatformNET.Elements.Element land_ele = dgnModel.FindElementById((ElementId)land_id);
				Bentley.DgnPlatformNET.Elements.Element excavation_ele = dgnModel.FindElementById((ElementId)excavation_id);
				bool flag2 = land_ele == null || excavation_ele == null;
				if (flag2)
				{
					MessageBox.Show("请锁定正确的岩面和开挖面");
				}
				else
				{
					double land_z = 0.0;
					double excavation_z = 0.0;
					bool flag3 = Func_Calculate.get_low(land_ele, ref land_z);
					bool flag4 = Func_Calculate.get_low(excavation_ele, ref excavation_z);
					land_z /= this.meter_rate;
					excavation_z /= this.meter_rate;
					double vol = 0.0;
					double vol2 = 0.0;
					Func_Calculate.vol_500(land_ele, ref vol, this.meter_rate, 500.0 - (land_z - excavation_z));
					bool flag5 = land_ele == null || excavation_ele == null;
					if (flag5)
					{
						MessageBox.Show("Wrong");
					}
					SelectionSetManager.EmptyAll();
					SelectionSetManager.AddElement(land_ele, dgnModel);
					SelectionSetManager.AddElement(excavation_ele, dgnModel);
					long res_id = 0L;
					Func_Bentley.Mesh_Union(ref res_id);
					Bentley.DgnPlatformNET.Elements.Element res_ele = dgnModel.FindElementById((ElementId)res_id);
					Func_Calculate.vol_500(res_ele, ref vol2, this.meter_rate, 500.0 - (land_z - excavation_z));
					double vol_m3 = vol - vol2;
					EC17.create_ec_double(res_ele, "开挖量", "立方米", vol - vol2, "三维开挖工具_Mesh版");
					EC17.create_ec_string(res_ele, "开挖量", "地层名称", "default_type", "三维开挖工具_Mesh版");
				}
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00009C08 File Offset: 0x00007E08
		private void LockLand_Click(object sender, EventArgs e)
		{
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			bool flag = agenda.GetCount() != 1;
			if (flag)
			{
				MessageBox.Show("请选择唯一地形!");
			}
			else
			{
				this.LandId.Text = agenda.GetEntry(0).ElementId.ToString();
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00009C64 File Offset: 0x00007E64
		private void LockExcavation_Click(object sender, EventArgs e)
		{
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			bool flag = agenda.GetCount() != 1U;
			if (flag)
			{
				MessageBox.Show("请选择唯一地形!");
			}
			else
			{
				this.ExcavationId.Text = agenda.GetEntry(0).ElementId.ToString();
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00009CC0 File Offset: 0x00007EC0
		private void GetLineString_Click(object sender, EventArgs e)
		{
			Func_Bentley.Get_Line();
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00009CCC File Offset: 0x00007ECC
		private void GetBlock_Click(object sender, EventArgs e)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			long land_id = Convert.ToInt64(this.LandId.Text);
			long excavation_id = Convert.ToInt64(this.ExcavationId.Text);
			bool flag = land_id == 0L || excavation_id == 0L;
			if (flag)
			{
				MessageBox.Show("请锁定岩面和开挖面");
			}
			else
			{
				Bentley.DgnPlatformNET.Elements.Element land_ele = dgnModel.FindElementById((ElementId)land_id);
				Bentley.DgnPlatformNET.Elements.Element excavation_ele = dgnModel.FindElementById((ElementId)excavation_id);
				bool flag2 = land_ele == null || excavation_ele == null;
				if (flag2)
				{
					MessageBox.Show("请锁定正确的岩面和开挖面");
				}
				else
				{
					using (ElementCopyContext context = new ElementCopyContext(dgnModel))
					{
						context.DoCopy(land_ele);
					}
					Bentley.Interop.MicroStationDGN.Element MSDgn_ele = Utilities.ComApp.ActiveModelReference.GetLastValidGraphicalElement();
					using (ElementCopyContext context2 = new ElementCopyContext(dgnModel))
					{
						context2.DoCopy(excavation_ele);
					}
					long ele_id = 0L;
					Func_Bentley.Mesh_Sub(ref ele_id);
				}
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00009DE0 File Offset: 0x00007FE0
		private void SimplifyLine_Click(object sender, EventArgs e)
		{
			int para = Convert.ToInt32(this.SimplifyPara.Value);
			double rate = Convert.ToDouble(SimplifyPobi.Value);
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			Bentley.DgnPlatformNET.Elements.Element ele = agenda.GetEntry(0U);
			bool flag = ele.ElementType != MSElementType.LineString;
			var line_ids = new List<long>();
			{
				LineStringElement lineString = ele as LineStringElement;
				Func_Calculate.cut_by_vector(lineString, para, ref line_ids);
			}
			foreach(long ele_id in line_ids)
            {
				Bentley.DgnPlatformNET.Elements.Element line_ele = dgnModel.FindElementById((ElementId)ele_id);
				EC17.create_ec_double(line_ele, "坡比", "坡比", rate, "三维开挖工具_Mesh版");
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00009E45 File Offset: 0x00008045
		private void Form_Body_Load(object sender, EventArgs e)
		{
			this.SimplifyPara.Value = 30;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00009E5B File Offset: 0x0000805B
		private void button1_Click(object sender, EventArgs e)
		{
			Func_Calculate.reverse_mesh();
		}

		// Token: 0x04000057 RID: 87
		private double meter_rate;
	}
}
