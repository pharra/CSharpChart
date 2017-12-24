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
        private void Form1_Load(Chart chart)
        {
            List<string> xdata = chart.xData;
            List<int> ydata = chart.yData;

            List<string> xData = xdata;
            List<int> yData = ydata;

            chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            chart1.Series[0].Points.DataBindXY(xData, yData);
        }

    }
}
