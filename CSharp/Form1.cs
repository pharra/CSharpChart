﻿using System;
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
        private int selectedIndex;
        public Form1()
        {
            DataCollection dataCollection = new DataCollection();
            dataObject = dataCollection.GetDataObject();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("语言分析");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }



        private void button1_Click(object sender, EventArgs e)
        {
            switch (selectedIndex)
            {
                case 0://语言分析
                    {
                        Chart chart = new Chart();
                        chart.CsChart(dataObject);
                        List<string> xdata = chart.xData;
                        List<int> ydata = chart.yData;


                        Language.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
                        Language.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
                        Language.Series[0].Points.DataBindXY(xdata, ydata);
                    };
                    break;
                case 1://岗位类型
                    {

                    };
                    break;
            }

        }

        private void Language_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
