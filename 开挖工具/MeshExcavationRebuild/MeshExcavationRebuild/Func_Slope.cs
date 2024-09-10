using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using Bentley.MstnPlatformNET.InteropServices;
using self_define;

namespace MeshExcavationRebuild
{
	// Token: 0x02000013 RID: 19
	internal class Func_Slope
	{
		// Token: 0x06000098 RID: 152 RVA: 0x000122A8 File Offset: 0x000104A8
		public static void BaseLine_Relative(double fp_height, double fp_rate, double meter_rate, DPoint3d center_point)
		{
			long high_line_id = 0L;
			ElementId para_id = (ElementId)high_line_id;
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			for (uint i = 0U; i < agenda.GetCount(); i += 1U)
			{
				Func_Slope.baseline_relative(agenda.GetEntry(i), fp_height, fp_rate, ref para_id, meter_rate, center_point);
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000122FC File Offset: 0x000104FC
		public static void BaseLine_Absolute(double fp_height, double fp_rate, double meter_rate, DPoint3d element_center)
		{
			long high_line_id = 0L;
			ElementId para_id = (ElementId)high_line_id;
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			for (uint i = 0U; i < agenda.GetCount(); i += 1U)
			{
				double low_height = 0.0;
				bool flag = Func_Calculate.get_low(agenda.GetEntry(i), ref low_height);
				double h = fp_height - low_height / meter_rate;
				bool flag2 = h > 0.0;
				if (flag2)
				{
					Func_Slope.baseline_absolute(agenda.GetEntry(i), h, fp_rate, ref para_id, meter_rate, element_center);
				}
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00012384 File Offset: 0x00010584
		public static void BaseLine_Relative90(double fp_height, double meter_rate, DPoint3d element_center)
		{
			long high_line_id = 0L;
			ElementId para_id = (ElementId)high_line_id;
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			for (uint i = 0U; i < agenda.GetCount(); i += 1U)
			{
				Func_Slope.baseline_relative90(agenda.GetEntry(i), fp_height, ref para_id, meter_rate, element_center);
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000123D8 File Offset: 0x000105D8
		public static void BaseLine_Absolute90(double fp_height, double meter_rate, DPoint3d element_center)
		{
			long high_line_id = 0L;
			ElementId para_id = (ElementId)high_line_id;
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			for (uint i = 0U; i < agenda.GetCount(); i += 1U)
			{
				Func_Slope.baseline_absolute90(agenda.GetEntry(i), fp_height, ref para_id, meter_rate, element_center);
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0001242C File Offset: 0x0001062C
		public static void HorseLine_Slope(double fp_width, double meter_rate, DPoint3d center_point)
		{
			long high_line_id = 0L;
			ElementId para_id = (ElementId)high_line_id;
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			for (uint i = 0U; i < agenda.GetCount(); i += 1U)
			{
				Func_Slope.slope_horseline(agenda.GetEntry(i), fp_width, ref para_id, meter_rate, center_point);
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00012480 File Offset: 0x00010680
		public static void Multy_HorseLine(double fp_width, double fp_height, double fp_rate, double level, double meter_rate, DPoint3d element_center)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			int num = 0;
			for (uint i = 0U; i < agenda.GetCount(); i += 1U)
			{
				bool flag = agenda.GetEntry(i).ElementType == MSElementType.Line;
				if (flag)
				{
					num++;
				}
			}
			Element[] line_element = new Element[num];
			int line_id = 0;
			for (uint j = 0U; j < agenda.GetCount(); j += 1U)
			{
				bool flag2 = agenda.GetEntry(j).ElementType == MSElementType.Line;
				if (flag2)
				{
					line_element[line_id] = agenda.GetEntry(j);
					line_id++;
				}
			}
			int k = 0;
			while ((double)k < level)
			{
				Element[] upper_element = new Element[num];
				for (int l = 0; l < num; l++)
				{
					long default_long = 0L;
					ElementId default_lineid = (ElementId)default_long;
					LineElement line = line_element[l] as LineElement;
					Func_Slope.baseline_relative(line, fp_height, fp_rate, ref default_lineid, meter_rate, element_center);
					Element new_line = dgnModel.FindElementById(default_lineid);
					bool flag3 = new_line == null;
					if (flag3)
					{
						MessageBox.Show("id:" + line.ElementId.ToString() + "错误");
						return;
					}
					upper_element[l] = new_line;
				}
				for (int m = 0; m < num - 1; m++)
				{
					LineElement line2 = upper_element[m] as LineElement;
					LineElement line3 = upper_element[m + 1] as LineElement;
					Math17.line_merge(line2, line3);
				}
				LineElement final_line1 = upper_element[num - 1] as LineElement;
				LineElement final_line2 = upper_element[0] as LineElement;
				Math17.line_merge(final_line1, final_line2);
				for (int n = 0; n < num; n++)
				{
					Element ele = upper_element[n];
					line_element[n] = ele;
				}
				for (int j2 = 0; j2 < num; j2++)
				{
					long default_long2 = 0L;
					ElementId default_lineid2 = (ElementId)default_long2;
					LineElement line4 = line_element[j2] as LineElement;
					Func_Slope.slope_horseline(line4, fp_width, ref default_lineid2, meter_rate, element_center);
					Element new_line2 = dgnModel.FindElementById(default_lineid2);
					bool flag4 = new_line2 == null;
					if (flag4)
					{
						MessageBox.Show("id:" + line4.ElementId.ToString() + "错误");
						return;
					}
					upper_element[j2] = new_line2;
				}
				for (int j3 = 0; j3 < num - 1; j3++)
				{
					LineElement line5 = upper_element[j3] as LineElement;
					LineElement line6 = upper_element[j3 + 1] as LineElement;
					Math17.line_merge(line5, line6);
				}
				LineElement final_horse1 = upper_element[num - 1] as LineElement;
				LineElement final_horse2 = upper_element[0] as LineElement;
				Math17.line_merge(final_horse1, final_horse2);
				for (int j4 = 0; j4 < num; j4++)
				{
					Element ele2 = upper_element[j4];
					line_element[j4] = ele2;
				}
				k++;
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00012740 File Offset: 0x00010940
		public static bool Line_Merge()
		{
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.BuildAgenda(ref agenda);
			bool flag = agenda.GetCount() < 2U;
			bool result2;
			if (flag)
			{
				string message_output = "放坡模块-直线拟合组件-Line_Merge-选择元素少于2。\r\n";
				Func_Init.Write_Log(message_output);
				result2 = false;
			}
			else
			{
				bool result = true;
				List<ElementId> aganda_list = new List<ElementId>();
				for (uint i = 0U; i < agenda.GetCount(); i += 1U)
				{
					aganda_list.Add(agenda.GetEntry(i).ElementId);
				}
				int j = 0;
				while ((long)j < (long)((ulong)(agenda.GetCount() - 1U)))
				{
					DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
					Element line = dgnModel.FindElementById(aganda_list[j]);
					Element line2 = dgnModel.FindElementById(aganda_list[j + 1]);
					bool temp_result = false;
					bool flag2 = line.ElementType == MSElementType.Line && line2.ElementType == MSElementType.Line;
					if (flag2)
					{
						LineElement l = (LineElement)line;
						LineElement l2 = (LineElement)line2;
						bool flag3 = !Math17.line_merge(l, l2);
						if (flag3)
						{
							string message_output2 = "放坡模块-直线拟合组件-Line_Merge-错误-线拟合错误：\r\n";
							message_output2 = string.Concat(new string[]
							{
								message_output2,
								"ElementId1：",
								line.ElementId.ToString(),
								"   ElementId2：",
								line2.ElementId.ToString(),
								"   \r\n"
							});
							Func_Init.Write_Log(message_output2);
						}
					}
					else
					{
						string message_output3 = "放坡模块-直线拟合组件-Line_Merge-错误:所选元素存在非直线元素\r\n";
						Func_Init.Write_Log(message_output3);
					}
					bool flag4 = !temp_result;
					if (flag4)
					{
						result = false;
					}
					j++;
				}
				result2 = result;
			}
			return result2;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000128EC File Offset: 0x00010AEC
		public static bool Convert_Arc(double fp_radius, double meter_rate)
		{
			try
			{
				fp_radius *= meter_rate;
				Session.Instance.Keyin("FILLET ICON");
				Utilities.ComApp.SetCExpressionValue("tcb->fillet_radius", fp_radius, "");
				Utilities.ComApp.SetCExpressionValue("tcb->msToolSettings.fillet.truncation", 2, "");
				Session.Instance.Keyin("FILLET ICON");
			}
			catch (Exception e)
			{
				string message_output = "放坡模块-弧线倒角-Bentley_Add_Arc-Catch:。\r\n";
				Func_Init.Write_Log(message_output);
				Func_Init.Write_Log(e.ToString());
				return false;
			}
			return true;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00012990 File Offset: 0x00010B90
		private static bool create_base(LineElement original_line, double height, double width, ref ElementId high_id, double meter_rate, DPoint3d element_center)
		{
			try
			{
				height *= meter_rate;
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DSegment3d seg;
				original_line.GetCurveVector().GetAt(0).TryGetLine(out seg);
				DPoint3d sp = seg.StartPoint;
				DPoint3d ep = seg.EndPoint;
				double direction_x = sp.X - ep.X;
				double direction_y = sp.Y - ep.Y;
				double mode_direction = Math.Sqrt(direction_x * direction_x + direction_y * direction_y);
				double move_x = -1.0 * direction_y / mode_direction;
				double move_y = direction_x / mode_direction;
				double move_x2 = direction_y / mode_direction;
				double move_y2 = -1.0 * direction_x / mode_direction;
				double unit_modex = direction_x / mode_direction;
				double unit_modey = direction_y / mode_direction;
				double len = Math.Sqrt((sp.X - element_center.X) * (sp.X - element_center.X) + (sp.Y - element_center.Y) * (sp.Y - element_center.Y));
				double len2 = Math.Sqrt((sp.X + move_x - element_center.X) * (sp.X + move_x - element_center.X) + (sp.Y + move_y - element_center.Y) * (sp.Y + move_y - element_center.Y));
				double move_len = width * meter_rate;
				DPoint3d p = DPoint3d.Zero;
				DPoint3d p2 = DPoint3d.Zero;
				bool flag = len2 > len;
				if (flag)
				{
					p.X = sp.X + move_x * move_len - mode_direction * 0.4 * unit_modex;
					p.Y = sp.Y + move_y * move_len - mode_direction * 0.4 * unit_modey;
					p.Z = sp.Z + height;
					p2.X = ep.X + move_x * move_len + mode_direction * 0.4 * unit_modex;
					p2.Y = ep.Y + move_y * move_len + mode_direction * 0.4 * unit_modey;
					p2.Z = ep.Z + height;
				}
				else
				{
					p.X = sp.X + move_x2 * move_len - mode_direction * 0.4 * unit_modex;
					p.Y = sp.Y + move_y2 * move_len - mode_direction * 0.4 * unit_modey;
					p.Z = sp.Z + height;
					p2.X = ep.X + move_x2 * move_len + mode_direction * 0.4 * unit_modex;
					p2.Y = ep.Y + move_y2 * move_len + mode_direction * 0.4 * unit_modey;
					p2.Z = ep.Z + height;
				}
				DSegment3d intersection_seg = new DSegment3d(p, p2);
				LineElement new_line = new LineElement(dgnModel, null, intersection_seg);
				new_line.AddToModel();
				Func_Slope.Revise_ele_level(new_line, "ExcavationMesh放坡线");
				high_id = new_line.ElementId;
				double rate = width * meter_rate / height;
				EC17.create_ec_double(new_line, "坡比", "坡比", rate, "三维开挖工具_Mesh版");
				EC17.create_ec_string(new_line, "坡比", "基线", original_line.ElementId.ToString(), "三维开挖工具_Mesh版");
			}
			catch (Exception ex)
			{
				string message_output = "放坡模块-基线放坡模块-Move_Line-Catch：\r\n";
				message_output = message_output + ex.ToString() + "\r\n";
				Func_Init.Write_Log(message_output);
				return false;
			}
			return true;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00012D50 File Offset: 0x00010F50
		private static bool slope_horseline(Element ele, double width, ref ElementId high_id, double meter_rate, DPoint3d element_center)
		{
			bool flag = ele.ElementType == MSElementType.Line;
			if (flag)
			{
				LineElement line = ele as LineElement;
				bool flag2 = !Func_Slope.create_horse(line, width, ref high_id, meter_rate, element_center);
				if (flag2)
				{
					string Message_out = "";
					Message_out += "放坡模块-基线放坡模块-Base_Line_Move-Create_line-返回值异常\r\n";
					Func_Init.Write_Log(Message_out);
					return true;
				}
			}
			else
			{
				string Message_out2 = "";
				Message_out2 = Message_out2 + "所选元素类型异常。" + ele.ElementType.ToString() + "\r\n";
				Func_Init.Write_Log(Message_out2);
			}
			return false;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00012DE8 File Offset: 0x00010FE8
		private static bool create_horse(LineElement original_line, double width, ref ElementId high_id, double meter_rate, DPoint3d element_center)
		{
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DSegment3d seg;
				original_line.GetCurveVector().GetAt(0).TryGetLine(out seg);
				DPoint3d sp = seg.StartPoint;
				DPoint3d ep = seg.EndPoint;
				double direction_x = sp.X - ep.X;
				double direction_y = sp.Y - ep.Y;
				double mode_direction = Math.Sqrt(direction_x * direction_x + direction_y * direction_y);
				double move_x = -1.0 * direction_y / mode_direction;
				double move_y = direction_x / mode_direction;
				double move_x2 = direction_y / mode_direction;
				double move_y2 = -1.0 * direction_x / mode_direction;
				double unit_modex = direction_x / mode_direction;
				double unit_modey = direction_y / mode_direction;
				double len = Math.Sqrt((sp.X - element_center.X) * (sp.X - element_center.X) + (sp.Y - element_center.Y) * (sp.Y - element_center.Y));
				double len2 = Math.Sqrt((sp.X + move_x - element_center.X) * (sp.X + move_x - element_center.X) + (sp.Y + move_y - element_center.Y) * (sp.Y + move_y - element_center.Y));
				double move_len = width * meter_rate;
				DPoint3d p = DPoint3d.Zero;
				DPoint3d p2 = DPoint3d.Zero;
				bool flag = len2 > len;
				if (flag)
				{
					p.X = sp.X + move_x * move_len - mode_direction * 0.4 * unit_modex;
					p.Y = sp.Y + move_y * move_len - mode_direction * 0.4 * unit_modey;
					p2.X = ep.X + move_x * move_len + mode_direction * 0.4 * unit_modex;
					p2.Y = ep.Y + move_y * move_len + mode_direction * 0.4 * unit_modey;
					p.Z = sp.Z;
					p2.Z = ep.Z;
				}
				else
				{
					p.X = sp.X + move_x2 * move_len - mode_direction * 0.4 * unit_modex;
					p.Y = sp.Y + move_y2 * move_len - mode_direction * 0.4 * unit_modey;
					p2.X = ep.X + move_x2 * move_len + mode_direction * 0.4 * unit_modex;
					p2.Y = ep.Y + move_y2 * move_len + mode_direction * 0.4 * unit_modey;
					p.Z = sp.Z;
					p2.Z = ep.Z;
				}
				DSegment3d intersection_seg = new DSegment3d(p, p2);
				LineElement new_line = new LineElement(dgnModel, null, intersection_seg);
				new_line.AddToModel();
				Func_Slope.Revise_ele_level(new_line, "ExcavationMesh放坡线");
				EC17.create_ec_double(new_line, "坡比", "坡比", 0.0, "三维开挖工具_Mesh版");
				EC17.create_ec_string(new_line, "坡比", "基线", original_line.ElementId.ToString(), "三维开挖工具_Mesh版");
				high_id = new_line.ElementId;
			}
			catch (Exception ex)
			{
				string message_output = "放坡模块-基线放坡模块-Move_Line-Catch：\r\n";
				message_output = message_output + ex.ToString() + "\r\n";
				Func_Init.Write_Log(message_output);
				return false;
			}
			return true;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00013198 File Offset: 0x00011398
		private static void baseline_relative(Element ele, double height, double rate, ref ElementId high_id, double meter_rate, DPoint3d center_point)
		{
			double width = height * rate;
			bool flag = ele.ElementType == MSElementType.Line;
			if (flag)
			{
				LineElement line = ele as LineElement;
				bool flag2 = !Func_Slope.create_base(line, height, width, ref high_id, meter_rate, center_point);
				if (flag2)
				{
					string Message_out = "";
					Message_out += "放坡模块-基线放坡模块-Base_Line_Move-Create_line-返回值异常\r\n";
					Func_Init.Write_Log(Message_out);
				}
			}
			else
			{
				bool flag3 = ele.ElementType == MSElementType.Arc;
				if (!flag3)
				{
					string Message_out2 = "";
					Message_out2 = Message_out2 + "所选元素类型异常。" + ele.ElementType.ToString() + "\r\n";
					Func_Init.Write_Log(Message_out2);
				}
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00013244 File Offset: 0x00011444
		private static void baseline_relative90(Element ele, double height, ref ElementId high_id, double meter_rate, DPoint3d element_center)
		{
			bool flag = ele.ElementType == MSElementType.Line;
			if (flag)
			{
				LineElement line = ele as LineElement;
				bool flag2 = !Func_Slope.create_base90(line, height, ref high_id, meter_rate, element_center);
				if (flag2)
				{
					string Message_out = "";
					Message_out += "放坡模块-基线放坡模块-Base_Line_Move-Create_line-返回值异常\r\n";
					Func_Init.Write_Log(Message_out);
				}
			}
			else
			{
				bool flag3 = ele.ElementType == MSElementType.Arc;
				if (!flag3)
				{
					string Message_out2 = "";
					Message_out2 = Message_out2 + "所选元素类型异常。" + ele.ElementType.ToString() + "\r\n";
					Func_Init.Write_Log(Message_out2);
				}
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000132E8 File Offset: 0x000114E8
		private static void baseline_absolute90(Element ele, double height, ref ElementId high_id, double meter_rate, DPoint3d element_center)
		{
			bool flag = ele.ElementType == MSElementType.Line;
			if (flag)
			{
				LineElement line = ele as LineElement;
				bool flag2 = !Func_Slope.create_base90_special(line, height, ref high_id, meter_rate, element_center);
				if (flag2)
				{
					string Message_out = "";
					Message_out += "放坡模块-基线放坡模块-Base_Line_Move-Create_line-返回值异常\r\n";
					Func_Init.Write_Log(Message_out);
				}
			}
			else
			{
				bool flag3 = ele.ElementType == MSElementType.Arc;
				if (!flag3)
				{
					string Message_out2 = "";
					Message_out2 = Message_out2 + "所选元素类型异常。" + ele.ElementType.ToString() + "\r\n";
					Func_Init.Write_Log(Message_out2);
				}
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0001338C File Offset: 0x0001158C
		private static void baseline_absolute(Element ele, double height, double rate, ref ElementId high_id, double meter_rate, DPoint3d element_center)
		{
			double width = height * rate;
			bool flag = ele.ElementType == MSElementType.Line;
			if (flag)
			{
				LineElement line = ele as LineElement;
				bool flag2 = !Func_Slope.create_base_special(line, height, width, ref high_id, meter_rate, element_center);
				if (flag2)
				{
					string Message_out = "";
					Message_out += "放坡模块-基线放坡模块-Base_Line_Move-Create_line-返回值异常\r\n";
					Func_Init.Write_Log(Message_out);
				}
			}
			else
			{
				bool flag3 = ele.ElementType == MSElementType.Arc;
				if (!flag3)
				{
					string Message_out2 = "";
					Message_out2 = Message_out2 + "所选元素类型异常。" + ele.ElementType.ToString() + "\r\n";
					Func_Init.Write_Log(Message_out2);
				}
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00013438 File Offset: 0x00011638
		private static bool create_base_special(LineElement original_line, double height, double width, ref ElementId high_id, double meter_rate, DPoint3d element_center)
		{
			bool result;
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DSegment3d seg;
				original_line.GetCurveVector().GetAt(0).TryGetLine(out seg);
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
				double r2 = Math.Sqrt((sp.Z - ep.Z) * (sp.Z - ep.Z)) * width / height;
				double R = Math.Sqrt((sp.X - ep.X) * (sp.X - ep.X) + (sp.Y - ep.Y) * (sp.Y - ep.Y));
				double r3 = Math.Sqrt(R * R - r2 * r2);
				DVector2d vpart = new DVector2d(sp.X / 2.0 + ep.X / 2.0, sp.Y / 2.0 + ep.Y / 2.0);
				DVector2d vpart2 = new DVector2d((r3 * r3 - r2 * r2) / (2.0 * R * R) * (ep.X - sp.X), (r3 * r3 - r2 * r2) / (2.0 * R * R) * (ep.Y - sp.Y));
				DVector2d vpart3 = new DVector2d(Math.Sqrt(2.0 * (r3 * r3 + r2 * r2) / (R * R) - (r3 * r3 - r2 * r2) * (r3 * r3 - r2 * r2) / (R * R * R * R) - 1.0) / 2.0 * (ep.Y - sp.Y), Math.Sqrt(2.0 * (r3 * r3 + r2 * r2) / (R * R) - (r3 * r3 - r2 * r2) * (r3 * r3 - r2 * r2) / (R * R * R * R) - 1.0) / 2.0 * (sp.X - ep.X));
				DPoint3d p = new DPoint3d(vpart.X + vpart2.X + vpart3.X, vpart.Y + vpart2.Y + vpart3.Y, sp.Z);
				DPoint3d p2 = new DPoint3d(vpart.X + vpart2.X - vpart3.X, vpart.Y + vpart2.Y - vpart3.Y, sp.Z);
				double len = Math.Sqrt((p.X - element_center.X) * (p.X - element_center.X) + (p.Y - element_center.Y) * (p.Y - element_center.Y));
				double len2 = Math.Sqrt((p2.X - element_center.X) * (p2.X - element_center.X) + (p2.Y - element_center.Y) * (p2.Y - element_center.Y));
				bool flag2 = len < len2;
				if (flag2)
				{
					DSegment3d seg2 = new DSegment3d(sp, p);
					LineElement line = new LineElement(dgnModel, null, seg2);
					line.AddToModel();
					bool flag3 = !Func_Slope.create_base(line, height, width, ref high_id, meter_rate, element_center);
					if (flag3)
					{
						string Message_out = "";
						Message_out += "放坡模块-基线放坡模块-create_base_special-调用create_base过程异常-返回值异常\r\n";
						Func_Init.Write_Log(Message_out);
						MessageBox.Show("提示: 放坡失败，已自动生成辅助线。");
						return false;
					}
					line.DeleteFromModel();
				}
				else
				{
					DSegment3d seg3 = new DSegment3d(sp, p2);
					LineElement line2 = new LineElement(dgnModel, null, seg3);
					line2.AddToModel();
					bool flag4 = !Func_Slope.create_base(line2, height, width, ref high_id, meter_rate, element_center);
					if (flag4)
					{
						string Message_out2 = "";
						Message_out2 += "放坡模块-基线放坡模块-create_base_special-调用create_base过程异常-返回值异常\r\n";
						Func_Init.Write_Log(Message_out2);
						MessageBox.Show("提示: 放坡失败，已自动生成辅助线。");
						return false;
					}
					line2.DeleteFromModel();
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

		// Token: 0x060000A8 RID: 168 RVA: 0x000138F8 File Offset: 0x00011AF8
		private static bool create_base90(LineElement original_line, double height, ref ElementId high_id, double meter_rate, DPoint3d element_center)
		{
			try
			{
				height *= meter_rate;
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DSegment3d seg;
				original_line.GetCurveVector().GetAt(0).TryGetLine(out seg);
				DPoint3d sp = seg.StartPoint;
				DPoint3d ep = seg.EndPoint;
				DPoint3d p = DPoint3d.Zero;
				p.X = sp.X;
				p.Y = sp.Y;
				p.Z = sp.Z + height;
				DPoint3d p2 = DPoint3d.Zero;
				p2.X = ep.X;
				p2.Y = ep.Y;
				p2.Z = ep.Z + height;
				DSegment3d intersection_seg = new DSegment3d(p, p2);
				LineElement new_line = new LineElement(dgnModel, null, intersection_seg);
				new_line.AddToModel();
				Func_Slope.Revise_ele_level(new_line, "ExcavationMesh放坡线");
				high_id = new_line.ElementId;
			}
			catch (Exception ex)
			{
				string message_output = "放坡模块-基线放坡模块-Move_Line-Catch：\r\n";
				message_output = message_output + ex.ToString() + "\r\n";
				Func_Init.Write_Log(message_output);
				return false;
			}
			return true;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00013A28 File Offset: 0x00011C28
		private static bool create_base90_special(LineElement original_line, double height, ref ElementId high_id, double meter_rate, DPoint3d element_center)
		{
			try
			{
				height *= meter_rate;
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				DSegment3d seg;
				original_line.GetCurveVector().GetAt(0).TryGetLine(out seg);
				DPoint3d sp = seg.StartPoint;
				DPoint3d ep = seg.EndPoint;
				DPoint3d p = DPoint3d.Zero;
				DPoint3d p2 = DPoint3d.Zero;
				bool flag = p.Z < p2.Z;
				if (flag)
				{
					p.X = sp.X;
					p.Y = sp.Y;
					p.Z = sp.Z + height;
					p2.X = ep.X;
					p2.Y = ep.Y;
					p2.Z = sp.Z + height;
				}
				else
				{
					p.X = sp.X;
					p.Y = sp.Y;
					p.Z = ep.Z + height;
					p2.X = ep.X;
					p2.Y = ep.Y;
					p2.Z = ep.Z + height;
				}
				DSegment3d intersection_seg = new DSegment3d(p, p2);
				LineElement new_line = new LineElement(dgnModel, null, intersection_seg);
				new_line.AddToModel();
				Func_Slope.Revise_ele_level(new_line, "ExcavationMesh放坡线");
				high_id = new_line.ElementId;
			}
			catch (Exception ex)
			{
				string message_output = "放坡模块-基线放坡模块-Move_Line-Catch：\r\n";
				message_output = message_output + ex.ToString() + "\r\n";
				Func_Init.Write_Log(message_output);
				return false;
			}
			return true;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00013BDC File Offset: 0x00011DDC
		public static bool Revise_ele_level(Element ele, string level_name)
		{
			bool result;
			try
			{
				DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				FileLevelCache flc = dgnModel.GetFileLevelCache();
				Element oldEle = Element.GetFromElementRef(ele.GetNativeElementRef());
				LevelHandle level = flc.GetLevelByName(level_name);
				ElementPropertiesSetter setprop = new ElementPropertiesSetter();
				setprop.SetLevel(level.LevelId);
				setprop.Apply(ele);
				uint color_id = 10U;
				bool flag = level_name == "ExcavationMesh放坡线";
				if (flag)
				{
					color_id = 3U;
				}
				else
				{
					bool flag2 = level_name == "ExcavationMesh简化边界线";
					if (flag2)
					{
						color_id = 7U;
					}
				}
				ElementPropertiesSetter elePropSet = new ElementPropertiesSetter();
				elePropSet.SetColor(color_id);
				elePropSet.Apply(ele);
				ele.ReplaceInModel(oldEle);
				result = true;
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				result = false;
			}
			return result;
		}
		//暂时废弃
		public static bool Cut_line()
        {
			try
            {
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				if(agenda.GetCount() != 2 || agenda.GetEntry(0).ElementType != MSElementType.Line || agenda.GetEntry(1).ElementType != MSElementType.Line)
                {
					MessageBox.Show("请选择需要剪切的线");
					return false;
                }
				DSegment3d seg;
				LineElement line1 = agenda.GetEntry(0) as LineElement;
				LineElement line2 = agenda.GetEntry(1) as LineElement;
				line1.GetCurveVector().GetAt(0).TryGetLine(out seg);
				DPoint3d sp1 = seg.StartPoint;
				DPoint3d ep1 = seg.EndPoint;
				line2.GetCurveVector().GetAt(0).TryGetLine(out seg);
				DPoint3d sp2 = seg.StartPoint;
				DPoint3d ep2 = seg.EndPoint;
				return true;
            }
			catch(Exception ex)
            {
				return false;
            }			
        }
	}
}
