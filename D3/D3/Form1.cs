using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            using (var fs = new FileStream("file.txt",FileMode.Open,FileAccess.Read))
            {
                var bytes = new byte[100];
                progressBar1.Step = bytes.Length;
                progressBar1.Maximum = (int)fs.Length;
                while(fs.Position != fs.Length) {
                    progressBar1.PerformStep();
                    label1.Text = progressBar1.Value.ToString();
                    this.Update();
                    Thread.Sleep(50);
                }
            }
        }
    }
}
