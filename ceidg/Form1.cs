using ceidg.Exceptions;
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

namespace ceidg
{
    public partial class Form1 : Form
    {
        protected Ceidg _ceidg { get; set; }

        public Form1()
        {
            InitializeComponent();
            _ceidg = new Ceidg();
        }

        private void load_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                _ceidg.LoadHtml(File.ReadAllText(openFileDialog.FileName));
            }

            try {
                subjectGrid.DataSource = _ceidg.GetSubjects();
            } catch (InvalidFileFormatException ex)
            {
                MessageBox.Show("It look like You try to load not support file format. Please try again");
            }
        }
    }
}
