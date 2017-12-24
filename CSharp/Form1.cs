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
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("语言分析");
        }

        private void button1_Click(Chart chart)
        {
            List<string> xdata = chart.xData;
            List<int> ydata = chart.yData;

            List<string> xData = xdata;
            List<int> yData = ydata;

            Language.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            Language.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            Language.Series[0].Points.DataBindXY(xData, yData);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
