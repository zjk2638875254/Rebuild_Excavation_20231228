using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeshExcavationRebuild
{
    class Commands
    {
		public static void HideEle(string unparsed)
		{
			Session.Instance.Keyin("MDL LOAD IsolateSelected");
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000097EC File Offset: 0x000079EC
		public static void ChooseEle(string unparsed)
		{
			Session.Instance.Keyin("MDL KEYIN PSELECT CHOOSE ELEMENT");
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00009800 File Offset: 0x00007A00
		public static void Func_Slope(string unparsed)
		{
			FormSlope SlopeWin = new FormSlope(Commands.center, Commands.base_h, Commands.meter_rate);
			SlopeWin.Show();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000982C File Offset: 0x00007A2C
		public static void Func_ConvertArc(string unparsed)
		{
			FormConvertArc CA = new FormConvertArc(Commands.meter_rate);
			CA.Show();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000984C File Offset: 0x00007A4C
		public static void Func_LineMerge(string unparsed)
		{
			MeshExcavationRebuild.Func_Slope.Line_Merge();
		}

		public static void Func_LineCalculate(string unparsed)
		{
			MeshExcavationRebuild.Func_Bentley.Line_Calculate();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00009855 File Offset: 0x00007A55
		public static void RefreshForm(DPoint3d center_r, double bh)
		{
			Commands.center.X = center_r.X;
			Commands.center.Y = center_r.Y;
			Commands.center.Z = center_r.Z;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00009890 File Offset: 0x00007A90
		public static void input(string unparsed)
		{
			FormInit input_data = new FormInit(Commands.center, Commands.base_h, Commands.meter_rate);
			input_data.Show();
			input_data.refresh += Commands.RefreshForm;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000098D0 File Offset: 0x00007AD0
		public static void Func_MakeBody(string unparsed)
		{
			FormBody BodyWin = new FormBody(Commands.meter_rate);
			BodyWin.Show();
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000098F0 File Offset: 0x00007AF0
		public static void Line_Mesh(string unparsed)
		{
			long id = 0L;
			Func_Bentley.HasLine_Mesh(ref id);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00009909 File Offset: 0x00007B09
		public static void Line_Surfance(string unparsed)
		{
			Func_Body.buttom_and_top();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00009914 File Offset: 0x00007B14
		public static void Func_Tag(string unparsed)
		{
			FormTag TagWin = new FormTag(Commands.center, Commands.meter_rate, Commands.base_h);
			TagWin.Show();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00009940 File Offset: 0x00007B40
		public static void Func_Engineer(string unparsed)
		{
			FormEngineer EngineerWin = new FormEngineer();
			EngineerWin.Show();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000995C File Offset: 0x00007B5C
		public static void Func_AutoView(string unparsed)
		{
			FormEightView EngineerWin = new FormEightView(Commands.meter_rate);
			EngineerWin.Show();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000997C File Offset: 0x00007B7C
		public static void Func_GetLine(string unparsed)
		{
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			long[] mesh_eles = new long[agenda.GetCount()];
			for(uint i=0;i<agenda.GetCount();i++)
            {
				if (agenda.GetEntry(i).ElementType != MSElementType.MeshHeader)
				{
					MessageBox.Show("请选择需要剖切的面");
					return;
				}
				else
					mesh_eles[i] = agenda.GetEntry(i).ElementId;
            }
			FormSlice FormSlice = new FormSlice(mesh_eles);
			FormSlice.Show();
		}

		// Token: 0x04000054 RID: 84
		public static DPoint3d center = new DPoint3d(0.0, 0.0, 0.0);

		// Token: 0x04000055 RID: 85
		public static double base_h = 0.0;

		// Token: 0x04000056 RID: 86
		public static double meter_rate = Session.Instance.GetActiveDgnModel().GetModelInfo().UorPerMeter;
	}
}
