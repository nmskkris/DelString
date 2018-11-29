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

namespace DelString
{
    public partial class Form1 : Form
    {
        private string fnameS;
        private string fnameD;
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "текстовые файлы (*.txt)|*.txt";
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            ofd.ShowDialog();
            fnameS = ofd.FileName;
            fnameD = fnameS + "_";

            List<string> lines = new List<string>();

            //FileStream fs = null;
            //fs = new FileStream(fnameD, FileMode.Create);
            //System.IO.StreamWriter filed = new System.IO.StreamWriter(fs, Encoding.GetEncoding(1251));
            System.IO.StreamReader file = new System.IO.StreamReader(fnameS, Encoding.GetEncoding(1251));
            while (!file.EndOfStream)
            {
                string str = file.ReadLine();

                if (!str.Contains(";"))
                    continue;

                if (str.Substring(0, str.IndexOf(";")).Contains("-"))
                    continue;

              //  filed.WriteLine(str);

                lines.Add(str);
                    counter++;
            }
            //if (fs != null)
              //  fs.Dispose();
            File.WriteAllLines(fnameD, lines, Encoding.GetEncoding(1251));
        }
    }
}
