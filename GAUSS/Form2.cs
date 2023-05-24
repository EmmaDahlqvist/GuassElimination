using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAUSS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(isNumber(x1.Text) && isNumber(x2.Text) && isNumber(y1.Text) && isNumber(y2.Text) && isNumber(a1.Text) && isNumber(a2.Text))
            {

                Form1.defr1c1 = x1.Text;
                Form1.defr1c2 = y1.Text;
                Form1.defr1c3 = a1.Text;

                Form1.defr2c1 = x2.Text;
                Form1.defr2c2 = y2.Text;
                Form1.defr2c3 = a2.Text;

                Form1 form1 = new Form1();

                Hide();
                form1.ShowDialog();
                Show();

            } else
            {
                errorTxt.Text = "Du måste ange korrekta siffror!";
            }
        }

        private bool isNumber(string numString)
        {
            bool isNum;
            isNum = int.TryParse(numString, out int num);
            return isNum;
        }
    }
}
