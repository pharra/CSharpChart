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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 二级菜单三级菜单预设隐藏
            comboBox2.Hide();
            comboBox3.Hide();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            // 展示二级菜单
            comboBox2.Show();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    comboBox2.Items.AddRange(new string[] { "按地址分布招聘需求", "技术栈种类和数目", "语言种类和数目", "工作岗位需求和数目" });
                    break;
                case 1:
                    comboBox2.Items.AddRange(dataObject.CompanyObject.Keys.ToArray());
                    break;
                case 2:
                    comboBox2.Items.AddRange(dataObject.AddressObject.Keys.ToArray());
                    break;
                default:
                    MessageBox.Show("未知错误！请重新选择");
                    return;
            }
            // 二级菜单默认选中第0项
            comboBox2.SelectedIndex = 0;
        }
    }
}
