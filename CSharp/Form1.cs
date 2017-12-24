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
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void 信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 职业技能ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramLanguage pl = new ProgramLanguage();
            pl.MdiParent = this;
            pl.Show();
        }

        private void 岗位需求ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TechnologyStack ts = new TechnologyStack();
            ts.MdiParent = this;
            ts.Show();
        }
    }
}
