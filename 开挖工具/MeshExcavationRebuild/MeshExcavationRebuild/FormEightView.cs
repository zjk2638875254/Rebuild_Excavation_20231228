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
    public partial class FormEightView : Form
    {
        public FormEightView(double MR)
        {
			this.meter_rate = MR;
			InitializeComponent();
        }

		// Token: 0x06000004 RID: 4 RVA: 0x000020A8 File Offset: 0x000002A8
		private void CreateSection_Click(object sender, EventArgs e)
		{
			try
			{
				DPoint3d p = new DPoint3d(Convert.ToDouble(this.P1X.Value) * this.meter_rate, Convert.ToDouble(this.P1Y.Value) * this.meter_rate, Convert.ToDouble(this.P1Z.Value) * this.meter_rate);
				DPoint3d p2 = new DPoint3d(Convert.ToDouble(this.P2X.Value) * this.meter_rate, Convert.ToDouble(this.P2Y.Value) * this.meter_rate, Convert.ToDouble(this.P2Z.Value) * this.meter_rate);
				DPoint3d p3 = new DPoint3d(Convert.ToDouble(this.P3X.Value) * this.meter_rate, Convert.ToDouble(this.P3Y.Value) * this.meter_rate, Convert.ToDouble(this.P3Z.Value) * this.meter_rate);
				DPoint3d p4 = new DPoint3d(Convert.ToDouble(this.P4X.Value) * this.meter_rate, Convert.ToDouble(this.P4Y.Value) * this.meter_rate, Convert.ToDouble(this.P4Z.Value) * this.meter_rate);
				DPoint3d[] pos = new DPoint3d[]
				{
					p,
					p2,
					p3,
					p4
				};
				this.CreateBeamDrawing(pos);
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log("八视图错误:\r\n" + ex.ToString());
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002254 File Offset: 0x00000454
		private void Form_EightView_Load(object sender, EventArgs e)
		{
			decimal max_num = 10000000m;
			this.P1X.Maximum = max_num;
			this.P1X.Minimum = -1m * max_num;
			this.P1Y.Maximum = max_num;
			this.P1Y.Minimum = -1m * max_num;
			this.P1Z.Maximum = max_num;
			this.P1Z.Minimum = -1m * max_num;
			this.P2X.Maximum = max_num;
			this.P2X.Minimum = -1m * max_num;
			this.P2Y.Maximum = max_num;
			this.P2Y.Minimum = -1m * max_num;
			this.P2Z.Maximum = max_num;
			this.P2Z.Minimum = -1m * max_num;
			this.P3X.Maximum = max_num;
			this.P3X.Minimum = -1m * max_num;
			this.P3Y.Maximum = max_num;
			this.P3Y.Minimum = -1m * max_num;
			this.P3Z.Maximum = max_num;
			this.P3Z.Minimum = -1m * max_num;
			this.P4X.Maximum = max_num;
			this.P4X.Minimum = -1m * max_num;
			this.P4Y.Maximum = max_num;
			this.P4Y.Minimum = -1m * max_num;
			this.P4Z.Maximum = max_num;
			this.P4Z.Minimum = -1m * max_num;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002420 File Offset: 0x00000620
		private NamedBoundary CreateNamedBoundary(string boundaryGroupName, string boundaryName)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			NamedBoundaryGroup boundaryGroup = NamedBoundaryGroup.CreateNamedBoundaryGroup(Session.Instance.GetActiveDgnModel(), boundaryGroupName, "");
			NamedBoundary boundary = new NamedBoundary();
			boundary.ModelRef = dgnModel;
			boundary.Name = boundaryName;
			boundary.DrawingScale = 1.0;
			boundary.Save();
			boundaryGroup.InsertBoundary(boundary);
			boundaryGroup.WriteToFile();
			return boundary;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002490 File Offset: 0x00000690
		private ViewInformation ZoomElementView(out ShapeElement shape, DPoint3d[] pos)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
			double max_x = 0.0;
			double min_x = 0.0;
			double max_y = 0.0;
			double min_y = 0.0;
			double max_z = 0.0;
			double min_z = 0.0;
			shape = new ShapeElement(dgnModel, null, pos);
			for (int i = 0; i < pos.Length; i++)
			{
				bool flag = pos[i].X > max_x;
				if (flag)
				{
					max_x = pos[i].X;
				}
				bool flag2 = pos[i].X < min_x;
				if (flag2)
				{
					min_x = pos[i].X;
				}
				bool flag3 = pos[i].Y > max_y;
				if (flag3)
				{
					max_y = pos[i].Y;
				}
				bool flag4 = pos[i].Y < min_y;
				if (flag4)
				{
					min_y = pos[i].Y;
				}
				bool flag5 = pos[i].Z > max_z;
				if (flag5)
				{
					max_z = pos[i].Z;
				}
				bool flag6 = pos[i].Z < min_z;
				if (flag6)
				{
					min_z = pos[i].Z;
				}
			}
			double rL = max_x - min_x;
			double rW = max_y - min_y;
			double rH = max_z - min_z;
			ViewGroupCollection viewcoll = dgnFile.GetViewGroups();
			ViewGroup viewgroup = viewcoll.GetActive();
			int viewnumber;
			viewgroup.FindFirstOpenView(out viewnumber);
			ViewInformation viewinfo = viewgroup.GetViewInformation(viewnumber);
			DPoint3d delta = DPoint3d.FromXYZ(rL, rW, rH);
			DMatrix3d rotmax = DMatrix3d.Identity;
			DPoint3d low_point = new DPoint3d(min_x, min_y, min_z);
			viewinfo.SetGeometry(low_point, delta, rotmax);
			return viewinfo;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002670 File Offset: 0x00000870
		private NamedView CreateNamedView(ShapeElement shape, ViewInformation viewInfo, string namedViewName)
		{
			DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
			NamedView view = new NamedView(dgnFile, namedViewName);
			view.SetClipElement(shape);
			view.SetViewInfo(viewInfo);
			view.WriteToFile();
			return view;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000026B0 File Offset: 0x000008B0
		private DgnModel CreateDrawingModel(string name, NamedView namedView, StandardView viewMode)
		{
			DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
			DgnModelStatus error;
			DgnModel drawingModel = dgnFile.CreateNewModel(out error, name, DgnModelType.Drawing, false, null);
			DgnAttachment refToCreate = drawingModel.CreateDgnAttachment(dgnFile.GetDocument().GetMoniker(), name);
			refToCreate.ApplyNamedView(namedView.Name, 1.0, 1.0, new ApplyViewClipOptions(), true, viewMode);
			refToCreate.WriteToModel(true);
			refToCreate.NestDepth = 99;
			refToCreate.SetLocateLock(true);
			refToCreate.SetSnapLock(true);
			return drawingModel;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002738 File Offset: 0x00000938
		private void CreateBeamDrawing(DPoint3d[] pos)
		{
			string time_tag = string.Concat(new string[]
			{
				DateTime.Now.Month.ToString(),
				DateTime.Now.Day.ToString(),
				"_",
				DateTime.Now.Hour.ToString(),
				"_",
				DateTime.Now.Minute.ToString(),
				"_",
				DateTime.Now.Second.ToString()
			});
			Dictionary<int, string> view_name = new Dictionary<int, string>();
			view_name[1] = "Top";
			view_name[2] = "Bottom";
			view_name[3] = "Left";
			view_name[4] = "Right";
			view_name[5] = "Front";
			view_name[6] = "Back";
			view_name[7] = "Iso";
			view_name[8] = "RightIso";
			for (int i = 1; i < 9; i++)
			{
				string sheetModelName = time_tag + "Model";
				string namedViewName = time_tag + "View";
				string groupName = time_tag + "Group";
				string boundaryName = time_tag + "Bound";
				sheetModelName = view_name[i] + sheetModelName;
				namedViewName = view_name[i] + namedViewName;
				groupName = view_name[i] + groupName;
				boundaryName = view_name[i] + boundaryName;
				StandardView stView = StandardView.Top;
				switch (i)
				{
					case 1:
						stView = StandardView.Top;
						break;
					case 2:
						stView = StandardView.Bottom;
						break;
					case 3:
						stView = StandardView.Left;
						break;
					case 4:
						stView = StandardView.Right;
						break;
					case 5:
						stView = StandardView.Front;
						break;
					case 6:
						stView = StandardView.Back;
						break;
					case 7:
						stView = StandardView.Iso;
						break;
					case 8:
						stView = StandardView.RightIso;
						break;
				}
				NamedBoundary boundary = this.CreateNamedBoundary(groupName, boundaryName);
				ShapeElement shape;
				ViewInformation viewInfo = this.ZoomElementView(out shape, pos);
				NamedView view = this.CreateNamedView(shape, viewInfo, namedViewName);
				DgnModel drawingModel = this.CreateDrawingModel(sheetModelName, view, stView);
			}
		}

		// Token: 0x04000002 RID: 2
		private double meter_rate;
	}
}
