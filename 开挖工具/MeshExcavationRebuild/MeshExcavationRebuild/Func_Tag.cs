using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
//using Bentley.Interop.MicroStationDGN;
using Bentley.MstnPlatformNET;
using Bentley.MstnPlatformNET.InteropServices;
using ExcelLib;
using self_define;

namespace MeshExcavationRebuild
{
	// Token: 0x02000012 RID: 18
	internal class Func_Tag
	{
		// Token: 0x06000088 RID: 136 RVA: 0x0000E9E0 File Offset: 0x0000CBE0
		private static bool RotateEle(Bentley.DgnPlatformNET.Elements.Element ele, DSegment3d seg, Angle angle1, Angle angle2)
		{
			try
			{
				DPoint3d base_point = new DPoint3d((seg.StartPoint.X + seg.EndPoint.X) / 2.0, (seg.StartPoint.Y + seg.EndPoint.Y) / 2.0, (seg.StartPoint.Z + seg.EndPoint.Z) / 2.0);
				DVector3d vz = new DVector3d(0.0, 0.0, 1.0);
				DTransform3d trans_xy = DTransform3d.FromRotationAroundLine(base_point, vz, angle1);
				TransformInfo transform = new TransformInfo(trans_xy);
				ele.ApplyTransform(transform);
				DPoint3d base_point2 = new DPoint3d((seg.StartPoint.X + seg.EndPoint.X) / 2.0, (seg.StartPoint.Y + seg.EndPoint.Y) / 2.0, (seg.StartPoint.Z + seg.EndPoint.Z) / 2.0);
				DVector3d vl = new DVector3d(seg.StartPoint, seg.EndPoint);
				DTransform3d trans_xz = DTransform3d.FromRotationAroundLine(base_point2, vl, angle2);
				TransformInfo transform2 = new TransformInfo(trans_xz);
				ele.ApplyTransform(transform2);
				ele.ReplaceInModel(ele);
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString() + "\r\n");
				return false;
			}
			return true;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0000EBBC File Offset: 0x0000CDBC
		private static bool CreateTagLine(DPoint3d p1, DPoint3d p2, ref ElementId line_id)
		{
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DSegment3d seg = new DSegment3d(p1, p2);
				LineElement line = new LineElement(dgnModel, null, seg);
				line.AddToModel();
				line_id = line.ElementId;
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString() + "\r\n");
				return false;
			}
			return true;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000EC34 File Offset: 0x0000CE34
		public static void Tag_All_Pobi(DPoint3d center_point, string style_name)
		{
			try
			{
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				for (uint i = 0U; i < agenda.GetCount(); i += 1U)
				{
					bool flag = agenda.GetEntry(i).ElementType == MSElementType.Line;
					if (flag)
					{
						LineElement line = agenda.GetEntry(i) as LineElement;
						DSegment3d seg;
						line.GetCurveVector().GetAt(0).TryGetLine(out seg);
						TagPobi(line, center_point, style_name);
						
						//Add_TagPobi(line, center_point, style_name, true, true);

						//Func_Tag.Tag_Pobi_Version3(line, center_point, style_name);
						Func_Tag.Tag_Pobi_Version3_text(line, center_point, style_name, true, true);
						Func_Tag.Tag_Pobi_Version3_text(line, center_point, style_name, true, false);
						Func_Tag.Tag_Pobi_Version3_text(line, center_point, style_name, false, true);
						Func_Tag.Tag_Pobi_Version3_text(line, center_point, style_name, false, false);
					}
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString() + "\r\n");
			}
		}

		public static void T1_Pobi(DPoint3d center_point, string style_name)
		{
			try
			{
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				for (uint i = 0U; i < agenda.GetCount(); i += 1U)
				{
					bool flag = agenda.GetEntry(i).ElementType == MSElementType.Line;
					if (flag)
					{
						LineElement line = agenda.GetEntry(i) as LineElement;
						DSegment3d seg;
						line.GetCurveVector().GetAt(0).TryGetLine(out seg);
						Add_TagPobi(line, center_point, style_name, true, true);
					}
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString() + "\r\n");
			}
		}

		public static void T2_Pobi(DPoint3d center_point, string style_name)
		{
			try
			{
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				for (uint i = 0U; i < agenda.GetCount(); i += 1U)
				{
					bool flag = agenda.GetEntry(i).ElementType == MSElementType.Line;
					if (flag)
					{
						LineElement line = agenda.GetEntry(i) as LineElement;
						DSegment3d seg;
						line.GetCurveVector().GetAt(0).TryGetLine(out seg);
						TagPobi(line, center_point, style_name);
					}
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString() + "\r\n");
			}
		}

		public static void T3_Pobi(DPoint3d center_point, string style_name)
		{
			try
			{
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				for (uint i = 0U; i < agenda.GetCount(); i += 1U)
				{
					bool flag = agenda.GetEntry(i).ElementType == MSElementType.Line;
					if (flag)
					{
						LineElement line = agenda.GetEntry(i) as LineElement;
						DSegment3d seg;
						line.GetCurveVector().GetAt(0).TryGetLine(out seg);
						Func_Tag.Tag_Pobi_Version3(line, center_point, style_name);
						Func_Tag.Tag_Pobi_Version3_text(line, center_point, style_name, true, true);
						Func_Tag.Tag_Pobi_Version3_text(line, center_point, style_name, true, false);
						Func_Tag.Tag_Pobi_Version3_text(line, center_point, style_name, false, true);
						Func_Tag.Tag_Pobi_Version3_text(line, center_point, style_name, false, false);
					}
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString() + "\r\n");
			}
		}
		// Token: 0x0600008B RID: 139 RVA: 0x0000ED08 File Offset: 0x0000CF08
		private static void TagPobi(LineElement line, DPoint3d center_point, string style_name)
		{
			try
			{
				TagElement tag = null;
				double tag_value = 0.0;
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
				EC17.find_property_double(line, "坡比", ref tag_value);
				string tag_str = "1:" + tag_value.ToString();
				DgnTextStyle style = DgnTextStyle.GetByName(style_name, dgnFile);
				double width = 0.0;
				style.GetProperty(TextStyleProperty.Width, out width);
				create_tag2024(line, tag_str, style, ref tag);
				//tag.AddToModel();
				bool flag = tag == null;
				if (!flag)
				{
					Angle angle_xy = Angle.PI;
					Angle angle_xz = Angle.PI;
					Tag17.angle_xy(line, center_point, ref angle_xy);
					angle_xy -= Angle.FromDegrees(90.0);
					double angle = Math.Atan(1.0 / tag_value);
					angle_xz = Angle.FromRadians(angle);
					DSegment3d seg;
					line.GetCurveVector().GetAt(0).TryGetLine(out seg);
					DPoint3d cp = new DPoint3d((seg.StartPoint.X + seg.EndPoint.X) / 2.0, (seg.StartPoint.Y + seg.EndPoint.Y) / 2.0, (seg.StartPoint.Z + seg.EndPoint.Z) / 2.0);
					ElementId[] ids = new ElementId[5];
					for (int i = 0; i < 3; i++)
					{
						DPoint3d p = new DPoint3d(cp.X + (double)i * 0.5 * width, cp.Y, cp.Z + 10.0);
						DPoint3d p2 = new DPoint3d(p.X, p.Y - 3.0 * width, p.Z);
						ElementId id = default(ElementId);
						Func_Tag.CreateTagLine(p, p2, ref id);
						ids[i * 2] = id;
					}
					for (int j = 0; j < 2; j++)
					{
						DPoint3d p3 = new DPoint3d(cp.X + (double)j * 0.5 * width + 0.25 * width, cp.Y, cp.Z + 10.0);
						DPoint3d p4 = new DPoint3d(p3.X, p3.Y - 1.5 * width, p3.Z);
						ElementId id2 = default(ElementId);
						Func_Tag.CreateTagLine(p3, p4, ref id2);
						ids[j * 2 + 1] = id2;
					}
					Func_Tag.RotateEle(tag, seg, angle_xy, angle_xz);
					angle_xy += Angle.FromDegrees(90.0);
					for (int k = 0; k < 5; k++)
					{
						ElementId ele_id = ids[k];
						Bentley.DgnPlatformNET.Elements.Element tagline = dgnModel.FindElementById(ele_id);
						bool flag2 = tagline != null;
						if (flag2)
						{
							Func_Tag.RotateEle(tagline, seg, angle_xy, angle_xz);
						}
					}
					bool convert_cell = true;
					SelectionSetManager.EmptyAll();
					//SelectionSetManager.AddElement(tag, dgnModel);
					for (int l = 0; l < 5; l++)
					{
						ElementId ele_id2 = ids[l];
						Bentley.DgnPlatformNET.Elements.Element tagline2 = dgnModel.FindElementById(ele_id2);
						bool flag3 = tagline2 != null;
						if (flag3)
						{
							SelectionSetManager.AddElement(tagline2, dgnModel);
						}
						else
						{
							convert_cell = false;
						}
					}
					bool flag4 = convert_cell;
					if (flag4)
					{
						Session.Instance.Keyin("group selection");
					}
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString() + "\r\n");
			}
		}

		private static bool create_tag2024(LineElement ele, string value, DgnTextStyle style, ref TagElement tag_ele)
		{
			try
			{
				DgnFile dgnFile = Session.Instance.GetActiveDgnFile();//获得创建文本元素的文件
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();//获得创建文本元素的模型空间

				DgnTagDefinition[] tagDefs = new DgnTagDefinition[1];//创建标签定义数组
				tagDefs[0] = new DgnTagDefinition();//创建标签定义
				tagDefs[0].Name = ele.ElementId.ToString();//设置标签名称
				tagDefs[0].TagDataType = TagType.Char;//设置标签类型
				tagDefs[0].Value = value;//设置标签值            

				TagSetElement tagSet = new TagSetElement(dgnModel, tagDefs, tagDefs[0].Name, "", true, dgnFile, 0);//创建标签集元素
				tagSet.AddToModel();//将标签集元素写入模型

				ele.GetCurveVector().GetAt(0).TryGetLine(out DSegment3d seg);
				DPoint3d sp = seg.StartPoint;
				DPoint3d ep = seg.EndPoint;

				DPoint3d origin = new DPoint3d(0.5 * (ep.X - sp.X), 0.5 * (ep.Y - sp.Y), 0.5 * (ep.Z - sp.Z));//设置标签元素插入点

				DMatrix3d orientation = DMatrix3d.Identity;

				TagElement tag = new TagElement(dgnModel, null, tagSet.SetName, tagSet.SetName, null, style, false, origin, orientation, ele);//创建标注元素
				tag.AddToModel();//将标注元素写入模型
				tag_ele = tag;
			}
			catch (Exception ex)
			{
				//Write_Log(ex.ToString() + "\r\n");
				return false;
			}
			return true;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000F0DC File Offset: 0x0000D2DC
		private static void Add_TagPobi(LineElement line, DPoint3d center_point, string style_name, bool limitx, bool limity)
		{
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
				TagElement tag = null;
				double rate = 0.0;
				EC17.find_property_double(line, "坡比", ref rate);
				string tag_str = "1:" + rate.ToString();
				DgnTextStyle style = DgnTextStyle.GetByName(style_name, dgnFile);
				double width = 0.0;
				style.GetProperty(TextStyleProperty.Width, out width);
				Tag17.create_tag(line, tag_str, style, ref tag);
				bool flag = tag == null;
				if (!flag)
				{
					ElementId[] ids = new ElementId[5];
					for (int i = 0; i < 3; i++)
					{
						DPoint3d p = new DPoint3d(0.0, (double)i * width, 0.0);
						DPoint3d p2 = new DPoint3d(4.0 * width, p.Y, 0.0);
						ElementId id = default(ElementId);
						Func_Tag.CreateTagLine(p, p2, ref id);
						ids[i * 2] = id;
					}
					for (int j = 0; j < 2; j++)
					{
						DPoint3d p3 = new DPoint3d(0.0, (double)j * width + 0.5 * width, 0.0);
						DPoint3d p4 = new DPoint3d(2.0 * width, p3.Y, 0.0);
						ElementId id2 = default(ElementId);
						Func_Tag.CreateTagLine(p3, p4, ref id2);
						ids[j * 2 + 1] = id2;
					}
					bool convert_cell = true;
					SelectionSetManager.EmptyAll();
					SelectionSetManager.AddElement(tag, dgnModel);
					for (int k = 0; k < 5; k++)
					{
						ElementId ele_id = ids[k];
						Bentley.DgnPlatformNET.Elements.Element tagline = dgnModel.FindElementById(ele_id);
						bool flag2 = tagline != null;
						if (flag2)
						{
							SelectionSetManager.AddElement(tagline, dgnModel);
						}
						else
						{
							convert_cell = false;
						}
					}
					bool flag3 = convert_cell;
					if (flag3)
					{
						Session.Instance.Keyin("group selection");
					}
					Bentley.Interop.MicroStationDGN.Element MSDgn_ele = Utilities.ComApp.ActiveModelReference.GetLastValidGraphicalElement();
					long cell_id = MSDgn_ele.ID64;
					Bentley.DgnPlatformNET.Elements.Element cell_ele = dgnModel.FindElementById((ElementId)cell_id);
					DTransform3d trans = DTransform3d.Identity;
					bool flag4 = Func_Tag.get_direction(line, rate, center_point, ref trans);
					if (limitx)
					{
						double vxx = trans.RowX.X;
						double vxy = trans.RowY.X;
						double vxz = trans.RowZ.X;
						DVector3d vx = new DVector3d(-1.0 * vxx, -1.0 * vxy, -1.0 * vxz);
						trans.SetColumn(0, vx);
					}
					if (limity)
					{
						double vyx = trans.RowX.Y;
						double vyy = trans.RowY.Y;
						double vyz = trans.RowZ.Y;
						DVector3d vy = new DVector3d(-1.0 * vyx, -1.0 * vyy, -1.0 * vyz);
						trans.SetColumn(1, vy);
					}
					TransformInfo transform = new TransformInfo(trans);
					cell_ele.ApplyTransform(transform);
					DSegment3d seg;
					line.GetCurveVector().GetAt(0).TryGetLine(out seg);
					DPoint3d center_line = new DPoint3d((seg.StartPoint.X + seg.EndPoint.X) / 2.0, (seg.StartPoint.Y + seg.EndPoint.Y) / 2.0, (seg.StartPoint.Z + seg.EndPoint.Z) / 2.0 + 100.0);
					DTransform3d trans_mv = DTransform3d.FromTranslation(center_line);
					TransformInfo transform_mv = new TransformInfo(trans_mv);
					cell_ele.ApplyTransform(transform_mv);
					cell_ele.ReplaceInModel(cell_ele);
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString() + "\r\n");
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000F52C File Offset: 0x0000D72C
		private static void Tag_Pobi_Version3(LineElement line, DPoint3d center_point, string style_name)
		{
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
				DgnTextStyle style = DgnTextStyle.GetByName(style_name, dgnFile);
				double width = 0.0;
				style.GetProperty(TextStyleProperty.Width, out width);
				double meter_rate = Session.Instance.GetActiveDgnModel().GetModelInfo().UorPerMeter;
				double rate = 0.0;
				EC17.find_property_double(line, "坡比", ref rate);
				//string tag_str = "1:" + rate.ToString();
				DVector3d v_dir = DVector3d.UnitZ;
				bool flag = Func_Tag.get_direction_version2(line, rate, center_point, ref v_dir);
				DSegment3d seg;
				line.GetCurveVector().GetAt(0).TryGetLine(out seg);
				DPoint3d sp = seg.StartPoint;
				DPoint3d ep = seg.EndPoint;
				bool flag2 = sp.Z > ep.Z;
				if (flag2)
				{
					DPoint3d tp = new DPoint3d(sp.X, sp.Y, sp.Z);
					sp.X = ep.X;
					sp.Y = ep.Y;
					sp.Z = ep.Z;
					ep.X = tp.X;
					ep.Y = tp.Y;
					ep.Z = tp.Z;
				}
				long[] lines_id = new long[5];
				DPoint3d line_min = new DPoint3d((sp.X + ep.X) / 2.0, (sp.Y + ep.Y) / 2.0, (sp.Z + ep.Z) / 2.0);
				double min_z = line_min.Z + width * 2.0 * v_dir.Z;
				DVector3d v_line = new DVector3d(sp, ep);
				double mode_line = Math.Sqrt(v_line.X * v_line.X + v_line.Y * v_line.Y + v_line.Z * v_line.Z);
				v_line.X /= mode_line;
				v_line.Y /= mode_line;
				v_line.Z /= mode_line;
				for (int i = 0; i < 3; i++)
				{
					DPoint3d tag_sp = new DPoint3d(line_min.X + v_line.X * width * 2.0 * (double)i, line_min.Y + v_line.Y * width * 2.0 * (double)i, line_min.Z + v_line.Z * width * 2.0 * (double)i + 500.0);
					DPoint3d tag_ep = new DPoint3d(tag_sp.X - (tag_sp.Z - min_z) / v_dir.Z * v_dir.X, tag_sp.Y - (tag_sp.Z - min_z) / v_dir.Z * v_dir.Y, tag_sp.Z - (tag_sp.Z - min_z));
					DSegment3d tag_seg = new DSegment3d(tag_sp, tag_ep);
					LineElement tag_line = new LineElement(dgnModel, null, tag_seg);
					tag_line.AddToModel();
					lines_id[i * 2] = tag_line.ElementId;
				}
				for (int j = 0; j < 2; j++)
				{
					DPoint3d tag_sp2 = new DPoint3d(line_min.X + v_line.X * width * (double)(2 * j + 1), line_min.Y + v_line.Y * width * (double)(2 * j + 1), line_min.Z + v_line.Z * width * (double)(2 * j + 1) + 500.0);
					DPoint3d tag_ep2 = new DPoint3d(tag_sp2.X - (tag_sp2.Z - min_z - width) / v_dir.Z * v_dir.X, tag_sp2.Y - (tag_sp2.Z - min_z - width) / v_dir.Z * v_dir.Y, tag_sp2.Z - (tag_sp2.Z - min_z - width));
					DSegment3d tag_seg2 = new DSegment3d(tag_sp2, tag_ep2);
					LineElement tag_line2 = new LineElement(dgnModel, null, tag_seg2);
					tag_line2.AddToModel();
					lines_id[j * 2 + 1] = tag_line2.ElementId;
				}
				bool convert_cell = true;
				SelectionSetManager.EmptyAll();
				for (int k = 0; k < 5; k++)
				{
					ElementId ele_id = (ElementId)lines_id[k];
					Bentley.DgnPlatformNET.Elements.Element tagline = dgnModel.FindElementById(ele_id);
					bool flag3 = tagline != null;
					if (flag3)
					{
						SelectionSetManager.AddElement(tagline, dgnModel);
					}
					else
					{
						convert_cell = false;
					}
				}
				bool flag4 = convert_cell;
				if (flag4)
				{
					Session.Instance.Keyin("group selection");
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString() + "\r\n");
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000FA38 File Offset: 0x0000DC38
		private static void Tag_Pobi_Version3_text(LineElement line, DPoint3d center_point, string style_name, bool limitx, bool limity)
		{
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
				TagElement tag = null;
				double rate = 0.0;
				EC17.find_property_double(line, "坡比", ref rate);
				string tag_str = "1:" + rate.ToString();
				DgnTextStyle style = DgnTextStyle.GetByName(style_name, dgnFile);
				double width = 0.0;
				style.GetProperty(TextStyleProperty.Width, out width);
				Tag17.create_tag(line, tag_str, style, ref tag);
				//bool flag = tag == null;
				if (tag != null)
				{
					DTransform3d trans = DTransform3d.Identity;
					Func_Tag.get_direction_version3(line, rate, center_point, ref trans);
					if (limitx)
					{
						double vxx = trans.RowX.X;
						double vxy = trans.RowY.X;
						double vxz = trans.RowZ.X;
						DVector3d vx = new DVector3d(-1.0 * vxx, -1.0 * vxy, -1.0 * vxz);
						trans.SetColumn(0, vx);
					}
					if (limity)
					{
						double vyx = trans.RowX.Y;
						double vyy = trans.RowY.Y;
						double vyz = trans.RowZ.Y;
						DVector3d vy = new DVector3d(-1.0 * vyx, -1.0 * vyy, -1.0 * vyz);
						trans.SetColumn(1, vy);
					}
					TransformInfo transform = new TransformInfo(trans);
					tag.ApplyTransform(transform);
					DSegment3d seg;
					line.GetCurveVector().GetAt(0).TryGetLine(out seg);
					DPoint3d center_line = new DPoint3d((seg.StartPoint.X + seg.EndPoint.X) / 2.0, (seg.StartPoint.Y + seg.EndPoint.Y) / 2.0, (seg.StartPoint.Z + seg.EndPoint.Z) / 2.0 + 500.0);
					DTransform3d trans_mv = DTransform3d.FromTranslation(center_line);
					TransformInfo transform_mv = new TransformInfo(trans_mv);
					tag.ApplyTransform(transform_mv);
					tag.ReplaceInModel(tag);
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString() + "\r\n");
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000FCDC File Offset: 0x0000DEDC
		private static void Create_Text(DPoint3d tagpoint, string text_message, string style_name, double meter_rate)
		{
			try
			{
				DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				TextBlockProperties txtBlockProp = new TextBlockProperties(dgnModel);
				txtBlockProp.IsViewIndependent = false;
				ParagraphProperties paraProp = new ParagraphProperties(dgnModel);
				DgnTextStyle style = DgnTextStyle.GetByName(style_name, dgnFile);
				RunProperties runProp = new RunProperties(style, dgnModel);
				TextBlock txtBlock = new TextBlock(txtBlockProp, paraProp, runProp, dgnModel);
				txtBlock.AppendText(text_message);
				TextElement text = (TextElement)TextHandlerBase.CreateElement(null, txtBlock);
				text.AddToModel();
				Bentley.DgnPlatformNET.Elements.Element oldEle = Bentley.DgnPlatformNET.Elements.Element.GetFromElementRef(text.GetNativeElementRef());
				DTransform3d trans = DTransform3d.FromTranslation(tagpoint);
				TransformInfo transform = new TransformInfo(trans);
				text.ApplyTransform(transform);
				text.ReplaceInModel(oldEle);
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000FDB0 File Offset: 0x0000DFB0
		public static bool Add_TagLine(string style_name, double meter_rate)
		{
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
				HashSet<Bentley.DgnPlatformNET.Elements.Element> ele_s = new HashSet<Bentley.DgnPlatformNET.Elements.Element>();
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				bool flag = agenda.GetCount() != 2U;
				if (flag)
				{
					MessageBox.Show("请选择两条相邻线");
				}
				CurveVector ele = CurvePathQuery.ElementToCurveVector(agenda.GetEntry(0U));
				DPoint3d p;
				DPoint3d p2;
				ele.GetStartEnd(out p, out p2);
				CurveVector ele2 = CurvePathQuery.ElementToCurveVector(agenda.GetEntry(1U));
				DPoint3d p3;
				DPoint3d p4;
				ele2.GetStartEnd(out p3, out p4);
				bool flag2 = (p.X - p3.X) * (p.X - p3.X) + (p.Y - p3.Y) * (p.Y - p3.Y) + (p.Z - p3.Z) * (p.Z - p3.Z) < 1.0;
				DPoint3d common_p;
				if (flag2)
				{
					common_p = p;
				}
				else
				{
					bool flag3 = (p.X - p4.X) * (p.X - p4.X) + (p.Y - p4.Y) * (p.Y - p4.Y) + (p.Z - p4.Z) * (p.Z - p4.Z) < 1.0;
					if (flag3)
					{
						common_p = p;
					}
					else
					{
						common_p = p2;
					}
				}
				DgnTextStyle style = DgnTextStyle.GetByName(style_name, dgnFile);
				double width = 0.0;
				style.GetProperty(TextStyleProperty.Width, out width);
				DPoint3d common_high = common_p;
				common_high.Z += 2.0 * width;
				DSegment3d seg = new DSegment3d(common_p, common_high);
				LineElement line = new LineElement(dgnModel, null, seg);
				line.AddToModel();
				double tag_time = (double)(DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60 * 60 + DateTime.Now.Day * 24 * 60 * 60);
				tag_time += (double)(DateTime.Now.Month * 30 * 24 * 60 * 60);
				tag_time += (double)((DateTime.Now.Year - 2010) * 12 * 30 * 24 * 60 * 60);
				EC17.create_ec_double(line, "桩号", "时间戳", tag_time, "三维开挖工具_Mesh版");
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				return false;
			}
			return true;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00010074 File Offset: 0x0000E274
		public static bool Tag_Output(string style_name, double meter_rate)
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				ModelElementsCollection elems = dgnModel.GetGraphicElements();
				Dictionary<double, ElementId> pointlist = new Dictionary<double, ElementId>();
				foreach (Bentley.DgnPlatformNET.Elements.Element ele in elems)
				{
					double time = 0.0;
					bool flag = EC17.find_property_double(ele, "时间戳", ref time);
					if (flag)
					{
						pointlist[time] = ele.ElementId;
					}
				}
				Dictionary<double, ElementId> SortDic = (from p in pointlist
				orderby p.Key
				select p).ToDictionary((KeyValuePair<double, ElementId> p) => p.Key, (KeyValuePair<double, ElementId> o) => o.Value);
				int id = 1;
				Dictionary<string, string[]> zh_message = new Dictionary<string, string[]>();
				foreach (KeyValuePair<double, ElementId> item in SortDic)
				{
					string tag_message = "Z" + id.ToString();
					Bentley.DgnPlatformNET.Elements.Element ele2 = dgnModel.FindElementById(item.Value);
					bool flag2 = ele2.ElementType == MSElementType.Line;
					if (flag2)
					{
						CurveVector cv_line = CurvePathQuery.ElementToCurveVector(ele2);
						DPoint3d sp;
						DPoint3d ep;
						cv_line.GetStartEnd(out sp, out ep);
						bool flag3 = sp.Z > ep.Z;
						if (flag3)
						{
							Func_Tag.Create_Text(sp, tag_message, style_name, meter_rate);
							zh_message[tag_message] = new string[]
							{
								tag_message,
								(ep.X / meter_rate).ToString(),
								(ep.Y / meter_rate).ToString(),
								(ep.Z / meter_rate).ToString()
							};
						}
						else
						{
							Func_Tag.Create_Text(ep, tag_message, style_name, meter_rate);
							zh_message[tag_message] = new string[]
							{
								tag_message,
								(sp.X / meter_rate).ToString("f4"),
								(sp.Y / meter_rate).ToString("f4"),
								(sp.Z / meter_rate).ToString("f4")
							};
						}
						id++;
					}
				}
				string save_excel = excel_lib.save_filepath();
				string[] excel_name = new string[4];
				excel_name[0] = "桩号";
				excel_name[0] = "X/m";
				excel_name[0] = "Y/m";
				excel_name[0] = "Z/m";
				excel_lib.export_file(save_excel, zh_message, "Excavation_DataExport", excel_name);
				//DrawExcel.InstallNewInstance(excel_name, zh_message);
				result = true;
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				result = false;
			}
			return result;
		}

		public static bool Tag_Excel(double meter_rate)
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				ModelElementsCollection elems = dgnModel.GetGraphicElements();
				SortedDictionary<double, ElementId> pointlist = new SortedDictionary<double, ElementId>();
				foreach (Bentley.DgnPlatformNET.Elements.Element ele in elems)
				{
					double time = 0.0;
					if (EC17.find_property_double(ele, "时间戳", ref time))
						pointlist[time] = ele.ElementId;
				}

				string[] excel_name = new string[4];
				excel_name[0] = "控制点编号";
				excel_name[1] = "X(m)";
				excel_name[2] = "Y(m)";
				excel_name[3] = "高程(m)";

				int id = 1;
				string[][] data = new string[pointlist.Count + 1][];
				data[0] = excel_name;
				foreach (KeyValuePair<double, ElementId> item in pointlist)
				{
					string tag_message = "Z" + id.ToString();
					Bentley.DgnPlatformNET.Elements.Element ele2 = dgnModel.FindElementById(item.Value);
					string[] point_data = new string[4];
					if (ele2.ElementType == MSElementType.Line)
					{
						CurveVector cv_line = CurvePathQuery.ElementToCurveVector(ele2);
						DPoint3d sp;
						DPoint3d ep;
						cv_line.GetStartEnd(out sp, out ep);
						if (sp.Z > ep.Z)
						{
							point_data[0] = tag_message;
							point_data[1] = (ep.X / meter_rate).ToString("f4");
							point_data[2] = (ep.Y / meter_rate).ToString("f4");
							point_data[3] = (ep.Z / meter_rate).ToString("f4");
						}
						else
						{
							point_data[0] = tag_message;
							point_data[1] = (sp.X / meter_rate).ToString("f4");
							point_data[2] = (sp.Y / meter_rate).ToString("f4");
							point_data[3] = (sp.Z / meter_rate).ToString("f4");
						}
						data[id] = point_data;
						id++;
					}
				}
				SetElement.InstallNewInstance(40000, 6000, excel_name, data);
				result = true;
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0001038C File Offset: 0x0000E58C
		public static bool create_data_string(string ec_name, string property_name, string property_value)
		{
			bool result;
			try
			{
				EC17.refresh_schema_string(1, 1, ec_name, property_name, "三维开挖工具_Mesh版");
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				for (uint i = 0U; i < agenda.GetCount(); i += 1U)
				{
					EC17.create_ec_string(agenda.GetEntry(i), ec_name, property_name, property_value, "三维开挖工具_Mesh版");
				}
				result = true;
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log("Func_Tag:\r\ncreate_data_string\r\n" + ex.ToString() + "\r\n");
				result = false;
			}
			return result;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00010428 File Offset: 0x0000E628
		public static bool create_data_double(string ec_name, string property_name, double property_value)
		{
			bool result;
			try
			{
				EC17.refresh_schema_double(1, 1, ec_name, property_name, "三维开挖工具_Mesh版");
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				for (uint i = 0U; i < agenda.GetCount(); i += 1U)
				{
					EC17.create_ec_double(agenda.GetEntry(i), ec_name, property_name, property_value, "三维开挖工具_Mesh版");
				}
				result = true;
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log("Func_Tag:\r\ncreate_data_string\r\n" + ex.ToString() + "\r\n");
				result = false;
			}
			return result;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000104C4 File Offset: 0x0000E6C4
		private static bool get_direction(LineElement line, double rate, DPoint3d element_center, ref DTransform3d trans)
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DSegment3d seg;
				line.GetCurveVector().GetAt(0).TryGetLine(out seg);
				DPoint3d sp = seg.StartPoint;
				DPoint3d ep = seg.EndPoint;
				bool flag = sp.Z > ep.Z;
				if (flag)
				{
					DPoint3d temp = new DPoint3d(0.0, 0.0, 0.0);
					temp = sp;
					sp = ep;
					ep = temp;
				}
				double r2 = Math.Sqrt((sp.Z - ep.Z) * (sp.Z - ep.Z)) * rate;
				double R = Math.Sqrt((sp.X - ep.X) * (sp.X - ep.X) + (sp.Y - ep.Y) * (sp.Y - ep.Y));
				double r3 = Math.Sqrt(R * R - r2 * r2);
				DVector2d vpart = new DVector2d(sp.X / 2.0 + ep.X / 2.0, sp.Y / 2.0 + ep.Y / 2.0);
				DVector2d vpart2 = new DVector2d((r3 * r3 - r2 * r2) / (2.0 * R * R) * (ep.X - sp.X), (r3 * r3 - r2 * r2) / (2.0 * R * R) * (ep.Y - sp.Y));
				DVector2d vpart3 = new DVector2d(Math.Sqrt(2.0 * (r3 * r3 + r2 * r2) / (R * R) - (r3 * r3 - r2 * r2) * (r3 * r3 - r2 * r2) / (R * R * R * R) - 1.0) / 2.0 * (ep.Y - sp.Y), Math.Sqrt(2.0 * (r3 * r3 + r2 * r2) / (R * R) - (r3 * r3 - r2 * r2) * (r3 * r3 - r2 * r2) / (R * R * R * R) - 1.0) / 2.0 * (sp.X - ep.X));
				DPoint3d p = new DPoint3d(vpart.X + vpart2.X + vpart3.X, vpart.Y + vpart2.Y + vpart3.Y, sp.Z);
				DPoint3d p2 = new DPoint3d(vpart.X + vpart2.X - vpart3.X, vpart.Y + vpart2.Y - vpart3.Y, sp.Z);
				double len = Math.Sqrt((p.X - element_center.X) * (p.X - element_center.X) + (p.Y - element_center.Y) * (p.Y - element_center.Y));
				double len2 = Math.Sqrt((p2.X - element_center.X) * (p2.X - element_center.X) + (p2.Y - element_center.Y) * (p2.Y - element_center.Y));
				double line_len = Math.Sqrt((sp.X - ep.X) * (sp.X - ep.X) + (sp.Y - ep.Y) * (sp.Y - ep.Y) + (sp.Z - ep.Z) * (sp.Z - ep.Z));
				DPoint3d line_center = new DPoint3d((sp.X + ep.X) / 2.0, (sp.Y + ep.Y) / 2.0, (sp.Z + ep.Z) / 2.0);
				DVector3d es = new DVector3d(ep, sp);
				double mode_es = Math.Sqrt(es.X * es.X + es.Y * es.Y + es.Z * es.Z);
				DPoint3d nx = DPoint3d.Zero;
				DPoint3d ny = DPoint3d.Zero;
				DPoint3d nz = DPoint3d.Zero;
				bool flag2 = len < len2;
				if (flag2)
				{
					DVector3d direction = new DVector3d(ep, p);
					double mode_dir = Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y + direction.Z * direction.Z);
					double sp_p = Math.Sqrt((sp.X - p.X) * (sp.X - p.X) + (sp.Y - p.Y) * (sp.Y - p.Y) + (sp.Z - p.Z) * (sp.Z - p.Z));
					double i = mode_dir * mode_dir / sp_p;
					DPoint3d px = new DPoint3d(ep.X + i / mode_es * es.X, ep.Y + i / mode_es * es.Y, ep.Z + i / mode_es * es.Z);
					DVector3d vx = new DVector3d(px, p);
					double mode_vx = Math.Sqrt(vx.X * vx.X + vx.Y * vx.Y + vx.Z * vx.Z);
					nx = new DPoint3d(vx.X / mode_vx, vx.Y / mode_vx, vx.Z / mode_vx);
					double nz_x = (ep.Y - sp.Y) * (p.Z - sp.Z) - (ep.Z - sp.Z) * (p.Y - sp.Y);
					double nz_y = (ep.Z - sp.X) * (p.X - sp.X) - (ep.X - sp.X) * (p.Z - sp.Z);
					double nz_z = (ep.X - sp.X) * (p.Y - sp.Y) - (ep.Y - sp.Y) * (p.X - sp.X);
					double mode_nz = Math.Sqrt(nz_x * nz_x + nz_y * nz_y + nz_z * nz_z);
					bool flag3 = nz_z > 0.0;
					if (flag3)
					{
						nz = new DPoint3d(nz_x / mode_nz, nz_y / mode_nz, nz_z / mode_nz);
					}
					else
					{
						nz = new DPoint3d(-1.0 * nz_x / mode_nz, -1.0 * nz_y / mode_nz, -1.0 * nz_z / mode_nz);
					}
					DVector3d d = new DVector3d(DPoint3d.Zero, sp);
					DVector3d d2 = new DVector3d(DPoint3d.Zero, ep);
					double mode_d = Math.Sqrt(d.X * d.X + d.Y * d.Y + d.Z * d.Z);
					double mode_d2 = Math.Sqrt(d2.X * d2.X + d2.Y * d2.Y + d2.Z * d2.Z);
					double angle = Math.Acos(d.X / mode_d);
					double angle2 = Math.Acos(d2.X / mode_d2);
					bool flag4 = d.Y < 0.0;
					if (flag4)
					{
						angle = 6.283185307179586 - angle2;
					}
					bool flag5 = d2.Y < 0.0;
					if (flag5)
					{
						angle2 = 6.283185307179586 - angle2;
					}
					bool flag6 = angle - angle2 > 3.141592653589793;
					if (flag6)
					{
						angle -= 6.283185307179586;
					}
					bool flag7 = angle2 - angle > 3.141592653589793;
					if (flag7)
					{
						angle2 -= 6.283185307179586;
					}
					DVector3d vline = new DVector3d(sp, ep);
					double mode_v = Math.Sqrt(vline.X * vline.X + vline.Y * vline.Y + vline.Z * vline.Z);
					bool flag8 = angle > angle2;
					if (flag8)
					{
						ny.X = -1.0 * vline.X / mode_v;
						ny.Y = -1.0 * vline.Y / mode_v;
						ny.Z = -1.0 * vline.Z / mode_v;
					}
					else
					{
						ny.X = vline.X / mode_v;
						ny.Y = vline.Y / mode_v;
						ny.Z = vline.Z / mode_v;
					}
				}
				else
				{
					DVector3d direction2 = new DVector3d(ep, p2);
					double mode_dir2 = Math.Sqrt(direction2.X * direction2.X + direction2.Y * direction2.Y + direction2.Z * direction2.Z);
					double sp_p2 = Math.Sqrt((sp.X - p2.X) * (sp.X - p2.X) + (sp.Y - p2.Y) * (sp.Y - p2.Y) + (sp.Z - p2.Z) * (sp.Z - p2.Z));
					double j = mode_dir2 * mode_dir2 / sp_p2;
					DPoint3d px2 = new DPoint3d(ep.X + j / mode_es * es.X, ep.Y + j / mode_es * es.Y, ep.Z + j / mode_es * es.Z);
					DVector3d vx2 = new DVector3d(px2, p2);
					double mode_vx2 = Math.Sqrt(vx2.X * vx2.X + vx2.Y * vx2.Y + vx2.Z * vx2.Z);
					nx = new DPoint3d(vx2.X / mode_vx2, vx2.Y / mode_vx2, vx2.Z / mode_vx2);
					double nz_x2 = (ep.Y - sp.Y) * (p2.Z - sp.Z) - (ep.Z - sp.Z) * (p2.Y - sp.Y);
					double nz_y2 = (ep.Z - sp.X) * (p2.X - sp.X) - (ep.X - sp.X) * (p2.Z - sp.Z);
					double nz_z2 = (ep.X - sp.X) * (p2.Y - sp.Y) - (ep.Y - sp.Y) * (p2.X - sp.X);
					double mode_nz2 = Math.Sqrt(nz_x2 * nz_x2 + nz_y2 * nz_y2 + nz_z2 * nz_z2);
					bool flag9 = nz_z2 > 0.0;
					if (flag9)
					{
						nz = new DPoint3d(nz_x2 / mode_nz2, nz_y2 / mode_nz2, nz_z2 / mode_nz2);
					}
					else
					{
						nz = new DPoint3d(-1.0 * nz_x2 / mode_nz2, -1.0 * nz_y2 / mode_nz2, -1.0 * nz_z2 / mode_nz2);
					}
					DVector3d d3 = new DVector3d(DPoint3d.Zero, sp);
					DVector3d d4 = new DVector3d(DPoint3d.Zero, ep);
					double mode_d3 = Math.Sqrt(d3.X * d3.X + d3.Y * d3.Y + d3.Z * d3.Z);
					double mode_d4 = Math.Sqrt(d4.X * d4.X + d4.Y * d4.Y + d4.Z * d4.Z);
					double angle3 = Math.Acos(d3.X / mode_d3);
					double angle4 = Math.Acos(d4.X / mode_d4);
					bool flag10 = d3.Y < 0.0;
					if (flag10)
					{
						angle3 = 6.283185307179586 - angle4;
					}
					bool flag11 = d4.Y < 0.0;
					if (flag11)
					{
						angle4 = 6.283185307179586 - angle4;
					}
					bool flag12 = angle3 - angle4 > 3.141592653589793;
					if (flag12)
					{
						angle3 -= 6.283185307179586;
					}
					bool flag13 = angle4 - angle3 > 3.141592653589793;
					if (flag13)
					{
						angle4 -= 6.283185307179586;
					}
					DVector3d vline2 = new DVector3d(sp, ep);
					double mode_v2 = Math.Sqrt(vline2.X * vline2.X + vline2.Y * vline2.Y + vline2.Z * vline2.Z);
					bool flag14 = angle3 > angle4;
					if (flag14)
					{
						ny.X = -1.0 * vline2.X / mode_v2;
						ny.Y = -1.0 * vline2.Y / mode_v2;
						ny.Z = -1.0 * vline2.Z / mode_v2;
					}
					else
					{
						ny.X = vline2.X / mode_v2;
						ny.Y = vline2.Y / mode_v2;
						ny.Z = vline2.Z / mode_v2;
					}
				}
				trans = new DTransform3d(nx.X, ny.X, nz.X, nx.Y, ny.Y, nz.Y, nx.Z, ny.Z, nz.Z);
				result = true;
			}
			catch (Exception ex)
			{
				string message_output = "放坡模块-基线放坡模块-Move_Line-Catch：\r\n";
				message_output = message_output + ex.ToString() + "\r\n";
				Func_Init.Write_Log(message_output);
				result = false;
			}
			return result;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00011360 File Offset: 0x0000F560
		private static bool get_direction_version2(LineElement line, double rate, DPoint3d element_center, ref DVector3d vdir)
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DSegment3d seg;
				line.GetCurveVector().GetAt(0).TryGetLine(out seg);
				DPoint3d sp = seg.StartPoint;
				DPoint3d ep = seg.EndPoint;
				bool flag = sp.Z > ep.Z;
				if (flag)
				{
					DPoint3d temp = new DPoint3d(0.0, 0.0, 0.0);
					temp = sp;
					sp = ep;
					ep = temp;
				}
				double r2 = Math.Sqrt((sp.Z - ep.Z) * (sp.Z - ep.Z)) * rate;
				double R = Math.Sqrt((sp.X - ep.X) * (sp.X - ep.X) + (sp.Y - ep.Y) * (sp.Y - ep.Y));
				double r3 = Math.Sqrt(R * R - r2 * r2);
				DVector2d vpart = new DVector2d(sp.X / 2.0 + ep.X / 2.0, sp.Y / 2.0 + ep.Y / 2.0);
				DVector2d vpart2 = new DVector2d((r3 * r3 - r2 * r2) / (2.0 * R * R) * (ep.X - sp.X), (r3 * r3 - r2 * r2) / (2.0 * R * R) * (ep.Y - sp.Y));
				DVector2d vpart3 = new DVector2d(Math.Sqrt(2.0 * (r3 * r3 + r2 * r2) / (R * R) - (r3 * r3 - r2 * r2) * (r3 * r3 - r2 * r2) / (R * R * R * R) - 1.0) / 2.0 * (ep.Y - sp.Y), Math.Sqrt(2.0 * (r3 * r3 + r2 * r2) / (R * R) - (r3 * r3 - r2 * r2) * (r3 * r3 - r2 * r2) / (R * R * R * R) - 1.0) / 2.0 * (sp.X - ep.X));
				DPoint3d p = new DPoint3d(vpart.X + vpart2.X + vpart3.X, vpart.Y + vpart2.Y + vpart3.Y, sp.Z);
				DPoint3d p2 = new DPoint3d(vpart.X + vpart2.X - vpart3.X, vpart.Y + vpart2.Y - vpart3.Y, sp.Z);
				double len = Math.Sqrt((p.X - element_center.X) * (p.X - element_center.X) + (p.Y - element_center.Y) * (p.Y - element_center.Y));
				double len2 = Math.Sqrt((p2.X - element_center.X) * (p2.X - element_center.X) + (p2.Y - element_center.Y) * (p2.Y - element_center.Y));
				double line_len = Math.Sqrt((sp.X - ep.X) * (sp.X - ep.X) + (sp.Y - ep.Y) * (sp.Y - ep.Y) + (sp.Z - ep.Z) * (sp.Z - ep.Z));
				DPoint3d line_center = new DPoint3d((sp.X + ep.X) / 2.0, (sp.Y + ep.Y) / 2.0, (sp.Z + ep.Z) / 2.0);
				DVector3d es = new DVector3d(ep, sp);
				double mode_es = Math.Sqrt(es.X * es.X + es.Y * es.Y + es.Z * es.Z);
				DPoint3d nx = DPoint3d.Zero;
				DPoint3d ny = DPoint3d.Zero;
				DPoint3d nz = DPoint3d.Zero;
				bool flag2 = len < len2;
				if (flag2)
				{
					DVector3d direction = new DVector3d(ep, p);
					double mode_dir = Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y + direction.Z * direction.Z);
					vdir = new DVector3d(direction.X / mode_dir, direction.Y / mode_dir, direction.Z / mode_dir);
				}
				else
				{
					DVector3d direction2 = new DVector3d(ep, p2);
					double mode_dir2 = Math.Sqrt(direction2.X * direction2.X + direction2.Y * direction2.Y + direction2.Z * direction2.Z);
					vdir = new DVector3d(direction2.X / mode_dir2, direction2.Y / mode_dir2, direction2.Z / mode_dir2);
				}
				result = true;
			}
			catch (Exception ex)
			{
				string message_output = "放坡模块-基线放坡模块-Move_Line-Catch：\r\n";
				message_output = message_output + ex.ToString() + "\r\n";
				Func_Init.Write_Log(message_output);
				result = false;
			}
			return result;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00011924 File Offset: 0x0000FB24
		private static bool get_direction_version3(LineElement line, double rate, DPoint3d element_center, ref DTransform3d trans)
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DSegment3d seg;
				line.GetCurveVector().GetAt(0).TryGetLine(out seg);
				DPoint3d sp = seg.StartPoint;
				DPoint3d ep = seg.EndPoint;
				bool flag = sp.Z > ep.Z;
				if (flag)
				{
					DPoint3d temp = new DPoint3d(0.0, 0.0, 0.0);
					temp = sp;
					sp = ep;
					ep = temp;
				}
				double r2 = Math.Sqrt((sp.Z - ep.Z) * (sp.Z - ep.Z)) * rate;
				double R = Math.Sqrt((sp.X - ep.X) * (sp.X - ep.X) + (sp.Y - ep.Y) * (sp.Y - ep.Y));
				double r3 = Math.Sqrt(R * R - r2 * r2);
				DVector2d vpart = new DVector2d(sp.X / 2.0 + ep.X / 2.0, sp.Y / 2.0 + ep.Y / 2.0);
				DVector2d vpart2 = new DVector2d((r3 * r3 - r2 * r2) / (2.0 * R * R) * (ep.X - sp.X), (r3 * r3 - r2 * r2) / (2.0 * R * R) * (ep.Y - sp.Y));
				DVector2d vpart3 = new DVector2d(Math.Sqrt(2.0 * (r3 * r3 + r2 * r2) / (R * R) - (r3 * r3 - r2 * r2) * (r3 * r3 - r2 * r2) / (R * R * R * R) - 1.0) / 2.0 * (ep.Y - sp.Y), Math.Sqrt(2.0 * (r3 * r3 + r2 * r2) / (R * R) - (r3 * r3 - r2 * r2) * (r3 * r3 - r2 * r2) / (R * R * R * R) - 1.0) / 2.0 * (sp.X - ep.X));
				DPoint3d p = new DPoint3d(vpart.X + vpart2.X + vpart3.X, vpart.Y + vpart2.Y + vpart3.Y, sp.Z);
				DPoint3d p2 = new DPoint3d(vpart.X + vpart2.X - vpart3.X, vpart.Y + vpart2.Y - vpart3.Y, sp.Z);
				double len = Math.Sqrt((p.X - element_center.X) * (p.X - element_center.X) + (p.Y - element_center.Y) * (p.Y - element_center.Y));
				double len2 = Math.Sqrt((p2.X - element_center.X) * (p2.X - element_center.X) + (p2.Y - element_center.Y) * (p2.Y - element_center.Y));
				double line_len = Math.Sqrt((sp.X - ep.X) * (sp.X - ep.X) + (sp.Y - ep.Y) * (sp.Y - ep.Y) + (sp.Z - ep.Z) * (sp.Z - ep.Z));
				DPoint3d line_center = new DPoint3d((sp.X + ep.X) / 2.0, (sp.Y + ep.Y) / 2.0, (sp.Z + ep.Z) / 2.0);
				DVector3d es = new DVector3d(ep, sp);
				double mode_es = Math.Sqrt(es.X * es.X + es.Y * es.Y + es.Z * es.Z);
				DPoint3d nx = DPoint3d.Zero;
				DPoint3d ny = DPoint3d.Zero;
				DPoint3d nz = DPoint3d.Zero;
				bool flag2 = len < len2;
				if (flag2)
				{
					DVector3d direction = new DVector3d(ep, p);
					double mode_dir = Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y + direction.Z * direction.Z);
					nx = new DPoint3d(direction.X / mode_dir, direction.Y / mode_dir, direction.Z / mode_dir);
					double nz_x = (ep.Y - sp.Y) * (p.Z - sp.Z) - (ep.Z - sp.Z) * (p.Y - sp.Y);
					double nz_y = (ep.Z - sp.X) * (p.X - sp.X) - (ep.X - sp.X) * (p.Z - sp.Z);
					double nz_z = (ep.X - sp.X) * (p.Y - sp.Y) - (ep.Y - sp.Y) * (p.X - sp.X);
					double mode_nz = Math.Sqrt(nz_x * nz_x + nz_y * nz_y + nz_z * nz_z);
					bool flag3 = nz_z > 0.0;
					if (flag3)
					{
						nz = new DPoint3d(nz_x / mode_nz, nz_y / mode_nz, nz_z / mode_nz);
					}
					else
					{
						nz = new DPoint3d(-1.0 * nz_x / mode_nz, -1.0 * nz_y / mode_nz, -1.0 * nz_z / mode_nz);
					}
					ny = new DVector3d(p, sp);
					double mode_y = Math.Sqrt(ny.X * ny.X + ny.Y * ny.Y + ny.Z * ny.Z);
					ny.X /= mode_y;
					ny.Y /= mode_y;
					ny.Z /= mode_y;
				}
				else
				{
					DVector3d direction2 = new DVector3d(ep, p2);
					double mode_dir2 = Math.Sqrt(direction2.X * direction2.X + direction2.Y * direction2.Y + direction2.Z * direction2.Z);
					nx = new DPoint3d(direction2.X / mode_dir2, direction2.Y / mode_dir2, direction2.Z / mode_dir2);
					double nz_x2 = (ep.Y - sp.Y) * (p2.Z - sp.Z) - (ep.Z - sp.Z) * (p2.Y - sp.Y);
					double nz_y2 = (ep.Z - sp.X) * (p2.X - sp.X) - (ep.X - sp.X) * (p2.Z - sp.Z);
					double nz_z2 = (ep.X - sp.X) * (p2.Y - sp.Y) - (ep.Y - sp.Y) * (p2.X - sp.X);
					double mode_nz2 = Math.Sqrt(nz_x2 * nz_x2 + nz_y2 * nz_y2 + nz_z2 * nz_z2);
					bool flag4 = nz_z2 > 0.0;
					if (flag4)
					{
						nz = new DPoint3d(nz_x2 / mode_nz2, nz_y2 / mode_nz2, nz_z2 / mode_nz2);
					}
					else
					{
						nz = new DPoint3d(-1.0 * nz_x2 / mode_nz2, -1.0 * nz_y2 / mode_nz2, -1.0 * nz_z2 / mode_nz2);
					}
					ny = new DVector3d(p2, sp);
					double mode_y2 = Math.Sqrt(ny.X * ny.X + ny.Y * ny.Y + ny.Z * ny.Z);
					ny.X /= mode_y2;
					ny.Y /= mode_y2;
					ny.Z /= mode_y2;
				}
				trans = new DTransform3d(nx.X, ny.X, nz.X, nx.Y, ny.Y, nz.Y, nx.Z, ny.Z, nz.Z);
				result = true;
			}
			catch (Exception ex)
			{
				string message_output = "放坡模块-基线放坡模块-Move_Line-Catch：\r\n";
				message_output = message_output + ex.ToString() + "\r\n";
				Func_Init.Write_Log(message_output);
				result = false;
			}
			return result;
		}

		public static void tag_height(double height, DgnTextStyle style, DPoint3d CenterPoint)
		{
			try
			{
				//获取点选直线
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				double uor = Session.Instance.GetActiveDgnModel().GetModelInfo().UorPerMeter;
				DgnFile dgnfile = Session.Instance.GetActiveDgnFile();

				LineElement StartBaseLine, EndBaseLine;
				DPoint3d SquareStartPoint = new DPoint3d();
				DPoint3d BaseMidPoint = new DPoint3d();
				Angle angle = Angle.Zero;
				double textheight = 0;
				double textwidth = 0;
				style.GetProperty(TextStyleProperty.Height, out textheight);
				style.GetProperty(TextStyleProperty.Width, out textwidth);

				if (agenda.GetCount() == 2 && agenda.GetEntry(0).ElementType == MSElementType.Line && agenda.GetEntry(1).ElementType == MSElementType.Line)
				{
					DPoint3d a = new DPoint3d(0, 0, 0);
					DPoint3d b = new DPoint3d(1, 0, 0);
					DSegment3d seg = new DSegment3d(a, b);
					LineElement BaseLine = new LineElement(dgnModel, null, seg);

					//按选择顺序：第一条
					StartBaseLine = agenda.GetEntry(0) as LineElement;
					StartBaseLine.GetCurveVector().GetAt(0).TryGetLine(out DSegment3d SBLine);
					//按选择顺序：第二条
					EndBaseLine = agenda.GetEntry(1) as LineElement;
					EndBaseLine.GetCurveVector().GetAt(0).TryGetLine(out DSegment3d EBLine);
					//第一条线中点定位
					DPoint3d StartLineFirstPoint = SBLine.StartPoint;
					DPoint3d StartLineLastPoint = SBLine.EndPoint;
					DPoint3d StartLineMidpoint = new DPoint3d();
					StartLineMidpoint.X = (StartLineFirstPoint.X + StartLineLastPoint.X) / 2;
					StartLineMidpoint.Y = (StartLineFirstPoint.Y + StartLineLastPoint.Y) / 2;
					StartLineMidpoint.Z = (StartLineFirstPoint.Z + StartLineLastPoint.Z) / 2;
					//第二条线中点定位
					DPoint3d EndLineFirstPoint = EBLine.StartPoint;
					DPoint3d EndLineLastPoint = EBLine.EndPoint;
					DPoint3d EndLineMidpoint = new DPoint3d();
					EndLineMidpoint.X = (EndLineFirstPoint.X + EndLineLastPoint.X) / 2;
					EndLineMidpoint.Y = (EndLineFirstPoint.Y + EndLineLastPoint.Y) / 2;
					EndLineMidpoint.Z = (EndLineFirstPoint.Z + EndLineLastPoint.Z) / 2;

					//判断两条线的关系
					double CenterToStart = System.Math.Sqrt(((StartLineMidpoint.X - CenterPoint.X) * (StartLineMidpoint.X - CenterPoint.X))
						+ ((StartLineMidpoint.Y - CenterPoint.Y) * (StartLineMidpoint.Y - CenterPoint.Y))
						+ ((StartLineMidpoint.Z - CenterPoint.Z) * (StartLineMidpoint.Z - CenterPoint.Z)));
					double CenterToEnd = System.Math.Sqrt(((EndLineMidpoint.X - CenterPoint.X) * (EndLineMidpoint.X - CenterPoint.X))
						+ ((EndLineMidpoint.Y - CenterPoint.Y) * (EndLineMidpoint.Y - CenterPoint.Y))
						+ ((EndLineMidpoint.Z - CenterPoint.Z) * (EndLineMidpoint.Z - CenterPoint.Z)));
					if (CenterToStart >= CenterToEnd)
					{
						SquareStartPoint = EndLineMidpoint;
						BaseMidPoint = EndLineMidpoint;
						BaseLine = EndBaseLine;
					}
					else if (CenterToStart < CenterToEnd)
					{
						SquareStartPoint = StartLineMidpoint;
						BaseMidPoint = StartLineMidpoint;
						BaseLine = StartBaseLine;
					}

					//位数判断
					double DefHeight = SquareStartPoint.Z / uor;
					DefHeight = DefHeight - height;
					DefHeight = Math.Round(DefHeight, 2);
					string DefHeightStr = DefHeight.ToString("f2");
					char[] DefHeightChar = DefHeightStr.ToCharArray();

					double SquareLongsideLenght = DefHeightChar.Length * (textwidth * 0.75);
					SquareStartPoint.X = SquareStartPoint.X - SquareLongsideLenght / 2;
					SquareStartPoint.Y = SquareStartPoint.Y + uor;
					SquareStartPoint.Z = SquareStartPoint.Z + 1;

					DPoint3d SquareSecondPoint = new DPoint3d();
					SquareSecondPoint.X = SquareStartPoint.X + SquareLongsideLenght;
					SquareSecondPoint.Y = SquareStartPoint.Y;
					SquareSecondPoint.Z = SquareStartPoint.Z;

					DPoint3d SquareThirdPoint = new DPoint3d();
					SquareThirdPoint.X = SquareStartPoint.X + SquareLongsideLenght;
					SquareThirdPoint.Y = SquareStartPoint.Y + 0.5 * uor + textheight;
					SquareThirdPoint.Z = SquareStartPoint.Z;

					DPoint3d SquareFourthPoint = new DPoint3d();
					SquareFourthPoint.X = SquareStartPoint.X;
					SquareFourthPoint.Y = SquareStartPoint.Y + 0.5 * uor + textheight;
					SquareFourthPoint.Z = SquareStartPoint.Z;

					//画四边形
					DPoint3d[] pos = { SquareStartPoint, SquareSecondPoint, SquareThirdPoint, SquareFourthPoint, SquareStartPoint };
					LineStringElement Square = new LineStringElement(dgnModel, null, pos);
					Element oldEle = Element.GetFromElementRef(Square.GetNativeElementRef());
					ElementPropertiesSetter elePropSet = new ElementPropertiesSetter();
					elePropSet.SetWeight(3);
					elePropSet.Apply(Square);
					Square.ReplaceInModel(oldEle);
					//Square.AddToModel();

					DgnTagDefinition[] tagDefs = new DgnTagDefinition[1];

					tagDefs[0] = new DgnTagDefinition();
					tagDefs[0].Name = DefHeight.ToString("f2");
					tagDefs[0].TagDataType = TagType.Char;
					tagDefs[0].Value = DefHeight.ToString("f2");

					TagSetElement tagset = new TagSetElement(dgnModel, tagDefs, tagDefs[0].Name, "", true, dgnfile, 0);
					tagset.AddToModel();

					DPoint3d origin = DPoint3d.FromXYZ(0, 0, 0);
					origin.Y = 0.2 * uor + textheight;
					DMatrix3d orientation = DMatrix3d.Identity;
					TagElement tag = new TagElement(dgnModel, null, tagset.SetName, tagset.SetName, null, style, false, origin, orientation, Square);
					tag.AddToModel();

					//组成组
					SelectionSetManager.EmptyAll();
					SelectionSetManager.AddElement(Square, dgnModel);
					SelectionSetManager.AddElement(tag, dgnModel);

					Session.Instance.Keyin("group selection");
					Bentley.Interop.MicroStationDGN.Element original_mesh = Bentley.MstnPlatformNET.InteropServices.Utilities.ComApp.ActiveModelReference.GetLastValidGraphicalElement();
					long mesh_id = original_mesh.ID64;
					Element ele_id = dgnModel.FindElementById((ElementId)mesh_id);
					Element targetElement = ele_id;
				}
				else
				{
					MessageBox.Show("请选择两条线元素。");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		public void DrawDataTable(string[] name_list, Dictionary<string, string[]> excel_message)
		{
			DgnFile dgnFile = Session.Instance.GetActiveDgnFile();//获得当前激活的文件
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();//获得当前激活的模型空间

			DgnTextStyle textStyle = DgnTextStyle.GetByName("ExcavationStyle_Level2", dgnFile);
			ElementId textStyleId = textStyle.Id;//获得文字样式ID
			TextTable textTable = TextTable.Create((uint)excel_message.Keys.Count + 1, (uint)name_list.Length, textStyleId, 1000, dgnModel);//创建文字表
			{
				for (int i = 0; i < name_list.Length; i++)
				{
					TableCellIndex index = new TableCellIndex(0, (uint)i);//声明图表单元索引
					TextTableCell tableCell = textTable.GetCell(index);//通过索引值获得文字表单元
					tableCell.SetTextString(name_list[i]);//设置文字表单元名称
				}

				foreach (string[] values in excel_message.Values)
				{
					uint i = 1;
					for (int j = 0; j < values.Length; j++)
					{
						TableCellIndex index = new TableCellIndex(i, (uint)j);//声明图表单元索引
						TextTableCell tableCell = textTable.GetCell(index);//通过索引值获得文字表单元
						tableCell.SetTextString(values[j]);//设置文字表单元名称
					}
					i++;
				}
				TextTableElement m_textTableElem = new TextTableElement(textTable);//声明文字表元素
				m_textTableElem.AddToModel();
				MessageBox.Show("success");
			}
		}

		public static void draw_excel(int width, int height, string[] name_list, string[][] excel_message)
        {
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
			IList<Element> subElems = new List<Element>();//声明元素列表
			int row = excel_message.Length;
			int col = name_list.Length;
			DgnTextStyle textStyle = DgnTextStyle.GetByName("ExcavationStyle_Level1", dgnFile);

			#region DrawCustomDataTable  
			for (int i = 0; i < row + 1; i++)//遍历
			{
				DPoint3d startPo = new DPoint3d(0, (-1) * i * height);//设置图表行线起点
				DPoint3d endPo = new DPoint3d(col * width, (-1) * i * height);//设置图表行线终点
				DSegment3d segment = new DSegment3d(startPo, endPo);//声明几何直线
				LineElement line = new LineElement(dgnModel, null, segment);//声明线元素
				//line.AddToModel();
				subElems.Add(line);//将线元素添加到列表中                   
			}

			for (int i = 0; i < col + 1; i++)//遍历
			{
				DPoint3d startPo = new DPoint3d(i * width, 0);//设置图表列线起点
				DPoint3d endPo = new DPoint3d(i * width, (-1) * row * height);//设置图表列线终点
				DSegment3d segment = new DSegment3d(startPo, endPo);//声明几何直线
				LineElement line = new LineElement(dgnModel, null, segment);//声明线元素
				//line.AddToModel();
				subElems.Add(line);//将线元素添加到列表中                  
			}
			#endregion

			#region InsertDataToDataTable
			for (int i = 0; i < row; i++)//遍历
			{

				for (int j = 0; j < col; j++)//遍历
				{
					DPoint3d insertPo = new DPoint3d((j + 0.1) * width, (-1) * (i + 0.1) * height);//设置文字插入点

					TextBlockProperties txtBlockProp = new TextBlockProperties(dgnModel);//定义文本属性
					txtBlockProp.IsViewIndependent = false;//设置文本非独立于视图
					ParagraphProperties paraProp = new ParagraphProperties(dgnModel);//定义段落属性
					RunProperties runProp = new RunProperties(textStyle, dgnModel);//定义运行属性
					TextBlock txtBlock = new TextBlock(txtBlockProp, paraProp, runProp, dgnModel);//定义文本块
					txtBlock.AppendText(excel_message[i][j]);
					TextElement text = (TextElement)TextElement.CreateElement(null, txtBlock);//定义文本元素
					TransformInfo transform = new TransformInfo(DTransform3d.FromTranslation(insertPo));//声明变换信息
					text.ApplyTransform(transform);//对元素应用变换信息
					subElems.Add(text);//将元素添加到列表中
				}
			}
			#endregion

			#region MergeIntoCell
			Element m_textTableElem = new CellHeaderElement(dgnModel, "CustomDataTable", DPoint3d.Zero, DMatrix3d.Identity, subElems);//声明单元元素
			m_textTableElem.AddToModel();
			//SetElement.InstallNewInstance(m_textTableElem.ElementId);
			//m_textTableElem.DeleteFromModel();
			#endregion
		}

	}

	internal class SetElement : DgnElementSetTool
	{
		// Token: 0x0600006E RID: 110 RVA: 0x0000BA1F File Offset: 0x00009C1F
		public SetElement(int toolId, int prompt) : base(toolId, prompt)
		{
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000BA2C File Offset: 0x00009C2C
		public static void InstallNewInstance(int width, int height, string[] name_list, string[][] excel_message)
		{
			new SetElement(0, 0)
			{
				w = width,
				h = height,
				title = name_list,
				message = excel_message
			}.InstallTool();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000BA74 File Offset: 0x00009C74
		protected override void OnPostInstall()
		{
			string tips = "请选择放置点:";
			NotificationManager.OutputPrompt(tips);
			this.set_point = DPoint3d.Zero;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000BA9C File Offset: 0x00009C9C
		public override StatusInt OnElementModify(Element element)
		{
			return StatusInt.Error;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000BAB4 File Offset: 0x00009CB4
		protected override bool OnDataButton(DgnButtonEvent ev)
		{
			try
			{
				set_point = ev.Point;
				Element set_ele = draw_cell(w, h, title, message);
				if (set_ele != null)
				{
					TransformInfo trans = new TransformInfo(DTransform3d.FromTranslation(set_point));
					set_ele.ApplyTransform(trans);
					set_ele.AddToModel();
				}
				else
				{
					string tips = "异常:";
					NotificationManager.OutputPrompt(tips);
					this.ExitTool();
				}
			}
			catch(Exception ex)
            {
				MessageBox.Show(ex.ToString());
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
			string[] default_title = new string[] { };
			string[][] default_message = new string[][] { };
			SetElement.InstallNewInstance(40000, 6000, default_title, default_message);
		}

		// Token: 0x0400007B RID: 123
		//private ElementId id;
		private int w;
		private int h;
		private string[] title;
		private string[][] message;
		private DPoint3d set_point;

		private Element draw_cell(int width, int height, string[] name_list, string[][] excel_message)
		{
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
				IList<Element> subElems = new List<Element>();//声明元素列表
				int row = excel_message.Length;
				int col = name_list.Length;
				DgnTextStyle textStyle = DgnTextStyle.GetByName("ExcavationStyle_Level1", dgnFile);

				#region DrawCustomDataTable  
				for (int i = 0; i < row + 1; i++)//遍历
				{
					DPoint3d startPo = new DPoint3d(0, (-1) * i * height);//设置图表行线起点
					DPoint3d endPo = new DPoint3d(col * width, (-1) * i * height);//设置图表行线终点
					DSegment3d segment = new DSegment3d(startPo, endPo);//声明几何直线
					LineElement line = new LineElement(dgnModel, null, segment);//声明线元素
																				//line.AddToModel();
					subElems.Add(line);//将线元素添加到列表中                   
				}

				for (int i = 0; i < col + 1; i++)//遍历
				{
					DPoint3d startPo = new DPoint3d(i * width, 0);//设置图表列线起点
					DPoint3d endPo = new DPoint3d(i * width, (-1) * row * height);//设置图表列线终点
					DSegment3d segment = new DSegment3d(startPo, endPo);//声明几何直线
					LineElement line = new LineElement(dgnModel, null, segment);//声明线元素
																				//line.AddToModel();
					subElems.Add(line);//将线元素添加到列表中                  
				}
				#endregion

				#region InsertDataToDataTable
				for (int i = 0; i < row; i++)//遍历
				{

					for (int j = 0; j < col; j++)//遍历
					{
						DPoint3d insertPo = new DPoint3d((j + 0.1) * width, (-1) * (i + 0.1) * height);//设置文字插入点

						TextBlockProperties txtBlockProp = new TextBlockProperties(dgnModel);//定义文本属性
						txtBlockProp.IsViewIndependent = false;//设置文本非独立于视图
						ParagraphProperties paraProp = new ParagraphProperties(dgnModel);//定义段落属性
						RunProperties runProp = new RunProperties(textStyle, dgnModel);//定义运行属性
						TextBlock txtBlock = new TextBlock(txtBlockProp, paraProp, runProp, dgnModel);//定义文本块
						txtBlock.AppendText(excel_message[i][j]);
						TextElement text = (TextElement)TextElement.CreateElement(null, txtBlock);//定义文本元素
						TransformInfo transform = new TransformInfo(DTransform3d.FromTranslation(insertPo));//声明变换信息
						text.ApplyTransform(transform);//对元素应用变换信息
						subElems.Add(text);//将元素添加到列表中
					}
				}
				#endregion

				#region MergeIntoCell
				Element m_textTableElem = new CellHeaderElement(dgnModel, "CustomDataTable", DPoint3d.Zero, DMatrix3d.Identity, subElems);//声明单元元素
				//m_textTableElem.AddToModel();
				return m_textTableElem;
				//m_textTableElem.DeleteFromModel();
				#endregion
			}
			catch(Exception ex)
            {
				MessageBox.Show(ex.ToString());
				return null;
            }
		}

	}

}
