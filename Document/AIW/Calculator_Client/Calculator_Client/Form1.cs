using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            var service = new calculator.CalculatorClient();
            //lấy giá trị 2 ô textbox và validate
            FormObject returnObject = getValue();

            if (!returnObject.status)
                MessageBox.Show(returnObject.message);
            else
                lblResultDisplay.Text = service.add(returnObject.no1, returnObject.no2).ToString();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            var service = new calculator.CalculatorClient();
            FormObject returnObject = getValue();
            if (!returnObject.status)
                MessageBox.Show(returnObject.message);
            else
                lblResultDisplay.Text = service.sub(returnObject.no1, returnObject.no2).ToString();
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            var service = new calculator.CalculatorClient();
            FormObject returnObject = getValue();
            if (!returnObject.status)
                MessageBox.Show(returnObject.message);
            else
                lblResultDisplay.Text = service.mul(returnObject.no1, returnObject.no2).ToString();
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            var service = new calculator.CalculatorClient();
            FormObject returnObject = getValue();
            if (!returnObject.status)
                MessageBox.Show(returnObject.message);
            else if (returnObject.no2 == 0)
                MessageBox.Show("Can not divide by zero!");
            else
                lblResultDisplay.Text = service.div(returnObject.no1, returnObject.no2).ToString();
        }

        private bool checkEmpty(string no1, string no2)
        {
            return no1.Length > 0 && no2.Length > 0;
        }

        private bool isFloatNumber(string no1, string no2)
        {
            try
            {
                float.Parse(no1);
                float.Parse(no2);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private FormObject getValue()
        {
            string no1 = txtNo1.Text;
            string no2 = txtNo2.Text;
            FormObject returnObject = new FormObject();
            returnObject.status = false;
            if (!checkEmpty(no1, no2))
                returnObject.message = "Can not contains empty field!";
            else if (!isFloatNumber(no1, no2))
                returnObject.message = "Must be a number in field!";
            else
            {
                returnObject.status = true;
                returnObject.setValue(no1, no2);
            }
            return returnObject;
        }

    }
}
