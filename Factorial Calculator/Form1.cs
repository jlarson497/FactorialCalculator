using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**************************************************************************************
 * This is a simple program that calculates a factorial using a loop.  The data is
 * stored in longs, however, the calculation will only be accurate until about
 * 20!, so there is validation in place to prevent the user going entering a number
 * over that.  The calculation uses a for loop to do the calculation.
 * 
 * Produced by Joseph Larson 
 * *************************************************************************************/

namespace Factorial_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Method for performing the calculation
        private long CalculateFactorial(long number)
        {
            long count = number;
            for (int i = 1; i < number; i++)
            {
                count = count * i; 

            }
            return count;
        }

        //click event handler for the calculate button
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!IsValidForm()) 
            {
                txtFactorial.Clear();
                return;
            }
            long number = long.Parse(txtNumber.Text);

            long result = CalculateFactorial(number);

            txtFactorial.Text = Convert.ToString(result);
            txtNumber.Clear();
            txtNumber.Focus();
        }

        //Range validation
        private bool IsWithinRange(TextBox textbox, string name, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textbox.Text);
            if (number > max || number < min)
            {
                MessageBox.Show(name + " must be between " + min.ToString() + " and " + max.ToString(), "Entry Error");
                textbox.Clear();
                textbox.Focus();
                return false;
            }

            return true;
        }

        //Data type validation
        public bool IsInt(TextBox textbox, string name)
        {
            int number = 0;
            if (int.TryParse(textbox.Text, out number))
            {
                return true;
            }
            else
	        {
                MessageBox.Show(name + " must be an integer.", "Entry Error");
                textbox.Clear();
                textbox.Focus();
                return false;
	        }
                
        }
        //Entry validation
        public bool isPresent(TextBox textbox, string name)
        {
            if (textbox.Text == "")
            {
                MessageBox.Show(name + " is a required field", "Error");
                textbox.Clear();
                textbox.Focus();
                return false;
            }
            return true;
        }
        //Form validation
        public bool IsValidForm()
        {
            return
                isPresent(txtNumber, "Number")
                && IsInt(txtNumber, "Number")
                && IsWithinRange(txtNumber, "Number", 1, 20);
        }
        //Exit button event handler
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
