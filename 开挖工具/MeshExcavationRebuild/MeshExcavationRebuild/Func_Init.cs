using System;
using System.IO;
using Bentley.DgnPlatformNET;
using Bentley.MstnPlatformNET;
using self_define;

namespace MeshExcavationRebuild
{
	// Token: 0x02000011 RID: 17
	internal class Func_Init
	{
		// Token: 0x06000082 RID: 130 RVA: 0x0000E5F0 File Offset: 0x0000C7F0
		public static bool Write_Log(string wrong_message)
		{
			bool result;
			try
			{
				File.AppendAllText("D://开挖工具Mesh版错误日志", wrong_message);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000E628 File Offset: 0x0000C828
		public static bool init_tagStyle()
		{
			bool result;
			try
			{
				double meter_rate = Session.Instance.GetActiveDgnModel().GetModelInfo().UorPerMeter;
				DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
				DgnTextStyle style = new DgnTextStyle("ExcavationStyle", dgnFile);
				style.SetProperty(TextStyleProperty.Width, 5.0 * meter_rate);
				style.SetProperty(TextStyleProperty.Height, 5.0 * meter_rate);
				style.Add(dgnFile);
				Func_Init.refresh_style("ExcavationStyle_Level1", 0.4);
				Func_Init.refresh_style("ExcavationStyle_Level2", 1.6);
				Func_Init.refresh_style("ExcavationStyle_Level3", 6.4);
				Func_Init.refresh_style("ExcavationStyle_Level4", 25.6);
				result = true;
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString());
				result = false;
			}
			return result;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000E70C File Offset: 0x0000C90C
		public static bool init_schema()
		{
			bool result;
			try
			{
				EC17.init_schema("三维开挖工具_Mesh版", 1, 1);
				EC17.refresh_schema_double(1, 1, "开挖量", "立方米", "三维开挖工具_Mesh版");
				EC17.refresh_schema_string(1, 1, "开挖量", "地层名称", "三维开挖工具_Mesh版");
				EC17.refresh_schema_double(1, 1, "坡比", "坡比", "三维开挖工具_Mesh版");
				EC17.refresh_schema_string(1, 1, "坡比", "基线", "三维开挖工具_Mesh版");
				EC17.refresh_schema_string(1, 1, "支护信息", "支护区号", "三维开挖工具_Mesh版");
				EC17.refresh_schema_string(1, 1, "支护信息", "支护面积", "三维开挖工具_Mesh版");
				EC17.refresh_schema_double(1, 1, "锚杆数量", "锚杆数量", "三维开挖工具_Mesh版");
				EC17.refresh_schema_double(1, 1, "梅花型锚杆间距", "梅花型锚杆间距", "三维开挖工具_Mesh版");
				EC17.refresh_schema_double(1, 1, "喷混量m3", "喷混量m3", "三维开挖工具_Mesh版");
				EC17.refresh_schema_double(1, 1, "喷混厚度cm", "喷混厚度cm", "三维开挖工具_Mesh版");
				EC17.refresh_schema_double(1, 1, "钢筋网质量t", "钢筋网质量t", "三维开挖工具_Mesh版");
				EC17.refresh_schema_double(1, 1, "钢筋型号mm", "钢筋型号mm", "三维开挖工具_Mesh版");
				EC17.refresh_schema_double(1, 1, "钢筋间排距m", "钢筋间排距m", "三维开挖工具_Mesh版");
				EC17.refresh_schema_double(1, 1, "桩号", "时间戳", "三维开挖工具_Mesh版");
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000E87C File Offset: 0x0000CA7C
		public static bool init_level()
		{
			bool result;
			try
			{
				DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				FileLevelCache flc = dgnModel.GetFileLevelCache();
				EditLevelHandle line_level = flc.CreateLevel("ExcavationMesh放坡线");
				LevelDefinitionColor levelColor = new LevelDefinitionColor(3U, dgnFile);
				line_level.SetByLevelColor(levelColor);
				EditLevelHandle simply_level = flc.CreateLevel("ExcavationMesh简化边界线");
				LevelDefinitionColor levelColor2 = new LevelDefinitionColor(7U, dgnFile);
				line_level.SetByLevelColor(levelColor2);
				flc.Write();
				result = true;
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log(ex.ToString() + "\r\n");
				result = false;
			}
			return result;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000E924 File Offset: 0x0000CB24
		private static bool refresh_style(string style_name, double value)
		{
			bool result;
			try
			{
				double meter_rate = Session.Instance.GetActiveDgnModel().GetModelInfo().UorPerMeter;
				DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
				DgnTextStyle style = DgnTextStyle.GetByName(style_name, dgnFile);
				bool flag = style == null;
				if (flag)
				{
					DgnTextStyle style_level = new DgnTextStyle(style_name, dgnFile);
					style_level.SetProperty(TextStyleProperty.Width, value * meter_rate);
					style_level.SetProperty(TextStyleProperty.Height, value * meter_rate);
					style_level.Add(dgnFile);
				}
				else
				{
					style.SetProperty(TextStyleProperty.Width, value * meter_rate);
					style.SetProperty(TextStyleProperty.Height, value * meter_rate);
					style.Replace(style_name, dgnFile);
				}
				result = true;
			}
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}
	}
}
