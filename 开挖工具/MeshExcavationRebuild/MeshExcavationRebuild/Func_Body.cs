using System;
using System.Collections.Generic;
using System.Linq;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using self_define;

namespace MeshExcavationRebuild
{
	// Token: 0x02000009 RID: 9
	internal class Func_Body
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00007E3C File Offset: 0x0000603C
		public static bool buttom_and_top()
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				HashSet<long> surfances = new HashSet<long>();
				HashSet<long> buttom_lines = new HashSet<long>();
				for (uint i = 0U; i < agenda.GetCount(); i += 1U)
				{
					string s_value = "";
					Element high_ele = agenda.GetEntry(i);
					long sufance_id = 0L;
					while (EC17.find_property_string(high_ele, "基线", ref s_value))
					{
						Element low_ele = dgnModel.FindElementById((ElementId)Convert.ToInt64(s_value));
						bool flag = low_ele.ElementType == MSElementType.Line && high_ele.ElementType == MSElementType.Line;
						if (flag)
						{
							Func_Body.line_to_surfance(low_ele as LineElement, high_ele as LineElement, ref sufance_id);
						}
						high_ele = low_ele;
						surfances.Add(sufance_id);
					}
					buttom_lines.Add(high_ele.ElementId);
				}
				long res = 0L;
				bool flag2 = Func_Body.get_buttom(buttom_lines, ref res);
				surfances.Add(res);
				SelectionSetManager.EmptyAll();
				foreach (long id in surfances)
				{
					SelectionSetManager.AddElement(dgnModel.FindElementById((ElementId)id), dgnModel);
				}
				long res_id = 0L;
				Func_Bentley.Combine_Surfance(ref res_id);
				SelectionSetManager.EmptyAll();
				SelectionSetManager.AddElement(dgnModel.FindElementById((ElementId)res_id), dgnModel);
				Func_Bentley.Ele_To_Mesh(ref res_id);
				result = true;
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00008004 File Offset: 0x00006204
		private static bool get_buttom(HashSet<long> lines, ref long res_id)
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				HashSet<DPoint3d> unorder_points = new HashSet<DPoint3d>();
				foreach (long line_id in lines)
				{
					LineElement line = dgnModel.FindElementById((ElementId)line_id) as LineElement;
					DSegment3d seg;
					line.GetCurveVector().GetAt(0).TryGetLine(out seg);
					DPoint3d sp = new DPoint3d(seg.StartPoint);
					DPoint3d ep = new DPoint3d(seg.EndPoint);
					bool save_sp = true;
					bool save_ep = true;
					foreach (DPoint3d p in unorder_points)
					{
						bool flag = Math.Sqrt((sp.X - p.X) * (sp.X - p.X) + (sp.Y - p.Y) * (sp.Y - p.Y) + (sp.Z - p.Z) * (sp.Z - p.Z)) < 1.0;
						if (flag)
						{
							save_sp = false;
						}
						bool flag2 = Math.Sqrt((ep.X - p.X) * (ep.X - p.X) + (ep.Y - p.Y) * (ep.Y - p.Y) + (ep.Z - p.Z) * (ep.Z - p.Z)) < 1.0;
						if (flag2)
						{
							save_ep = false;
						}
					}
					bool flag3 = save_sp;
					if (flag3)
					{
						unorder_points.Add(sp);
					}
					bool flag4 = save_ep;
					if (flag4)
					{
						unorder_points.Add(ep);
					}
				}
				DPoint3d[] pos = new DPoint3d[unorder_points.Count];
				LineElement begin_line = dgnModel.FindElementById((ElementId)lines.ElementAt(0)) as LineElement;
				DSegment3d begin_seg;
				begin_line.GetCurveVector().GetAt(0).TryGetLine(out begin_seg);
				DPoint3d begin_sp = new DPoint3d(begin_seg.StartPoint);
				DPoint3d begin_ep = new DPoint3d(begin_seg.EndPoint);
				pos[0] = begin_sp;
				pos[1] = begin_ep;
				int i = 1;
				while (i < unorder_points.Count - 1)
				{
					foreach (long line_id2 in lines)
					{
						LineElement line2 = dgnModel.FindElementById((ElementId)line_id2) as LineElement;
						DSegment3d seg2;
						line2.GetCurveVector().GetAt(0).TryGetLine(out seg2);
						DPoint3d sp2 = new DPoint3d(seg2.StartPoint);
						DPoint3d ep2 = new DPoint3d(seg2.EndPoint);
						bool flag5 = Math.Sqrt((sp2.X - pos[i].X) * (sp2.X - pos[i].X) + (sp2.Y - pos[i].Y) * (sp2.Y - pos[i].Y) + (sp2.Z - pos[i].Z) * (sp2.Z - pos[i].Z)) < 1.0;
						if (flag5)
						{
							bool flag6 = Math.Sqrt((ep2.X - pos[i - 1].X) * (ep2.X - pos[i - 1].X) + (ep2.Y - pos[i - 1].Y) * (ep2.Y - pos[i - 1].Y) + (ep2.Z - pos[i - 1].Z) * (ep2.Z - pos[i - 1].Z)) > 1.0;
							if (flag6)
							{
								i++;
								pos[i] = ep2;
								Func_Init.Write_Log(string.Concat(new string[]
								{
									"P：",
									i.ToString(),
									" ",
									pos[i].X.ToString(),
									" ",
									pos[i].Y.ToString(),
									pos[i].Z.ToString(),
									"\r\n"
								}));
								break;
							}
						}
						bool flag7 = Math.Sqrt((ep2.X - pos[i].X) * (ep2.X - pos[i].X) + (ep2.Y - pos[i].Y) * (ep2.Y - pos[i].Y) + (ep2.Z - pos[i].Z) * (ep2.Z - pos[i].Z)) < 1.0;
						if (flag7)
						{
							bool flag8 = Math.Sqrt((sp2.X - pos[i - 1].X) * (sp2.X - pos[i - 1].X) + (sp2.Y - pos[i - 1].Y) * (sp2.Y - pos[i - 1].Y) + (sp2.Z - pos[i - 1].Z) * (sp2.Z - pos[i - 1].Z)) > 1.0;
							if (flag8)
							{
								i++;
								pos[i] = sp2;
								Func_Init.Write_Log(string.Concat(new string[]
								{
									"P：",
									i.ToString(),
									" ",
									pos[i].X.ToString(),
									" ",
									pos[i].Y.ToString(),
									pos[i].Z.ToString(),
									"\r\n"
								}));
								break;
							}
						}
					}
				}
				ShapeElement shape = new ShapeElement(dgnModel, null, pos);
				shape.AddToModel();
				res_id = shape.ElementId;
				result = true;
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00008750 File Offset: 0x00006950
		private static bool line_to_surfance(LineElement line1, LineElement line2, ref long ele_id)
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				double high = 0.0;
				double high2 = 0.0;
				double low = 0.0;
				double low2 = 0.0;
				bool flag = Func_Calculate.get_high(line1, ref high);
				bool flag2 = Func_Calculate.get_high(line2, ref high2);
				bool flag3 = Func_Calculate.get_low(line1, ref low);
				bool flag4 = Func_Calculate.get_low(line2, ref low2);
				bool flag5 = low != high || low2 != high2;
				if (flag5)
				{
					string output_message = "Func_Body:line_to_surfance:\r\n";
					output_message = string.Concat(new string[]
					{
						output_message,
						"high1:",
						high.ToString(),
						"   low1:",
						low.ToString(),
						"   high2:",
						high2.ToString(),
						"   low2:",
						low2.ToString(),
						"\r\n"
					});
					Func_Init.Write_Log(output_message);
					result = false;
				}
				else
				{
					DSegment3d seg;
					line1.GetCurveVector().GetAt(0).TryGetLine(out seg);
					DPoint3d sp = seg.StartPoint;
					DPoint3d ep = seg.EndPoint;
					DSegment3d seg2;
					line2.GetCurveVector().GetAt(0).TryGetLine(out seg2);
					DPoint3d sp2 = seg2.StartPoint;
					DPoint3d ep2 = seg2.EndPoint;
					bool flag6 = sp.X < ep.X;
					DPoint3d p;
					DPoint3d p2;
					DPoint3d p3;
					DPoint3d p4;
					if (flag6)
					{
						p = sp;
						p2 = ep;
						bool flag7 = sp2.X < ep2.X;
						if (flag7)
						{
							p3 = ep2;
							p4 = sp2;
						}
						else
						{
							p3 = sp2;
							p4 = ep2;
						}
					}
					else
					{
						p = ep;
						p2 = sp;
						bool flag8 = sp2.X < ep2.X;
						if (flag8)
						{
							p3 = ep2;
							p4 = sp2;
						}
						else
						{
							p3 = sp2;
							p4 = ep2;
						}
					}
					DSegment3d seg_ = new DSegment3d(p, p2);
					DSegment3d seg_2 = new DSegment3d(p2, p3);
					DSegment3d seg_3 = new DSegment3d(p3, p4);
					DSegment3d seg_4 = new DSegment3d(p4, p);
					LineElement line_ = new LineElement(dgnModel, null, seg_);
					LineElement line_2 = new LineElement(dgnModel, null, seg_2);
					LineElement line_3 = new LineElement(dgnModel, null, seg_3);
					LineElement line_4 = new LineElement(dgnModel, null, seg_4);
					ComplexShapeElement complexShape = new ComplexShapeElement(dgnModel, null);
					complexShape.AddComponentElement(line_);
					complexShape.AddComponentElement(line_2);
					complexShape.AddComponentElement(line_3);
					complexShape.AddComponentElement(line_4);
					complexShape.AddComponentComplete();
					complexShape.AddToModel();
					ele_id = complexShape.ElementId;
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
	}
}
