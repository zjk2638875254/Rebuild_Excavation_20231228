using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using Bentley.MstnPlatformNET.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeshExcavationRebuild
{
    public partial class FormSlice : Form
    {
		public FormSlice(long[] MeshEles)
		{
			InitializeComponent();
			this.target_id = MeshEles;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00005A8C File Offset: 0x00003C8C
		private void CreateMesh_Click(object sender, EventArgs e)
		{
			double len = Convert.ToDouble(this.WidthMeter.Value);
			double h = Convert.ToDouble(this.HeightMeter.Value);
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			bool flag = agenda.GetCount() != 1U || agenda.GetEntry(0U).ElementType != MSElementType.Line;
			if (flag)
			{
				MessageBox.Show("请选择剖面所在位置的直线");
			}
			else
			{
				LineElement line = agenda.GetEntry(0U) as LineElement;
				this.create_mesh(line, len, h);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00005B14 File Offset: 0x00003D14
		private void create_mesh(LineElement line, double length, double height)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			double meter_rate = Session.Instance.GetActiveDgnModel().GetModelInfo().UorPerMeter;
			DSegment3d seg;
			line.GetCurveVector().GetAt(0).TryGetLine(out seg);
			DPoint3d sp = seg.StartPoint;
			DPoint3d ep = seg.EndPoint;
			DVector3d vl = new DVector3d(ep.Y - sp.Y, sp.X - ep.X, 0.0);
			double mode_vl = Math.Sqrt(vl.X * vl.X + vl.Y * vl.Y);
			vl.X = vl.X / mode_vl * length * meter_rate;
			vl.Y = vl.Y / mode_vl * length * meter_rate;
			DPoint3d p_high = new DPoint3d(sp.X + vl.X, sp.Y + vl.Y, sp.Z + height * meter_rate);
			DPoint3d p_high2 = new DPoint3d(sp.X, sp.Y, sp.Z + height * meter_rate);
			DPoint3d p_high3 = new DPoint3d(ep.X + vl.X, ep.Y + vl.Y, sp.Z + height * meter_rate);
			DPoint3d p_high4 = new DPoint3d(ep.X, ep.Y, ep.Z + height * meter_rate);
			DPoint3d p_low = new DPoint3d(sp.X + vl.X, sp.Y + vl.Y, sp.Z - height * meter_rate);
			DPoint3d p_low2 = new DPoint3d(sp.X, sp.Y, sp.Z - height * meter_rate);
			DPoint3d p_low3 = new DPoint3d(ep.X + vl.X, ep.Y + vl.Y, sp.Z - height * meter_rate);
			DPoint3d p_low4 = new DPoint3d(ep.X, ep.Y, ep.Z - height * meter_rate);
			IList<DPoint3d> pos = new List<DPoint3d>();
			pos.Add(p_high);
			pos.Add(p_high2);
			pos.Add(p_high3);
			pos.Add(p_high4);
			pos.Add(p_low);
			pos.Add(p_low2);
			pos.Add(p_low3);
			pos.Add(p_low4);
			PolyfaceHeader polyface = new PolyfaceHeader();
			polyface.Point = pos;
			polyface.ActivateVectorsForIndexing(polyface);
			List<int> indices = new List<int>();
			indices.Add(1);
			indices.Add(2);
			indices.Add(4);
			indices.Add(3);
			polyface.AddIndexedFacet(indices, null, null, indices);
			indices.Clear();
			indices.Add(7);
			indices.Add(8);
			indices.Add(6);
			indices.Add(5);
			polyface.AddIndexedFacet(indices, null, null, indices);
			indices.Clear();
			indices.Add(1);
			indices.Add(5);
			indices.Add(6);
			indices.Add(2);
			polyface.AddIndexedFacet(indices, null, null, indices);
			indices.Clear();
			indices.Add(3);
			indices.Add(4);
			indices.Add(8);
			indices.Add(7);
			polyface.AddIndexedFacet(indices, null, null, indices);
			indices.Clear();
			indices.Add(1);
			indices.Add(3);
			indices.Add(7);
			indices.Add(5);
			polyface.AddIndexedFacet(indices, null, null, indices);
			indices.Clear();
			indices.Add(2);
			indices.Add(6);
			indices.Add(8);
			indices.Add(4);
			polyface.AddIndexedFacet(indices, null, null, indices);
			indices.Clear();
			MeshHeaderElement mesh = new MeshHeaderElement(dgnModel, null, polyface);
			mesh.AddToModel();
			long mesh_id = mesh.ElementId;
			cut_mesh(mesh_id);
		}

		private void cut_mesh(long mesh)
        {
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			for(int i=0;i<target_id.Length;i++)
				this.c_mesh(mesh, target_id[i]);
			Element mesh_ele = dgnModel.FindElementById((ElementId)mesh);
			mesh_ele.DeleteFromModel();
			SelectionSetManager.EmptyAll();
			for (int i = 0; i < target_id.Length; i++)
            {
				Element ele = dgnModel.FindElementById((ElementId)target_id[i]);
				SelectionSetManager.AddElement(ele, dgnModel);
            }
			Session.Instance.Keyin("MDL LOAD IsolateSelected");
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00005F34 File Offset: 0x00004134
		private void FormSlice_Load(object sender, EventArgs e)
		{
			this.WidthMeter.Value = 800m;
			this.HeightMeter.Value = 400m;
		}

		private void GetLine_Click(object sender, EventArgs e)
		{
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			bool flag = agenda.GetCount() != 1U || agenda.GetEntry(0U).ElementType != MSElementType.MeshHeader;
			if (flag)
			{
				MessageBox.Show("类型不对");
			}
			else
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				Bentley.Interop.MicroStationDGN.Point3d P = default(Bentley.Interop.MicroStationDGN.Point3d);
				P.X = 0.0;
				P.Y = 0.0;
				P.Z = 0.0;
				Session.Instance.Keyin("FACET EXTRACTBOUNDARY");
				Utilities.ComApp.SetCExpressionValue("extractBoundarySettings.outputType", 0, "MESH");
				Utilities.ComApp.SetCExpressionValue("extractBoundarySettings.extractMode", 1, "MESH");
				Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00006120 File Offset: 0x00004320
		private void c_mesh(long eleid1, long eleid2)
		{
			Bentley.Interop.MicroStationDGN.Element mesh = Utilities.ComApp.ActiveModelReference.GetElementByID(ref eleid1);
			long elmdscrp = mesh.MdlElementDescrP(false);
			Bentley.Interop.MicroStationDGN.Element mesh2 = Utilities.ComApp.ActiveModelReference.GetElementByID(ref eleid2);
			long elmdscrp2 = mesh2.MdlElementDescrP(false);
			bool flag = elmdscrp != 0L && elmdscrp2 != 0L;
			if (flag)
			{
				long elmdscrp3 = ImportNativeCode.mdlPop_elementDescrFromElementDescrBoolOp(mesh.MdlElementDescrP(false), mesh2.MdlElementDescrP(false), 0L, 0, true, true, false, false, false);
				bool flag2 = elmdscrp3 != 0L;
				if (flag2)
				{
					Bentley.Interop.MicroStationDGN.Element mesh3 = Utilities.ComApp.MdlCreateElementFromElementDescrP(elmdscrp3);
					Utilities.ComApp.ActiveModelReference.AddElement(mesh3);
				}
			}
		}

		// Token: 0x04000038 RID: 56
		private long[] target_id = { };
	}

	public class ImportNativeCode
	{
		// Token: 0x0600001F RID: 31
		[DllImport("ustation.dll")]
		public static extern long mdlPop_elementDescrFromElementDescrBoolOp(long pDescr0, long pDescr1, long pTemplate, int boolType, bool removeCoplanarEdges, bool removeColinearVertices, bool setCookieCutter, bool imprintOnly, bool separateShells);
	}
}
