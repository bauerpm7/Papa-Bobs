using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PapaBobsMegaChallenge.DTO.Enums;

namespace PapaBobsMegaChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter a name.";
                validationLabel.Visible = true;
                return;
            }
            

            if (addressTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter an address.";
                validationLabel.Visible = true;
                return;
            }


            if (zipCodeTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter a zip code.";
                validationLabel.Visible = true;
                return;
            }


            if (phoneNumberTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter a phone number.";
                validationLabel.Visible = true;
                return;
            }
           

            try
            {
                var order = buildOrder();
                Domain.OrderManager.CreateOrder(order);
                Response.Redirect("success.aspx");
            }
            catch (Exception exception)
            {
                validationLabel.Text = exception.Message;
                validationLabel.Visible = true;
            }

        }

        private PaymentType determinePaymentType()
        {
            var paymentType = cashRadioButton.Checked ? PaymentType.Cash : PaymentType.Credit;
            return paymentType;
        }

        private SizeType determineSizeType()
        {
            SizeType sizeType;
            if(!Enum.TryParse(pizzaSizeDropDownMenu.SelectedValue, out sizeType))
            {
                throw new Exception("Could not determine pizza size");
            }

            return sizeType;
        }

        private CrustType determineCrustType()
        {
            CrustType crustType;
            if (!Enum.TryParse(pizzaCrustDropDownMenu.SelectedValue, out crustType))
            {
                throw new Exception("Could not determine the type of crust");
            }

            return crustType;
        }


        protected void recalculateTotal(object sender, EventArgs e)
        {
            if (pizzaSizeDropDownMenu.SelectedValue == string.Empty) return;
            if (pizzaCrustDropDownMenu.SelectedValue == string.Empty) return;
            var order = buildOrder();
           
            
            resultLabel.Text = $"{Domain.PizzaPriceManager.CalculateCost(order):C}";
           
        }

        private DTO.OrderDTO buildOrder()
        {
            var order = new DTO.OrderDTO();

            order.Size = determineSizeType();
            order.Crust = determineCrustType();
            order.Sausage = sausageCheckBox.Checked;
            order.Pepperoni = pepperoniCheckBox.Checked;
            order.Onion = onionCheckBox.Checked;
            order.Green_Pepper = greenPepperCheckBox.Checked;
            order.Name = nameTextBox.Text;
            order.Address = addressTextBox.Text;
            order.Zip_Code = zipCodeTextBox.Text;
            order.Phone = phoneNumberTextBox.Text;
            order.Payment_Type = determinePaymentType();
            

            return order;
        }
    }
}