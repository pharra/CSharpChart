using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CSharp
{
    public partial class Form1 : Form
    {
        private DataObject dataObject;
        public Form1()
        {
            DataCollection dataCollection = new DataCollection();
            dataObject = dataCollection.GetDataObject();
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }




        private void button1_Click(object sender, EventArgs e)
        {
            //根据不同的菜单栏生成图表
            chart1.Series[0].ChartType = SeriesChartType.Pie;
            if(comboBox1.SelectedIndex == 0)
            {
                Dictionary<List<string>,List<int>> data= Chart.ChartRender(dataObject.AllInfoObject[comboBox2.SelectedIndex]);
                chart1.Series[0].Points.DataBindXY(data.First().Key, data.First().Value);
                if(comboBox2.SelectedIndex == 3)
                {
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                }
                // 推荐分析
                richTextBox1.Text = DataAnalysis.LanguageAnalysis(dataObject);
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                DataInfoObject dataInfoObject = new DataInfoObject();
                dataObject.CompanyObject.TryGetValue(comboBox2.SelectedItem.ToString(), out dataInfoObject);
                Dictionary<List<string>, List<int>> data = Chart.ChartRender(dataInfoObject[comboBox3.SelectedIndex]);
                chart1.Series[0].Points.DataBindXY(data.First().Key, data.First().Value);
                if (comboBox3.SelectedIndex == 3)
                {
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                }
                // 推荐分析
                richTextBox1.Text = DataAnalysis.CompanyAnalysis(dataObject, comboBox2.SelectedItem.ToString());
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Dictionary<string, DataInfoObject> dictionary = new Dictionary<string, DataInfoObject>();
                DataInfoObject dataInfoObject = new DataInfoObject();
                dataObject.AddressObject.TryGetValue(comboBox2.SelectedItem.ToString(), out dictionary);
                dictionary.TryGetValue(comboBox3.SelectedItem.ToString(), out dataInfoObject);
                Dictionary<List<string>, List<int>> data = Chart.ChartRender(dataInfoObject[comboBox4.SelectedIndex + 1]);
                chart1.Series[0].Points.DataBindXY(data.First().Key, data.First().Value);
                if (comboBox4.SelectedIndex + 1 == 3)
                {
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                }
                // 推荐分析
                richTextBox1.Text = DataAnalysis.AddressAnalysis(dataObject, comboBox2.SelectedItem.ToString());
            }
        }

        private void Language_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // 动态生成菜单栏
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 二级菜单三级菜单预设隐藏
            comboBox2.Hide();
            comboBox3.Hide();
            comboBox4.Hide();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();

            // 展示二级菜单
            comboBox2.Show();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    comboBox2.Items.AddRange(new string[] { "按地址分布招聘需求", "技术栈种类和数目", "语言种类和数目", "工作岗位需求和数目" });
                    break;
                case 1:
                    comboBox2.Items.AddRange(dataObject.CompanyObject.Keys.ToArray());
                    comboBox3.Items.AddRange(new string[] { "按地址分布招聘需求", "技术栈种类和数目", "语言种类和数目", "工作岗位需求和数目" });
                    comboBox3.Show();
                    comboBox3.SelectedIndex = 0;
                    break;
                case 2:
                    comboBox2.Items.AddRange(dataObject.AddressObject.Keys.ToArray());
                    comboBox3.Items.AddRange(dataObject.CompanyObject.Keys.ToArray());
                    comboBox4.Items.AddRange(new string[] {"技术栈种类和数目", "语言种类和数目", "工作岗位需求和数目" });
                    comboBox3.Show();
                    comboBox4.Show();
                    comboBox3.SelectedIndex = 0;
                    comboBox4.SelectedIndex = 0;
                    break;
                default:
                    MessageBox.Show("未知错误！请重新选择");
                    return;
            }
            // 二级菜单默认选中第0项
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
