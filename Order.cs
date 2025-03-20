using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Project_2
{
    public partial class Order: Form
    {
        public Order()
        {
            InitializeComponent();
        }
        float GetSelectedSizePrice()
        {
            float price = 0;
            if(rbSmall.Checked)
            {
                price = Convert.ToSingle(rbSmall.Tag);
            }
            if (rbMedium.Checked)
            {
                price = Convert.ToSingle(rbMedium.Tag);
            }
            if(rbLarge.Checked) {
                price = Convert.ToSingle(rbLarge.Tag);
            }

            return price;
        }
        float GetSelectedCrustPrice()
        {
            float price = 0;
            if (rbThinCrust.Checked)
            {
                price = Convert.ToSingle(rbThinCrust.Tag);
            }
            if (rbThickCrust.Checked)
            {
                price = Convert.ToSingle(rbThickCrust.Tag);
            }
            return price;
        }
        float GetSelectedWhereToEatPrice()
        {
            float price = 0;
            if (rbEatIn.Checked)
            {
                price = Convert.ToSingle(rbEatIn.Tag);
            }
            if (rbEatOut.Checked)
            {
                price = Convert.ToSingle(rbEatOut.Tag);
            }
            return price;
        }
        float GetSelectedToppingsPrice()
        {
            float price = 0;
            if (cbExtraCheese.Checked)
            {
                price += Convert.ToSingle(cbExtraCheese.Tag);
            }
            if (cbMushroom.Checked)
            {
                price += Convert.ToSingle(cbMushroom.Tag);
            }
            if (cbOlive.Checked)
            {
                price += Convert.ToSingle(cbOlive.Tag);
            }
            if (cbOnions.Checked)
            {
                price += Convert.ToSingle(cbOnions.Tag);
            }
            if (cbPeppers.Checked)
            {
                price += Convert.ToSingle(cbPeppers.Tag);
            }
            if (cbTomatoes.Checked)
            {
                price += Convert.ToSingle(cbTomatoes.Tag);
            }
            return price;
        }
       
        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + GetSelectedCrustPrice() + GetSelectedWhereToEatPrice() + GetSelectedToppingsPrice();
        }
        void TotalPrice()
        {
            lbTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
        }
        void UpdateSize()
        {
            TotalPrice();
            if (rbSmall.Checked)
            {
                lbSize.Text = "Small";
            }
            if (rbMedium.Checked)
            {
                lbSize.Text = "Medium";
            }
            if (rbLarge.Checked)
            {
                lbSize.Text = "Large";
            }
        }
       
        void UpdateCrustType()
        {
            TotalPrice();
            if(rbThinCrust.Checked)
            {
                lbCrust.Text = "Thin Crust";
            }
            if (rbThickCrust.Checked)
            {
                lbCrust.Text = "Thick Crust";
            }
        }

        void UpdateToppings()
        {
            TotalPrice();
            string toppings = "";
            if (cbExtraCheese.Checked)
            {
                toppings = "Extra Cheese";
            }
            if (cbMushroom.Checked)
            {
                toppings += ", Mushroom";
            }
            if (cbOlive.Checked)
            {
                toppings += ", Olive";
            }
            if (cbOnions.Checked)
            {
                toppings += ", Onions";
            }
            if (cbPeppers.Checked)
            {
                toppings += ", Peppers";
            }
            if (cbTomatoes.Checked)
            {
                toppings += ", Tomatoes";
            }
            if(toppings == "")
            {
                toppings = "No Toppings";
            }
            if (toppings.StartsWith(","))
            {
                toppings = toppings.Substring(1, toppings.Length - 1).Trim();
            }
            lbToppings.Text = toppings;
        }
        void UpdateWhereToEat()
        {
            TotalPrice();
            if (rbEatIn.Checked)
            {
                lbWhereToEat.Text = "Eat In";
            }
            if (rbEatOut.Checked)
            {
                lbWhereToEat.Text = "Eat Out";
            }
        }
        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure ? ","Confirm Order",MessageBoxButtons.OK,MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show($"Total Price is {CalculateTotalPrice()} ", "Final Price", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;
                gbOrderSummery.Enabled = false;
                gbCrustType.Enabled = false;
                btnOrderPizza.Enabled = false;
            }else
            {

            }
        }
        void ResetForm()
        {

            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
            gbOrderSummery.Enabled = true;
            gbCrustType.Enabled = true;
            btnOrderPizza.Enabled = true;
            rbSmall.Checked = true;
            rbThinCrust.Checked = true;
            rbEatIn.Checked = true;

            cbExtraCheese.Checked = false;
            cbPeppers.Checked = false;
            cbMushroom.Checked = false;
            cbOlive.Checked = false;
            cbOnions.Checked = false;
            cbTomatoes.Checked = false;
        }
        private void btnResetOrder_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            lbSize.Text = "Small";
            rbSmall.Checked = true;
            rbThinCrust.Checked = true;
            lbCrust.Text = "THin Crust";
            rbEatIn.Checked = true;
            lbWhereToEat.Text = "Eat In";
            lbToppings.Text = "No Toppings";
            TotalPrice();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbEatOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void cbExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbMushroom_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbOnions_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbOlive_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
    }
}
