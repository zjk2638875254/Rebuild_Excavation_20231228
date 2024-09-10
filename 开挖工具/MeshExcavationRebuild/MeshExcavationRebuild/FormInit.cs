using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
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

namespace MeshExcavationRebuild
{
    public partial class FormInit : Form
    {
        public FormInit(DPoint3d center_old, double bh, double MeterRate)
        {
			this.center.X = center_old.X;
			this.center.Y = center_old.Y;
			this.center.Z = center_old.Z;
			this.meter_rate = MeterRate;
			InitializeComponent();
        }
		public event FormInit.RefreshEvent refresh;

		// Token: 0x06000063 RID: 99 RVA: 0x0000A7E4 File Offset: 0x000089E4

		// Token: 0x06000064 RID: 100 RVA: 0x0000A88C File Offset: 0x00008A8C
		private void output_refresh()
		{
			string message = string.Concat(new string[]
			{
				"锚点坐标为：\r\n(",
				this.center.X.ToString(),
				" , ",
				this.center.Y.ToString(),
				" , ",
				this.center.Z.ToString(),
				")\r\n"
			});
			message = message + "基面高程为：" + this.base_h.ToString() + "米";
			this.Point_Output.Text = message;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000A934 File Offset: 0x00008B34
		private void cx_ValueChanged(object sender, EventArgs e)
		{
			this.center.X = Convert.ToDouble(this.cx.Value) * this.meter_rate;
			this.refresh(this.center, this.base_h);
			this.output_refresh();
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000A984 File Offset: 0x00008B84
		private void cy_ValueChanged(object sender, EventArgs e)
		{
			this.center.Y = Convert.ToDouble(this.cy.Value) * this.meter_rate;
			this.refresh(this.center, this.base_h);
			this.output_refresh();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000A9D4 File Offset: 0x00008BD4
		private void cz_ValueChanged(object sender, EventArgs e)
		{
			this.center.Z = Convert.ToDouble(this.cz.Value) * this.meter_rate;
			this.refresh(this.center, this.base_h);
			this.output_refresh();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000AA24 File Offset: 0x00008C24
		private void Input_Load(object sender, EventArgs e)
		{
			this.output_refresh();
			this.cx.Maximum = 99999999m;
			this.cx.Minimum = -99999999m;
			this.cy.Maximum = 99999999m;
			this.cy.Minimum = -99999999m;
			this.cz.Maximum = 99999999m;
			this.cz.Minimum = -99999999m;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000AAC0 File Offset: 0x00008CC0
		private void LockHeight_Click(object sender, EventArgs e)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			double height = Convert.ToDouble(this.BaseHeight.Value) * this.meter_rate;
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			for (uint i = 0U; i < agenda.GetCount(); i += 1U)
			{
				bool flag = agenda.GetEntry(i).ElementType != MSElementType.Line;
				if (flag)
				{
					MessageBox.Show("底面必须由直线构成。");
					return;
				}
			}
			for (uint j = 0U; j < agenda.GetCount(); j += 1U)
			{
				LineElement line = agenda.GetEntry(j) as LineElement;
				DSegment3d seg;
				line.GetCurveVector().GetAt(0).TryGetLine(out seg);
				DPoint3d start_point = seg.StartPoint;
				DPoint3d end_point = seg.EndPoint;
				DPoint3d p = DPoint3d.Zero;
				DPoint3d p2 = DPoint3d.Zero;
				p.X = start_point.X;
				p.Y = start_point.Y;
				p.Z = height;
				p2.X = end_point.X;
				p2.Y = end_point.Y;
				p2.Z = height;
				DSegment3d seg_height = new DSegment3d(p, p2);
				LineElement line_height = new LineElement(dgnModel, null, seg_height);
				line_height.AddToModel();
				line.DeleteFromModel();
			}
			this.base_h = Convert.ToDouble(this.BaseHeight.Value);
			this.refresh(this.center, this.base_h);
			this.output_refresh();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000AC53 File Offset: 0x00008E53
		private void LockPoint_Click(object sender, EventArgs e)
		{
			ChoosePoint.InstallNewInstance(this.meter_rate, ref this.cx, ref this.cy, ref this.cz);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000AC74 File Offset: 0x00008E74
		private void SendPoint_Click(object sender, EventArgs e)
		{
			this.center.X = Convert.ToDouble(this.cx.Value) * this.meter_rate;
			this.center.Y = Convert.ToDouble(this.cy.Value) * this.meter_rate;
			this.center.Z = Convert.ToDouble(this.cz.Value) * this.meter_rate;
			this.refresh(this.center, this.base_h);
			this.output_refresh();
		}

		// Token: 0x04000066 RID: 102
		private DPoint3d center = new DPoint3d(0.0, 0.0, 0.0);

		// Token: 0x04000067 RID: 103
		private double base_h = 100.0;

		// Token: 0x04000068 RID: 104
		private double meter_rate = 100.0;

		// Token: 0x0200001D RID: 29
		// (Invoke) Token: 0x060000C9 RID: 201
		public delegate void RefreshEvent(DPoint3d center_r, double bh);
	}

	internal class ChoosePoint : DgnElementSetTool
	{
		// Token: 0x0600006E RID: 110 RVA: 0x0000BA1F File Offset: 0x00009C1F
		public ChoosePoint(int toolId, int prompt) : base(toolId, prompt)
		{
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000BA2C File Offset: 0x00009C2C
		public static void InstallNewInstance(double r, ref NumericUpDown toolx, ref NumericUpDown tooly, ref NumericUpDown toolz)
		{
			new ChoosePoint(0, 0)
			{
				tool_center = DPoint3d.Zero,
				nx = toolx,
				ny = tooly,
				nz = toolz,
				rate = r
			}.InstallTool();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000BA74 File Offset: 0x00009C74
		protected override void OnPostInstall()
		{
			string tips = "请选择锚点:";
			NotificationManager.OutputPrompt(tips);
			this.tool_center = DPoint3d.Zero;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000BA9C File Offset: 0x00009C9C
		public override StatusInt OnElementModify(Element element)
		{
			return StatusInt.Error;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000BAB4 File Offset: 0x00009CB4
		protected override bool OnDataButton(DgnButtonEvent ev)
		{
			bool flag = this.tool_center == DPoint3d.Zero;
			if (flag)
			{
				this.tool_center = ev.Point;
				this.nx.Value = Convert.ToDecimal(this.tool_center.X / this.rate);
				this.ny.Value = Convert.ToDecimal(this.tool_center.Y / this.rate);
				this.nz.Value = Convert.ToDecimal(this.tool_center.Z / this.rate);
			}
			else
			{
				this.ExitTool();
			}
			return true;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000BB5C File Offset: 0x00009D5C
		protected override bool OnResetButton(DgnButtonEvent ev)
		{
			this.ExitTool();
			return true;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000BB76 File Offset: 0x00009D76
		protected override void OnRestartTool()
		{
			ChoosePoint.InstallNewInstance(this.rate, ref this.nx, ref this.ny, ref this.nz);
		}

		// Token: 0x0400007B RID: 123
		public DPoint3d tool_center;

		// Token: 0x0400007C RID: 124
		private NumericUpDown nx;

		// Token: 0x0400007D RID: 125
		private NumericUpDown ny;

		// Token: 0x0400007E RID: 126
		private NumericUpDown nz;

		// Token: 0x0400007F RID: 127
		private double rate;
	}
}
