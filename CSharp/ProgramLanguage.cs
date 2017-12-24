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

//职业技能
namespace CSharp
{
    public partial class ProgramLanguage : Form
    {
        public ProgramLanguage()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {


            List<string> xData = new List<string>() { "A", "B", "C", "D" };
            List<int> yData = new List<int>() { 10, 20, 30, 40 };


            chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            chart1.Series[0].Points.DataBindXY(xData, yData);
        }

    }
}
