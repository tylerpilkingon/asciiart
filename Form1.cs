using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asciiart {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            //show dialog box
            DialogResult drgtemp = ofdLoadImage.ShowDialog();

            //check if user selected "open"
            if (drgtemp == DialogResult.OK) {
                //use selected file to open bitmap
                Bitmap bmptemp = new Bitmap(ofdLoadImage.FileName);

                //set bitmap to picturebox
                picImage.Image = bmptemp;

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            BitmapAscii test = new BitmapAscii();
            test.KernalHeight = (int) KernrelHeightBox.Value;
            test.KernalWidth = (int) KernalWidthBox.Value;
            Bitmap bmptemp = new Bitmap(picImage.Image);
            richTextBox1.Text = test.Asciitze(bmptemp);
        }
    }
}
