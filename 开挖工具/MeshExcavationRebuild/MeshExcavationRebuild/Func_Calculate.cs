using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using self_define;

namespace MeshExcavationRebuild
{
	// Token: 0x0200000A RID: 10
	internal class Func_Calculate
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00008A08 File Offset: 0x00006C08
		public static bool vol_500(Element ele, ref double vol, double meter_rate, double mesh_height)
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				Func_Bentley.GetVolum(meter_rate, ele, mesh_height);
				bool flag = Tag17.get_vol(ele, ref vol);
				Func_Bentley.CallBack();
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00008A60 File Offset: 0x00006C60
		public static bool get_low(Element ele, ref double low_z)
		{
			DPoint3d lowp = DPoint3d.Zero;
			bool result;
			try
			{
				DisplayableElement display_ele = ele as DisplayableElement;
				DRange3d range;
				display_ele.CalcElementRange(out range);
				low_z = range.Low.Z;
				result = true;
			}
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00008AB4 File Offset: 0x00006CB4
		public static bool get_high(Element ele, ref double high_z)
		{
			DPoint3d highp = DPoint3d.Zero;
			bool result;
			try
			{
				DisplayableElement display_ele = ele as DisplayableElement;
				DRange3d range;
				display_ele.CalcElementRange(out range);
				high_z = range.High.Z;
				result = true;
			}
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00008B08 File Offset: 0x00006D08
		public static bool reverse_mesh()
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				Element ele = agenda.GetEntry(0U);
				bool flag = ele.ElementType != MSElementType.MeshHeader;
				if (flag)
				{
					result = false;
				}
				else
				{
					MeshHeaderElement mesh = ele as MeshHeaderElement;
					PolyfaceHeader poly = mesh.GetMeshData();
					IEnumerable<int> points_index = poly.PointIndex;
					IEnumerable<DPoint3d> points = poly.Point;
					IList<DPoint3d> pos = new List<DPoint3d>();
					string t = "";
					for (int i = 0; i < points.Count<DPoint3d>(); i++)
					{
						pos.Add(points.ElementAt(i));
					}
					PolyfaceHeader new_polyface = new PolyfaceHeader();
					for (int j = 0; j < points_index.Count<int>(); j++)
					{
						int temp = points_index.ElementAt(j);
						t = t + points_index.ElementAt(j).ToString() + " ";
					}
					MessageBox.Show(t);
					result = true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00008C34 File Offset: 0x00006E34
		public static bool cut_linestring(LineStringElement lineString)
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				Dictionary<string, string[]> already_find = new Dictionary<string, string[]>();
				List<DPoint3d> points = new List<DPoint3d>();
				CurvePathQuery.ElementToCurveVector(lineString).GetAt(0).TryGetLineString(points);
				int sp_id = 0;
				int ep_id = 2;
				while (ep_id < points.Count)
				{
					while (Func_Calculate.CombineLineString(points[ep_id - 2], points[ep_id - 1], points[ep_id]) && ep_id < points.Count)
					{
						ep_id++;
					}
					DPoint3d[] small_line_points = new DPoint3d[ep_id - sp_id];
					for (int i = sp_id; i < ep_id; i++)
					{
						small_line_points[i - sp_id] = points[i];
					}
					LineStringElement small_line = new LineStringElement(dgnModel, null, small_line_points);
					small_line.AddToModel();
					Func_Slope.Revise_ele_level(small_line, "ExcavationMesh简化边界线");
					bool flag = ep_id < points.Count;
					if (flag)
					{
						sp_id = ep_id - 1;
						ep_id = sp_id + 2;
					}
				}
				lineString.DeleteFromModel();
				result = true;
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00008D7C File Offset: 0x00006F7C
		public static bool cut_by_vector(LineStringElement lineString, int para, ref List<long> lines)
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				Dictionary<string, string[]> already_find = new Dictionary<string, string[]>();
				List<DPoint3d> points = new List<DPoint3d>();
				CurvePathQuery.ElementToCurveVector(lineString).GetAt(0).TryGetLineString(points);
				int sp_id = 0;
				int ep_id = 3;
				while (ep_id < points.Count)
				{
					while (ep_id < points.Count)
					{
						int pd = sp_id + 2;
						while (pd < points.Count && Func_Calculate.IsSame(points[sp_id], points[sp_id + 1], points[pd]))
						{
							pd++;
						}
						ep_id = pd + 1;
						while (ep_id < points.Count && Func_Calculate.IsCommon(points[sp_id], points[sp_id + 1], points[pd], points[ep_id - 1], points[ep_id]))
						{
							ep_id++;
						}
						DPoint3d[] small_line_points = new DPoint3d[ep_id - sp_id];
						for (int i = sp_id; i < ep_id; i++)
						{
							small_line_points[i - sp_id] = points[i];
						}
						LineStringElement small_line = new LineStringElement(dgnModel, null, small_line_points);
						Func_Calculate.linestring_to_line(small_line, para, ref lines);
						bool flag = ep_id < points.Count;
						if (flag)
						{
							sp_id = ep_id - 1;
							ep_id = sp_id + 3;
						}
					}
				}
				lineString.DeleteFromModel();
				result = true;
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00008F20 File Offset: 0x00007120
		public static bool Area_Output(uint color_num)
		{
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			for (uint i = 0U; i < agenda.GetCount(); i += 1U)
			{
				Element ele = agenda.GetEntry(i);
				Element oldEle = Element.GetFromElementRef(ele.GetNativeElementRef());
				ElementPropertiesSetter elePropSet = new ElementPropertiesSetter();
				elePropSet.SetColor(color_num);
				elePropSet.Apply(ele);
				ele.ReplaceInModel(oldEle);
			}
			for (uint j = 0U; j < agenda.GetCount(); j += 1U)
			{
				Element ele2 = agenda.GetEntry(j);
				double area_single = 0.0;
				bool flag = Tag17.get_area(ele2, ref area_single);
				EC17.create_ec_double(ele2, "支护信息", "支护区号", color_num, "三维开挖工具_Mesh版");
				EC17.create_ec_double(ele2, "支护信息", "支护面积", area_single, "三维开挖工具_Mesh版");
			}
			return true;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00009000 File Offset: 0x00007200
		private static bool IsCommon(DPoint3d p1, DPoint3d p2, DPoint3d p3, DPoint3d btar, DPoint3d target)
		{
			bool result;
			try
			{
				double meter_rate = Session.Instance.GetActiveDgnModel().GetModelInfo().UorPerMeter;
				DVector3d v = new DVector3d(p1, p2);
				DVector3d v2 = new DVector3d(p2, p3);
				DVector3d v3 = new DVector3d(btar, target);
				double res = v.X * v2.Y * v3.Z + v.Y * v2.Z * v3.X + v.Z * v2.X * v3.Y;
				double res2 = v3.X * v2.Y * v.Z + v3.Y * v2.Z * v.X + v3.Z * v2.X * v.Y;
				double res3 = res - res2;
				bool flag = res3 < 30000.0 && res3 > -30000.0;
				if (flag)
				{
					Func_Init.Write_Log("same_line:" + res3.ToString() + "\r\n");
					result = true;
				}
				else
				{
					Func_Init.Write_Log("not_same:" + res3.ToString() + "\r\n");
					result = false;
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00009174 File Offset: 0x00007374
		private static bool IsSame(DPoint3d p1, DPoint3d p2, DPoint3d p3)
		{
			bool result;
			try
			{
				DVector3d v = new DVector3d(p1, p2);
				DVector3d v2 = new DVector3d(p2, p3);
				double res = v.Y * v2.Z - v.Z * v2.Y;
				double res2 = v.Z * v2.X - v.X * v2.Z;
				double res3 = v.X * v2.Y - v.Y * v2.X;
				bool flag = res <= 100.0 && res >= -100.0 && res2 <= 100.0 && res2 >= -100.0 && res3 <= 100.0 && res3 >= -100.0;
				if (flag)
				{
					Func_Init.Write_Log("Same_Direction\r\n");
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000928C File Offset: 0x0000748C
		private static bool CombineLineString(DPoint3d p1, DPoint3d p2, DPoint3d p3)
		{
			bool result;
			try
			{
				DVector3d v = new DVector3d(p1, p2);
				DVector3d v2 = new DVector3d(p2, p3);
				double res = v.X * v2.X + v.Y * v2.Y + v.Z * v2.Z;
				double mode = Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
				double mode2 = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);
				double valid = res / (mode * mode2);
				bool flag = valid == double.NaN || valid >= 1.0 || valid <= -1.0;
				if (flag)
				{
					result = true;
				}
				else
				{
					double angle = Math.Acos(res / (mode * mode2));
					bool flag2 = angle < 0.5235987755982988;
					if (flag2)
					{
						result = true;
					}
					else
					{
						MessageBox.Show(angle.ToString());
						result = false;
					}
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000093F4 File Offset: 0x000075F4
		private static bool linestring_to_line(LineStringElement lineString, int para, ref List<long> lines)
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				Dictionary<string, string[]> already_find = new Dictionary<string, string[]>();
				List<DPoint3d> points = new List<DPoint3d>();
				CurvePathQuery.ElementToCurveVector(lineString).GetAt(0).TryGetLineString(points);
				bool flag = points.Count < 3;
				if (flag)
				{
					DSegment3d seg = new DSegment3d(points[0], points[1]);
					LineElement line = new LineElement(dgnModel, null, seg);
					line.AddToModel();
					lines.Add(line.ElementId);
					result = true;
				}
				else
				{
					int sp_id = 0;
					int ep_id = 2;
					DVector3d original_v = new DVector3d(points[0], points[1]);
					while (ep_id < points.Count)
					{
						original_v = new DVector3d(points[sp_id], points[sp_id + 1]);
						DVector3d v_test = new DVector3d(points[ep_id - 2], points[ep_id - 1]);
						DVector3d v_test2 = new DVector3d(points[ep_id - 1], points[ep_id]);
						DVector3d v_new = new DVector3d(points[0], points[ep_id]);
						while (Func_Calculate.valculate_angle(v_test, v_test2, para) && Func_Calculate.valculate_angle(original_v, v_new, para))
						{
							ep_id++;
							bool flag2 = ep_id == points.Count;
							if (flag2)
							{
								break;
							}
							v_test = new DVector3d(points[ep_id - 2], points[ep_id - 1]);
							v_test2 = new DVector3d(points[ep_id - 1], points[ep_id]);
							v_new = new DVector3d(points[0], points[ep_id]);
						}
						DSegment3d seg2 = new DSegment3d(points[sp_id], points[ep_id - 1]);
						LineElement line2 = new LineElement(dgnModel, null, seg2);
						line2.AddToModel();
						lines.Add(line2.ElementId);
						Func_Slope.Revise_ele_level(line2, "ExcavationMesh简化边界线");
						sp_id = ep_id - 1;
						ep_id = sp_id + 2;
					}
					bool flag3 = sp_id < points.Count - 1;
					if (flag3)
					{
						DSegment3d seg3 = new DSegment3d(points[sp_id], points[points.Count - 1]);
						LineElement line3 = new LineElement(dgnModel, null, seg3);
						line3.AddToModel();
						lines.Add(line3.ElementId);
					}
					result = true;
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00009648 File Offset: 0x00007848
		private static bool valculate_angle(DVector3d v1, DVector3d v2, int para)
		{
			bool result;
			try
			{
				double res = v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
				double mode = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
				double mode2 = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);
				double valid = res / (mode * mode2);
				bool flag = valid == double.NaN || valid >= 1.0 || valid <= -1.0;
				if (flag)
				{
					result = true;
				}
				else
				{
					double angle = Math.Acos(res / (mode * mode2));
					bool flag2 = angle < 3.141592653589793 * (double)para / 180.0 || angle > 15.707963267948966 * (double)para / 180.0;
					if (flag2)
					{
						result = true;
					}
					else
					{
						Func_Init.Write_Log(angle.ToString() + "\r\n");
						result = false;
					}
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				result = false;
			}
			return result;
		}
	}
}
