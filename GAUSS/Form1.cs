using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web;

namespace GAUSS
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent(); 


            //UPPDATERA FRÅN FORM2
            r1c1.Text = defr1c1;
            r1c2.Text = defr1c2;
            r1c3.Text = defr1c3;

            r2c1.Text = defr2c1;
            r2c2.Text = defr2c2;
            r2c3.Text = defr2c3;

        }

        //DEFAULT VÄRDEN
        public static string defr1c1;
        public static string defr1c2;
        public static string defr1c3;

        public static string defr2c1;
        public static string defr2c2;
        public static string defr2c3;


        //multiplicera rad
        private void apply_Click(object sender, EventArgs e)
        {
            double mult1 = GetMult(multiplyR1);
            double mult2 = GetMult(multiplyR2);

            if(mult1 != 0)
            {
                r1c1.Text = findFractionMult(r1c1.Text, multiplyR1.Text);
                r1c2.Text = findFractionMult(r1c2.Text, multiplyR1.Text);
                r1c3.Text = findFractionMult(r1c3.Text, multiplyR1.Text);
                multiplyR1.Text = "";
            } 

            if(mult2 != 0)
            {
                r2c1.Text = findFractionMult(r2c1.Text, multiplyR2.Text);
                r2c2.Text = findFractionMult(r2c2.Text, multiplyR2.Text);
                r2c3.Text = findFractionMult(r2c3.Text, multiplyR2.Text);
                multiplyR2.Text = "";
            }
        }

        //fungerande multiplikation med bråk (t.ex 1/2)
        private string findFractionMult(string num1, string num2)
        {
            string[] num1Split = num1.Split("/");
            string[] num2Split = num2.Split("/");

            int numerator = 1; //TÄLJARE
            int denominator = 1; //NÄMNARE

            if (num1Split.Length == 2 && num2Split.Length == 2) //båda är bråk
            {
                try
                {
                    numerator = int.Parse(num1Split[0]) * int.Parse(num2Split[0]);
                    denominator = int.Parse(num1Split[1]) * int.Parse(num2Split[1]);
                }
                catch {
                    ErrorText();
                }
            }
            else if (num1Split.Length == 1 && num2Split.Length == 2) //endast num 2 är bråk
            {
                try
                {
                    numerator = int.Parse(num1Split[0]) * int.Parse(num2Split[0]);
                    denominator = int.Parse(num2Split[1]);
                }
                catch {
                    ErrorText();
                }
            }
            else if (num1Split.Length == 2 && num2Split.Length == 1) //endast num 1 är bråk
            {
                try
                {
                    numerator = int.Parse(num1Split[0]) * int.Parse(num2Split[0]);
                    denominator = int.Parse(num1Split[1]);
                }
                catch
                {
                    ErrorText();

                }
            }
            else if (num1Split.Length == 1 && num2Split.Length == 1) //ingen är bråk
            {
                try
                {
                    numerator = int.Parse(num1Split[0]) * int.Parse(num2Split[0]);
                    denominator = 1;
                }
                catch {
                    ErrorText();
                }
            } else
            {
                ErrorText();
            }

            //Största gemensamma delare:
            int divisior = GCD(numerator, denominator);

            if (denominator/divisior == 1) //nämnaren är 1 skit i att skriva ut den liksom
            {
                return (numerator / divisior).ToString();
            } else
            {
                return (numerator / divisior).ToString() + "/" + (denominator / divisior).ToString();
            }

        }

        //få det tal som raden ska multipliceras med
        private double GetMult(TextBox textbox)
        {
            double mult = 0;

            if (textbox.Text != "")
            {
                if (textbox.Text.Contains("/")) {
                    string[] divisionparts = textbox.Text.Split('/'); 
                    if(divisionparts.Length == 2)
                    {
                        try
                        {
                            mult = double.Parse(divisionparts[0]) / double.Parse(divisionparts[1]);
                        } catch(Exception ex)
                        {
                            ErrorText();
                        }
                    }

                } 
                else
                {
                    try
                    {
                        mult = int.Parse(textbox.Text);
                    }
                    catch
                    {
                        ErrorText();
                    }
                }
            }

            return mult;
        }

        //hitta största gemensamma delare/
        private int GCD(int num1, int num2)
        {
            int Remainder;

            while (num2 != 0)
            {
                Remainder = num1 % num2;
                num1 = num2;
                num2 = Remainder;
            }

            return num1;
        }


        //byt rad
        private void button1_Click(object sender, EventArgs e)
        {
            string tempr1c1 = r1c1.Text;
            string tempr1c2 = r1c2.Text;
            string tempr1c3 = r1c3.Text;

            r1c1.Text = r2c1.Text;
            r1c2.Text = r2c2.Text;
            r1c3.Text = r2c3.Text;

            r2c1.Text = tempr1c1;
            r2c2.Text = tempr1c2;
            r2c3.Text = tempr1c3;

        }

        //multiplicera rad 1 och addera till rad 2
        private void addRow1toRow2_Click(object sender, EventArgs e)
        {
            string multString = row1mult.Text;

            r2c1.Text = findFractionAdd(findFractionMult(r1c1.Text, multString), r2c1.Text);
            r2c2.Text = findFractionAdd(findFractionMult(r1c2.Text, multString), r2c2.Text);
            r2c3.Text = findFractionAdd(findFractionMult(r1c3.Text, multString), r2c3.Text);

            row1mult.Text = "";
        }

        //multiplicera rad 2 och addera till rad 1
        private void addRow2toRow1_Click(object sender, EventArgs e)
        {
            string multString = row2mult.Text;

            r1c1.Text = findFractionAdd(findFractionMult(r2c1.Text, multString), r1c1.Text);
            r1c2.Text = findFractionAdd(findFractionMult(r2c2.Text, multString), r1c2.Text);
            r1c3.Text = findFractionAdd(findFractionMult(r2c3.Text, multString), r1c3.Text);

            row2mult.Text = "";

        }

        //fungerande addition mellan bråk. (Tex 1/2 + 1/3)
        private string findFractionAdd(string num1, string num2)
        {
            //det var inget bråk
            if(!num1.Contains("/") && !num2.Contains("/"))
            {
                return (int.Parse(num1) + int.Parse(num2)).ToString();
            }

            string[] num1Split = num1.Split("/");
            string[] num2Split = num2.Split("/");
            int numerator = 1; //täljare
            int denominator = 1; //nämnare

            if(num1Split.Length == 2 && num2Split.Length == 2) //två bråk
            {
                denominator = int.Parse(num1Split[1]) * int.Parse(num2Split[1]);
                int numerator1 = int.Parse(num1Split[0]) * int.Parse(num2Split[1]);
                int numerator2 = int.Parse(num2Split[0]) * int.Parse(num1Split[1]);
                numerator = numerator1 + numerator2;
            } else if(num1Split.Length == 1 && num1Split.Length == 2) //endast num 2 är bråk
            {
                denominator = int.Parse(num2Split[1]);
                int numerator1 = int.Parse(num1Split[0]) * int.Parse(num2Split[1]);
                int numerator2 = int.Parse(num2Split[0]);
                numerator = numerator1 + numerator2;
            } else if (num1Split.Length == 2 && num2Split.Length == 1) //endast num 1 är bråk
            {
                denominator = int.Parse(num1Split[1]);
                int numerator1 = denominator * int.Parse(num2Split[0]);
                int numerator2 = int.Parse(num1Split[0]);
                numerator = numerator1 + numerator2;
            }

            //största gemensamma delare
            int divisior = GCD(denominator, numerator);
            if(denominator/divisior == 1) //nämnaren är 1
            {
                return (numerator/divisior).ToString();
            } else
            {
                return (numerator / divisior).ToString() + "/" + (denominator / divisior).ToString();
            }

        }

        //resetta allt bara
        private void button2_Click(object sender, EventArgs e)
        {
            r1c1.Text = defr1c1;
            r1c2.Text = defr1c2;
            r1c3.Text = defr1c3;
            r2c1.Text = defr2c1;
            r2c2.Text = defr2c2;
            r2c3.Text = defr2c3;

            multiplyR1.Text = "";
            multiplyR2.Text = "";
            row1mult.Text = "";
            row2mult.Text = "";

        }

        //ERROR meddelande
        private void ErrorText()
        {
            errorTxt.Text = "Något gick fel!";
        }
    }
}