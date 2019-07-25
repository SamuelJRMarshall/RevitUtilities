using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorLogic;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Memory memory = new Memory();
        Brain brain = new Brain();

        /// x10^x
        /// Equals
        /// Answer list
        /// Clear
        /// Delete
        /// Previous Answer

        public Form1()
        {
            InitializeComponent();
           
        }

        
        private void txtEntry_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFinalDisplay_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnZero_Click(object sender, EventArgs e)
        {
            txtEntry.AppendText("0");
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtEntry.AppendText("1");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtEntry.AppendText("2");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtEntry.AppendText("3");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtEntry.AppendText("4");
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtEntry.AppendText("5");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtEntry.AppendText("6");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtEntry.AppendText("7");
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtEntry.AppendText("8");
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtEntry.AppendText("9");
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            txtEntry.AppendText(".");
        }


        private void btn10x_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                memory.SaveA(txtEntry.Text);
                ClearInput();
                memory.SetOperator("Add");
            }
            else
            {
                memory.SetOperator("Add");
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                memory.SaveA(txtEntry.Text);
                ClearInput();
                memory.SetOperator("Minus");
            }
            else
            {
                memory.SetOperator("Minus");
            }
        }

        private void btnTimes_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                memory.SaveA(txtEntry.Text);
                ClearInput();
                memory.SetOperator("Times");
            }
            else
            {
                memory.SetOperator("Times");
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                memory.SaveA(txtEntry.Text);
                ClearInput();
                memory.SetOperator("Divide");
            }
            else
            {
                memory.SetOperator("Divide");
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {

        }

        private void btnAns_Click(object sender, EventArgs e)
        {

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                txtEntry.Text = txtEntry.Text.Remove(txtEntry.Text.Length - 1);
                
            }catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("There are no numbers left to Delete! \n\nError Code: \n" + ex.Message);
            }
            finally
            {
                //
            }
            
             
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        public bool CheckInput()
        { 
            return txtEntry.Text.Length <= 0;
        }

        public void ClearInput()
        {
            txtEntry.Text = "";
        }
    }
}
