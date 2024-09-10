using Bentley.DgnPlatformNET;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagTools;

namespace MeshExcavationRebuild
{
    public partial class FormTag : Form
    {
		private DPoint3d center_point;

		// Token: 0x04000042 RID: 66
		private double meter_rate;

		// Token: 0x04000043 RID: 67
		private double base_h;

		// Token: 0x04000044 RID: 68
		private Dictionary<string, string> styleDic;
		public FormTag(DPoint3d center, double rate, double base_height)
        {
			center_point = center;
			meter_rate = rate;
			base_h = base_height;
			styleDic = new Dictionary<string, string>();
			InitializeComponent();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00006760 File Offset: 0x00004960
		private void Form_Tag_Load(object sender, EventArgs e)
		{
			StyleFont.Items.Add("小");
			StyleFont.Items.Add("中");
			StyleFont.Items.Add("大");
			StyleFont.Items.Add("超大");
			styleDic["小"] = "ExcavationStyle_Level1";
			styleDic["中"] = "ExcavationStyle_Level2";
			styleDic["大"] = "ExcavationStyle_Level3";
			styleDic["超大"] = "ExcavationStyle_Level4";
			EcName.Items.Add("坡比");
			EcName.Items.Add("桩号");
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000684C File Offset: 0x00004A4C
		private void TagPobi_Click(object sender, EventArgs e)
		{

        }

        // Token: 0x06000024 RID: 36 RVA: 0x000068A4 File Offset: 0x00004AA4
        private void TagHeight_Click(object sender, EventArgs e)
		{
			if (StyleFont.SelectedItem == null)
			{
				MessageBox.Show("未选择格式!");
			}
			else
			{
				DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
				DgnTextStyle style = DgnTextStyle.GetByName(this.styleDic[StyleFont.SelectedItem.ToString()], dgnFile);
				Func_Tag.tag_height(this.base_h, style, this.center_point);
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00006912 File Offset: 0x00004B12
		private void TagPoints_Click(object sender, EventArgs e)
		{
			try
			{
				Func_Tag.Add_TagLine(styleDic[StyleFont.SelectedItem.ToString()], meter_rate);
			}
			catch(Exception ex)
            {
				MessageBox.Show("1:" + ex.ToString());
            }
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000693C File Offset: 0x00004B3C
		private void OutputPoints_Click(object sender, EventArgs e)
		{
			if (StyleFont.SelectedItem == null)
			{
				MessageBox.Show("未选择格式!");
			}
			else
			{
				Func_Tag.Tag_Output(styleDic[StyleFont.SelectedItem.ToString()], this.meter_rate);
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00006994 File Offset: 0x00004B94
		private void AddProperty_Click(object sender, EventArgs e)
		{
			string property_name = EcName.Text;
			bool flag = property_name == "坡比";
			if (flag)
			{
				Func_Tag.create_data_double("坡比", "坡比", Convert.ToDouble(this.EcValue.Text));
			}
			else
			{
				bool flag2 = property_name == "桩号";
				if (flag2)
				{
					Func_Tag.create_data_double("桩号", "时间戳", Convert.ToDouble(this.EcValue.Text));
				}
			}
		}

        private void button1_Click(object sender, EventArgs e)
        {
			if (StyleFont.SelectedItem == null)
			{
				MessageBox.Show("未选择格式!");
			}
			else
			{
				//MessageBox.Show(styleDic[StyleFont.SelectedItem.ToString()]);
				Func_Tag.T1_Pobi(this.center_point, styleDic[StyleFont.SelectedItem.ToString()]);
			}
		}

        private void button2_Click(object sender, EventArgs e)
        {
			if (StyleFont.SelectedItem == null)
			{
				MessageBox.Show("未选择格式!");
			}
			else
			{
				//MessageBox.Show(styleDic[StyleFont.SelectedItem.ToString()]);
				Func_Tag.T2_Pobi(this.center_point, styleDic[StyleFont.SelectedItem.ToString()]);
			}
		}

        private void button3_Click(object sender, EventArgs e)
        {
			if (StyleFont.SelectedItem == null)
			{
				MessageBox.Show("未选择格式!");
			}
			else
			{
				//MessageBox.Show(styleDic[StyleFont.SelectedItem.ToString()]);
				Func_Tag.T3_Pobi(this.center_point, styleDic[StyleFont.SelectedItem.ToString()]);
			}
		}

        private void PlaceExcel_Click(object sender, EventArgs e)
        {
			Func_Tag.Tag_Excel(this.meter_rate);
		}
    }
}
