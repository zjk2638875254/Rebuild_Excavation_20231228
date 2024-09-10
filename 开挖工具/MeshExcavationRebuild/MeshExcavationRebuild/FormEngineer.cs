using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.MstnPlatformNET;
using ExcelLib;
using self_define;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeshExcavationRebuild
{
    public partial class FormEngineer : Form
    {
        public FormEngineer()
        {
            InitializeComponent();
        }
		private void Partition_Click(object sender, EventArgs e)
		{
			try
			{
				uint color_id = (uint)this.Local.Value;
				Func_Calculate.Area_Output(color_id);
			}
			catch (Exception ex)
			{
				string message_output = "放坡模块-立方体挖掘组件-create_buttom错误。\r\n";
				message_output += ex.ToString();
				Func_Init.Write_Log(message_output);
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000042CC File Offset: 0x000024CC
		private void CountZH_Click(object sender, EventArgs e)
		{
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				double single_area = Convert.ToDouble(this.Len.Value) * Convert.ToDouble(this.Len.Value);
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				for (uint i = 0U; i < agenda.GetCount(); i += 1U)
				{
					Element ele = agenda.GetEntry(i);
					bool flag = EC17.find_ecclass(ele, "支护信息");
					if (!flag)
					{
						MessageBox.Show("选中区存在未划分支护区面坡，请先为面坡划分支护区");
						break;
					}
					double area_num = 0.0;
					EC17.find_property_double(ele, "支护面积", ref area_num);
					double zhihu_num = area_num / single_area;
					zhihu_num = Math.Ceiling(zhihu_num);
					EC17.create_ec_double(ele, "锚杆数量", "锚杆数量", zhihu_num, "三维开挖工具_Mesh版");
					EC17.create_ec_double(ele, "梅花型锚杆间距", "梅花型锚杆间距", Convert.ToDouble(this.Len.Value), "三维开挖工具_Mesh版");
				}
			}
			catch (Exception ex)
			{
				Func_Init.Write_Log("Form_Engineer异常:\r\n" + ex.ToString());
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00004408 File Offset: 0x00002608
		private void CountSoil_Click(object sender, EventArgs e)
		{
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				Dictionary<double, double> area_dic = new Dictionary<double, double>();
				double thibk = Convert.ToDouble(this.Soil.Value);
				thibk /= 100.0;
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				for (uint i = 0U; i < agenda.GetCount(); i += 1U)
				{
					Element ele = agenda.GetEntry(i);
					bool flag = EC17.find_ecclass(ele, "支护信息");
					if (!flag)
					{
						MessageBox.Show("选中存在未划分支护区面坡，请重新选择");
						break;
					}
					double area_num = 0.0;
					EC17.find_property_double(ele, "支护面积", ref area_num);
					double soil_num = area_num * thibk;
					EC17.create_ec_double(ele, "喷混量m3", "喷混量m3", soil_num, "三维开挖工具_Mesh版");
					EC17.create_ec_double(ele, "喷混厚度cm", "喷混厚度cm", Convert.ToDouble(this.Soil.Value), "三维开挖工具_Mesh版");
				}
			}
			catch (Exception ex)
			{
				string message_output = "工程量计算-TagArea-CountZH_Click\r\n";
				message_output += ex.ToString();
				Func_Init.Write_Log(message_output);
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00004548 File Offset: 0x00002748
		private void CountFe_Click(object sender, EventArgs e)
		{
			try
			{
				DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
				Dictionary<double, double> area_dic = new Dictionary<double, double>();
				double single_area = Convert.ToDouble(this.FeLen.Value) * Convert.ToDouble(this.FeLen.Value);
				ElementAgenda agenda = new ElementAgenda();
				SelectionSetManager.BuildAgenda(ref agenda);
				for (uint i = 0U; i < agenda.GetCount(); i += 1U)
				{
					Element ele = agenda.GetEntry(i);
					bool flag = EC17.find_ecclass(ele, "支护信息");
					if (!flag)
					{
						MessageBox.Show("选中存在未划分支护区面坡，请重新选择");
						break;
					}
					double area_num = 0.0;
					EC17.find_property_double(ele, "支护面积", ref area_num);
					double fe_vol = area_num / single_area;
					fe_vol *= 2.0;
					bool flag2 = this.FeRadius.SelectedItem.ToString() == "6";
					if (flag2)
					{
						fe_vol = fe_vol * 0.222 / 1000.0;
					}
					else
					{
						bool flag3 = this.FeRadius.SelectedItem.ToString() == "8";
						if (flag3)
						{
							fe_vol = fe_vol * 0.395 / 1000.0;
						}
						else
						{
							bool flag4 = this.FeRadius.SelectedItem.ToString() == "10";
							if (flag4)
							{
								fe_vol = fe_vol * 0.617 / 1000.0;
							}
							else
							{
								bool flag5 = this.FeRadius.SelectedItem.ToString() == "12";
								if (flag5)
								{
									fe_vol = fe_vol * 0.888 / 1000.0;
								}
							}
						}
					}
					EC17.create_ec_double(ele, "钢筋网质量t", "钢筋网质量t", fe_vol, "三维开挖工具_Mesh版");
					EC17.create_ec_double(ele, "钢筋型号mm", "钢筋型号mm", Convert.ToDouble(this.FeRadius.SelectedItem.ToString()), "三维开挖工具_Mesh版");
					EC17.create_ec_double(ele, "钢筋间排距m", "钢筋间排距m", Convert.ToDouble(this.FeLen.Value), "三维开挖工具_Mesh版");
				}
			}
			catch (Exception ex)
			{
				string message_output = "工程量计算-TagArea-CountZH_Click\r\n";
				message_output += ex.ToString();
				Func_Init.Write_Log(message_output);
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000047C0 File Offset: 0x000029C0
		private void ExportMessage_Click(object sender, EventArgs e)
		{
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.EmptyAll();
			ModelElementsCollection elems = dgnModel.GetGraphicElements();
			Dictionary<string, double[]> area_dic = new Dictionary<string, double[]>();
			foreach (Element ele in elems)
			{
				bool flag = EC17.find_ecclass(ele, "支护信息");
				if (flag)
				{
					double e_id = 0.0;
					double e_area = 0.0;
					double bolts_num = 0.0;
					double concrete_weight = 0.0;
					double fe_vol = 0.0;
					EC17.find_property_double(ele, "支护区号", ref e_id);
					EC17.find_property_double(ele, "支护面积", ref e_area);
					EC17.find_property_double(ele, "锚杆数量", ref bolts_num);
					EC17.find_property_double(ele, "喷混量m3", ref concrete_weight);
					EC17.find_property_double(ele, "钢筋网质量t", ref fe_vol);

					double bolts_len = 0.0;
					EC17.find_property_double(ele, "梅花型锚杆间距", ref bolts_len);
					double concrete_height= 0.0;
					EC17.find_property_double(ele, "喷混厚度cm", ref concrete_height);
					double fe_type = 0.0;
					EC17.find_property_double(ele, "钢筋型号mm", ref fe_type);
					double fe_len = 0.0;
					EC17.find_property_double(ele, "钢筋间排距m", ref fe_len);
					bool flag2 = area_dic.ContainsKey(e_id.ToString());
					if (flag2)
					{
						double[] engineer_data = area_dic[e_id.ToString()];
						/*
						string[] array = engineer_data;
						int num = 0;
						array[num] += e_area.ToString();
						string[] array2 = engineer_data;
						int num2 = 1;
						array2[num2] += bolts_num.ToString();
						string[] array3 = engineer_data;
						int num3 = 2;
						array3[num3] += concrete_weight.ToString();
						string[] array4 = engineer_data;
						int num4 = 3;
						array4[num4] += fe_vol.ToString();
						*/

						engineer_data[0] += e_area;
						engineer_data[1] += bolts_num;
						engineer_data[2] += concrete_weight;
						engineer_data[3] += fe_vol;
						engineer_data[4] = bolts_len;
						engineer_data[5] = concrete_height;
						engineer_data[6] = fe_type;
						engineer_data[7] = fe_len;

						area_dic[e_id.ToString()] = engineer_data;
					}
					else
					{
						double[] engineer_data2 = new double[]
						{
							e_area,
							bolts_num,
							concrete_weight,
							fe_vol,
							bolts_len,
							concrete_height,
							fe_type,
							fe_len
						};
						area_dic[e_id.ToString()] = engineer_data2;
					}
				}
			}
			string[] name_list = new string[]
			{
				"支护面积/平方米",
				"锚杆数量",
				"喷混量/立方米",
				"钢筋网质量/吨",
				"梅花型锚杆间距",
				"喷混厚度cm",
				"钢筋型号mm",
				"钢筋间排距m"
			};
			string save_excel = excel_lib.save_filepath();
			Dictionary<string, string[]> save_dic = new Dictionary<string, string[]> { };
			foreach (string key in area_dic.Keys)
			{
				string[] values = new string[area_dic[key].Length];
				for (int i = 0; i < area_dic[key].Length; i++)
					values[i] = area_dic[key][i].ToString();
				save_dic[key] = values;
			}
			excel_lib.export_file(save_excel, save_dic, "Excavation_Export&ByDK", name_list);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000049F8 File Offset: 0x00002BF8
		private void Form_Engineer_Load(object sender, EventArgs e)
		{
			this.FeRadius.Items.Add("6");
			this.FeRadius.Items.Add("8");
			this.FeRadius.Items.Add("10");
			this.FeRadius.Items.Add("12");
		}

        private void ExcavationExport_Click(object sender, EventArgs e)
        {
			/*
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.EmptyAll();
			ModelElementsCollection elems = dgnModel.GetGraphicElements();
			string txt_message = "";
			string txt_path = save_txtpath();
			foreach (Element ele in elems)
			{
				bool flag = EC17.find_ecclass(ele, "开挖量");
				if (flag)
				{
					double vol = 0.0;
					string land_type = "";
					EC17.find_property_double(ele, "立方米", ref vol);
					EC17.find_property_string(ele, "地层名称", ref land_type);
					txt_message += "地层类别：" + land_type + " & " + "开挖量/立方米：" + vol.ToString() + "\r\n";
				}
			}
			write_txt(txt_path, txt_message);
			*/
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			ModelElementsCollection elems = dgnModel.GetGraphicElements();
			Dictionary<string, string[]> area_dic = new Dictionary<string, string[]>();
			foreach (Element ele in elems)
			{
				if (EC17.find_ecclass(ele, "开挖量"))
				{
					double vol = 0.0;
					string land_type = "";
					EC17.find_property_double(ele, "立方米", ref vol);
					EC17.find_property_string(ele, "地层名称", ref land_type);
					area_dic[ele.ElementId.ToString()] = new string[2];
					area_dic[ele.ElementId.ToString()][0] = land_type;
					area_dic[ele.ElementId.ToString()][1] = vol.ToString();
				}
			}
			string[] name_list = new string[]
			{
				"地层类型",
				"开挖量/立方米"
			};
			string save_excel = excel_lib.save_filepath();
			excel_lib.export_file(save_excel, area_dic, "Excavation_Export&ByDK", name_list);
		}

		private static string save_txtpath()
		{
			string result = "";
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			//打开的文件选择对话框上的标题
			saveFileDialog.Title = "请选择存储位置";
			//设置文件类型
			saveFileDialog.Filter = "*.txt(TXT文件)|*.txt";
			//设置默认文件类型显示顺序
			saveFileDialog.FilterIndex = 1;
			//保存对话框是否记忆上次打开的目录
			saveFileDialog.RestoreDirectory = true;
			//按下确定选择的按钮
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				//获得文件路径
				string localFilePath = saveFileDialog.FileName.ToString();
				System.IO.FileStream ft = System.IO.File.Create(localFilePath);
				ft.Close();
				result = localFilePath;
			}
			return result;
		}

		public static bool write_txt(string file, string message)
		{
			bool result;
			try
			{
				File.AppendAllText(file, message);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

        private void SetMessage_Click(object sender, EventArgs e)
        {
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			ElementAgenda agenda = new ElementAgenda();
			SelectionSetManager.EmptyAll();
			ModelElementsCollection elems = dgnModel.GetGraphicElements();
			SortedDictionary<string, double[]> area_dic = new SortedDictionary<string, double[]>();
			foreach (Element ele in elems)
			{
				bool flag = EC17.find_ecclass(ele, "支护信息");
				if (flag)
				{
					double e_id = 0.0;
					double e_area = 0.0;
					double bolts_num = 0.0;
					double concrete_weight = 0.0;
					double fe_vol = 0.0;
					EC17.find_property_double(ele, "支护区号", ref e_id);
					EC17.find_property_double(ele, "支护面积", ref e_area);
					EC17.find_property_double(ele, "锚杆数量", ref bolts_num);
					EC17.find_property_double(ele, "喷混量m3", ref concrete_weight);
					EC17.find_property_double(ele, "钢筋网质量t", ref fe_vol);

					double bolts_len = 0.0;
					EC17.find_property_double(ele, "梅花型锚杆间距", ref bolts_len);
					double concrete_height = 0.0;
					EC17.find_property_double(ele, "喷混厚度cm", ref concrete_height);
					double fe_type = 0.0;
					EC17.find_property_double(ele, "钢筋型号mm", ref fe_type);
					double fe_len = 0.0;
					EC17.find_property_double(ele, "钢筋间排距m", ref fe_len);
					bool flag2 = area_dic.ContainsKey(e_id.ToString());
					if (flag2)
					{
						double[] engineer_data = area_dic[e_id.ToString()];

						engineer_data[0] += e_area;
						engineer_data[1] += bolts_num;
						engineer_data[2] += concrete_weight;
						engineer_data[3] += fe_vol;
						engineer_data[4] = bolts_len;
						engineer_data[5] = concrete_height;
						engineer_data[6] = fe_type;
						engineer_data[7] = fe_len;

						area_dic[e_id.ToString()] = engineer_data;
					}
					else
					{
						double[] engineer_data2 = new double[]
						{
							e_area,
							bolts_num,
							concrete_weight,
							fe_vol,
							bolts_len,
							concrete_height,
							fe_type,
							fe_len
						};
						area_dic[e_id.ToString()] = engineer_data2;
					}
				}
			}
			string[] name_list = new string[]
			{
				"支护区号",
				"支护面积/平方米",
				"锚杆数量",
				"喷混量/立方米",
				"钢筋网质量/吨",
				"梅花型锚杆间距",
				"喷混厚度cm",
				"钢筋型号mm",
				"钢筋间排距m"
			};
			string[][] excel_message = new string[area_dic.Keys.Count + 1][];
			excel_message[0] = name_list;
			int id = 1;
			foreach (KeyValuePair<string, double[]> item in area_dic)
			{
				string[] area_data = new string[9];
				area_data[0] = item.Key;
				double[] datas = item.Value;
				area_data[1] = datas[0].ToString();
				area_data[2] = datas[1].ToString();
				area_data[3] = datas[2].ToString();
				area_data[4] = datas[3].ToString();
				area_data[5] = datas[4].ToString();
				area_data[6] = datas[5].ToString();
				area_data[7] = datas[6].ToString();
				area_data[8] = datas[7].ToString();
				excel_message[id] = area_data;
				id++;
			}
			SetElement.InstallNewInstance(60000, 6000, name_list, excel_message);
		}

        private void ExcavationSet_Click(object sender, EventArgs e)
        {
			DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
			ModelElementsCollection elems = dgnModel.GetGraphicElements();
			SortedDictionary<double, string> area_dic = new SortedDictionary<double, string>();
			foreach (Element ele in elems)
			{
				if (EC17.find_ecclass(ele, "开挖量"))
				{
					double vol = 0.0;
					string land_type = "";
					EC17.find_property_double(ele, "立方米", ref vol);
					EC17.find_property_string(ele, "地层名称", ref land_type);
					area_dic[vol] = land_type;
				}
			}
			string[][] excavation_message = new string[area_dic.Count + 1][];
			excavation_message[0] = new string[]
			{
				"地层类型",
				"开挖量/立方米"
			};
			int id = 1;
			foreach (KeyValuePair<double, string> data in area_dic)
			{
				excavation_message[id] = new string[] { data.Value, data.Key.ToString("f4") };
				id++;
			}
			//MessageBox.Show(excavation_message.ToString());
			for (int i = 0; i < excavation_message.Length; i++)
				MessageBox.Show(excavation_message[0] + "   " + excavation_message[1]);
			for (int i = area_dic.Count; i > 1; i--)
			{
				excavation_message[i][1] = (Convert.ToDouble(excavation_message[i][1]) - Convert.ToDouble(excavation_message[i - 1][1])).ToString();
			}
			string[] name_list = new string[] { "地层类型", "开挖量/立方米" };
			SetElement.InstallNewInstance(60000, 6000, name_list, excavation_message);
		}
    }
}
