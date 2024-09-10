using System;
using System.Windows.Forms;

using Bentley.ECObjects.Schema;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Constraint2d;
using Bentley.DgnPlatformNET.DgnEC;
using Bentley.DgnPlatformNET.Elements;
using Bentley.ECObjects.Instance;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using Bentley.MstnPlatformNET.InteropServices;

namespace MeshExcavationRebuild
{
	// Token: 0x02000008 RID: 8
	internal class Func_Bentley
	{
		// Token: 0x0600002A RID: 42 RVA: 0x000073E8 File Offset: 0x000055E8
		public static void HasLine_Mesh(ref long ele_id)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			Bentley.Interop.MicroStationDGN.Point3d P = new Bentley.Interop.MicroStationDGN.Point3d();
			P.X = 0.0;
			P.Y = 0.0;
			P.Z = 0.0;
			Session.Instance.Keyin("FACET TRIANGULATE CONTOURS");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.booleanOp.meshContoursExpand", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.booleanOp.meshKeepContours", 1, "MESH");
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Bentley.Interop.MicroStationDGN.Element MSDgn_ele = Utilities.ComApp.ActiveModelReference.GetLastValidGraphicalElement();
			ele_id = MSDgn_ele.ID64;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000074E8 File Offset: 0x000056E8
		public static void NotHasLine_Mesh(ref long ele_id)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			Bentley.Interop.MicroStationDGN.Point3d P = new Bentley.Interop.MicroStationDGN.Point3d();
			P.X = 0.0;
			P.Y = 0.0;
			P.Z = 0.0;
			Session.Instance.Keyin("FACET TRIANGULATE CONTOURS");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.booleanOp.meshContoursExpand", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.booleanOp.meshKeepContours", 0, "MESH");
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Bentley.Interop.MicroStationDGN.Element MSDgn_ele = Utilities.ComApp.ActiveModelReference.GetLastValidGraphicalElement();
			ele_id = MSDgn_ele.ID64;
		}

		public static void Line_Calculate()
        {
			Bentley.Interop.MicroStationDGN.Point3d P = new Bentley.Interop.MicroStationDGN.Point3d();
			P.X = 0.0;
			P.Y = 0.0;
			P.Z = 0.0;
			Utilities.ComApp.SetCExpressionValue("tcb->chamfer_dist1", 0, "");
			Utilities.ComApp.SetCExpressionValue("tcb->chamfer_dist2", 0, "");
			Session.Instance.Keyin("CHAMFER");
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000075E8 File Offset: 0x000057E8
		public static void Mesh_Union(ref long ele_id)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			Bentley.Interop.MicroStationDGN.Point3d P = new Bentley.Interop.MicroStationDGN.Point3d();
			P.X = 0.0;
			P.Y = 0.0;
			P.Z = 0.0;
			Session.Instance.Keyin("FACET BOOLEAN INTERSECT");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.facet.intersectKeepOriginals", 0, "MESH");
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Bentley.Interop.MicroStationDGN.Element MSDgn_ele = Utilities.ComApp.ActiveModelReference.GetLastValidGraphicalElement();
			ele_id = MSDgn_ele.ID64;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000076CC File Offset: 0x000058CC
		public static void CallBack()
		{
			Session.Instance.Keyin("undo");
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000076E0 File Offset: 0x000058E0
		public static void GetVolum(double meter_rate, Bentley.DgnPlatformNET.Elements.Element ele, double height)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			Bentley.Interop.MicroStationDGN.Point3d P = new Bentley.Interop.MicroStationDGN.Point3d();
			P.X = 0.0;
			P.Y = 0.0;
			P.Z = 0.0;
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.EmptyAll();
			SelectionSetManager.AddElement(ele, dgnModel);
			Session.Instance.Keyin("FACET EXTRUDEVOLUME");
			Utilities.ComApp.SetCExpressionValue("extrudeVolumeSettings.extrudeVolumeMode", 0, "MESH");
			Session.Instance.Keyin("FACET EXTRUDEVOLUME");
			Utilities.ComApp.SetCExpressionValue("extrudeVolumeSettings.controlDirection", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("extrudeVolumeSettings.isFullDynamic", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("extrudeVolumeSettings.createTargetKeepOriginal", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("extrudeVolumeSettings.outputOuterBoundaryLineString", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("extrudeVolumeSettings.lockHeight", -1, "MESH");
			Utilities.ComApp.SetCExpressionValue("extrudeVolumeSettings.height", height * meter_rate, "MESH");
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00007874 File Offset: 0x00005A74
		public static void Mesh_Sub(ref long ele_id)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			Bentley.Interop.MicroStationDGN.Point3d P = new Bentley.Interop.MicroStationDGN.Point3d();
			P.X = 0.0;
			P.Y = 0.0;
			P.Z = 0.0;
			Session.Instance.Keyin("FACET BOOLEAN SUBTRACT");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.trimCurve.meshBoolean2ndAsTrimmer", 1, "MESH");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.facet.subtractKeepOriginals", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.facet.subtractSplit", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.facet.boolReverse2", 0, "MESH");
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Bentley.Interop.MicroStationDGN.Element MSDgn_ele = Utilities.ComApp.ActiveModelReference.GetLastValidGraphicalElement();
			ele_id = MSDgn_ele.ID64;
			Bentley.DgnPlatformNET.Elements.Element block_ele = dgnModel.FindElementById((ElementId)ele_id);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00007A08 File Offset: 0x00005C08
		public static void Get_Line()
		{
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			bool flag = agenda.GetCount() != 1U;
			if (flag)
			{
				MessageBox.Show("Please Choose 开挖区");
			}
			else
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				Bentley.Interop.MicroStationDGN.Point3d P = new Bentley.Interop.MicroStationDGN.Point3d();
				P.X = 0.0;
				P.Y = 0.0;
				P.Z = 0.0;
				Session.Instance.Keyin("FACET EXTRACTBOUNDARY");
				Utilities.ComApp.SetCExpressionValue("extractBoundarySettings.outputType", 0, "MESH");
				Utilities.ComApp.SetCExpressionValue("extractBoundarySettings.extractMode", 0, "MESH");
				Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
				Bentley.DgnPlatformNET.Elements.Element ele = agenda.GetEntry(0U);
				ele.DeleteFromModel();
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00007B08 File Offset: 0x00005D08
		public static void Combine_Surfance(ref long ele_id)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			Bentley.Interop.MicroStationDGN.Point3d P = new Bentley.Interop.MicroStationDGN.Point3d();
			P.X = 0.0;
			P.Y = 0.0;
			P.Z = 0.0;
			Session.Instance.Keyin("CONSTRUCT STITCH");
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Bentley.Interop.MicroStationDGN.Element MSDgn_ele = Utilities.ComApp.ActiveModelReference.GetLastValidGraphicalElement();
			ele_id = MSDgn_ele.ID64;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00007BD4 File Offset: 0x00005DD4
		public static void Ele_To_Mesh(ref long ele_id)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			Bentley.Interop.MicroStationDGN.Point3d P = new Bentley.Interop.MicroStationDGN.Point3d();
			P.X = 0.0;
			P.Y = 0.0;
			P.Z = 0.0;
			Session.Instance.Keyin("FACET CREATE");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.facet.lockChordTol", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.facet.lockAngleTol", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.facet.lockMaxEdgeLength", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.facet.lockMaxSides", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("tcb->ms3DToolSettings.facet.keepOriginal", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("pFacetControls->smoothTriangulation", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("pFacetControls->includeParams", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("pFacetControls->includeNormals", 0, "MESH");
			Utilities.ComApp.SetCExpressionValue("pFacetControls->hideSmoothEdges", 0, "MESH");
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Utilities.ComApp.CadInputQueue.SendDataPoint(ref P, Utilities.ComApp.ActiveDesignFile.Views[1], 0);
			Bentley.Interop.MicroStationDGN.Element MSDgn_ele = Utilities.ComApp.ActiveModelReference.GetLastValidGraphicalElement();
			ele_id = MSDgn_ele.ID64;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00007D90 File Offset: 0x00005F90
		public static void Mesh_Bool(long eleid1, long eleid2)
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
	}
}
