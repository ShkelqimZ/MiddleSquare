using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Middle_Square_Method
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
        public string algoritmi(double seed)
        {
            double[] randomNumbers = new double[Convert.ToInt32(nmrNum.Value)];
            double var1 = double.Parse(txtSeed.Text);
            string show = "";
            for (int i = 0; i < nmrNum.Value;i++ )
            {
               
                string squareSeedz = "";
                string seedS = "";
                double squareSeed ;
                seedS = seed.ToString();
                
                squareSeed = double.Parse(seedS) * double.Parse(seedS);
                squareSeedz = squareSeed.ToString();
                string squareSeedzz = "";
                
                
                if (squareSeed.ToString().Length % 2 == 1 && seed.ToString().Length % 2 == 0)
                {
                    squareSeedz = "0" + squareSeedz;
                }
                else if (squareSeed.ToString().Length % 2 == 0 && seed.ToString().Length % 2 == 1 && seed.ToString().Length * 2 != squareSeed.ToString().Length)
                {
                    
                     for (int k = 0; k < ((var1 * var1).ToString().Length - squareSeedz.Length); k++)
                     {
                         squareSeedzz += "0";
                     }
                     squareSeedz = squareSeedzz + squareSeed;
                    
                }
                else if (squareSeed.ToString().Length % 2 == 0 && seed.ToString().Length % 2 == 1 && seed.ToString().Length<3)
                {
                    for (int k = 0; k < ((var1 * var1).ToString().Length - squareSeedz.Length); k++)
                     {
                         squareSeedzz += "0";
                     }
                     squareSeedz = squareSeedzz + squareSeed;
                }

                double middleD = 0;
                
                if (squareSeed.ToString().Length == 1 && seed.ToString().Length == 1)
                {
                    middleD = 0;
                }
                else
                {
                    
                    int NR = Convert.ToInt32(nmrDigits.Value) / 2;
                    int start = (squareSeedz.Length / 2) - NR;
                    int length = Convert.ToInt32(nmrDigits.Value);
                    
                    string middleNum = squareSeedz.Substring(start, length);
                    middleD = double.Parse(middleNum);
                }
                
                randomNumbers[i] += middleD;
                
                seed = middleD;

                if (seed.ToString().Length != nmrDigits.Value)
                {
                    for (int u = 0; u < nmrDigits.Value - seed.ToString().Length; u++)
                    {
                        show += "0";
                    }
                    show +=  randomNumbers[i] +" ";
                }
                else
                {
                    show += randomNumbers[i].ToString() + " ";
                }
            }

            return show;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (nmrDigits.Value==0)
            {
                MessageBox.Show("Please input the number of digits !","WARNING",MessageBoxButtons.OK);
            }
            else if (txtSeed.Text == "")
            {
                MessageBox.Show("Please input the seed number");
                txtSeed.Focus();
            }
            else if (nmrNum.Value==0)
            {
                MessageBox.Show("Please give the number of pseudorandom numbers you want !", "WARNING", MessageBoxButtons.OK);
            }
            else if (nmrDigits.Value%2==1)
            {
                MessageBox.Show("Accuracy for odd numbers are weak.\n Please input even number of digits !", "WARNING", MessageBoxButtons.OK);
                
                nmrDigits.Focus();
            }
            else if (txtSeed.Text.Length != nmrDigits.Value)
            {
                MessageBox.Show("Please, number of  seed's digits and number of digits you input are not equal !");
            }
            else
            {

                rtbOutput.Text += algoritmi(double.Parse(txtSeed.Text));
            }
            
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
       
       
    }
    
}
