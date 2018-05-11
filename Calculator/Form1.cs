using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double result = 0;
        String operation = "";
        bool enter_value = false;
        String firstnum,secondnum;
        private double memory;
        private bool memFlag;
        public Form1()
        {
            InitializeComponent();

            btnMC.Enabled = false;
            btnMR.Enabled = false;
            btnHistory.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void numbers_Only(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if ((txtDisplay.Text == "0") || (enter_value) || memFlag == true)
            {
                txtDisplay.Text = "";
                enter_value = false;
                memFlag = false;
            }

            if (b.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                    txtDisplay.Text = txtDisplay.Text + b.Text;

            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + b.Text;
            }

        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (result != 0)
            {
                btnEquals.PerformClick();
                enter_value = true;
                operation = b.Text;
                lblShowOps.Text = result + "  " + operation;
            }
            else
            {
                operation = b.Text;
                result = Double.Parse(txtDisplay.Text);
                txtDisplay.Text = "";
                lblShowOps.Text = result + "  " + operation;
            }
            firstnum = lblShowOps.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            result = 0;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            secondnum = txtDisplay.Text;
            lblShowOps.Text = "";
            switch(operation)
            {
                case "+":
                    txtDisplay.Text = (result + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (result - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "x":
                    txtDisplay.Text = (result * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (result / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "%":
                    txtDisplay.Text = (result * (Double.Parse(txtDisplay.Text)/100)).ToString();
                    break;
                default:
                    break;

            }
            result = Double.Parse(txtDisplay.Text);
            operation = "";

            btnHistory.Enabled = true;
            btnClearHistory.Visible = true;
            rtbDisplayHistory.AppendText(firstnum + "   " + secondnum + "   =" + "\n");
            rtbDisplayHistory.AppendText("\n\t" + txtDisplay.Text + "\n\n");
            lblShowOps.Text = "";

        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            rtbDisplayHistory.Clear();
            if (lblShowOps.Text == "")
            {
                lblHistoryDisplay.Text = "There's no history yet";

            }
            btnClearHistory.Visible = false;
            rtbDisplayHistory.ScrollBars = 0;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
            if (txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }
        }
      
       


        private void btnMS_Click_1(object sender, EventArgs e)
        {
            memory = Double.Parse(txtDisplay.Text);
            btnMC.Enabled = true;
            btnMR.Enabled = true;
            memFlag = true;
        }

        private void btnMC_Click_1(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            memory = 0;
            btnMR.Enabled = false;
            btnMC.Enabled = false;
        }

        private void btnMR_Click_1(object sender, EventArgs e)
        {
            txtDisplay.Text = memory.ToString();
            memFlag = true;
        }

        private void btnMPlus_Click_1(object sender, EventArgs e)
        {
            memory += Double.Parse(txtDisplay.Text);
        }

      

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            lblShowOps.Text = txtDisplay.Text + "√ " + operation;

            txtDisplay.Text = Math.Sqrt(Double.Parse(txtDisplay.Text)).ToString();
        }

        private void btnSqr_Click_1(object sender, EventArgs e)
        {
            lblShowOps.Text = txtDisplay.Text + " ²" + operation;
            txtDisplay.Text = (Double.Parse(txtDisplay.Text) * Double.Parse(txtDisplay.Text)).ToString();
        }

        private void btnRecip_Click(object sender, EventArgs e)
        {
            lblShowOps.Text = "1/"+txtDisplay.Text + operation;

            txtDisplay.Text = (1/(Double.Parse(txtDisplay.Text))).ToString();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            this.Size = new Size(850, 690);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Size = new Size(320, 690);
        }

        private void btnMMinus_Click_1(object sender, EventArgs e)
        {
            memory -= Double.Parse(txtDisplay.Text);
        }

    }
}
