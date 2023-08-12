using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Programmer: Alaina Smith
// Project: Assingment 1
// Date 2/11/2022
// Description: Moterway Motel guest check-out program 
namespace Smith_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         // intructions on how to use the program
        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1) First enter checking out date information.\n2) Enter the first and last name. \n3) Enter room number, nights stayed, and nightly rate.\n4) Enter minibar, miscellaneous, and telephone charges.\n5) Lastly click the total button.");
        }
        //  Everything inside is inside the total button so when the user clicks the button it will display values and totals
        private void totalButton_Click(object sender, EventArgs e)
        {
            // Use try-catch to handle any data entry expections
            try
            {
                // Declare local constants
                const decimal SALES_TAX_RATE = 0.07m;

                // Declare  local variables for the amount of nights a guest has stayed.
                // Optional additional charges incurred, as well as the nightly room rate.

                decimal roomCharges;       // Rate per night for room
                decimal minibar;   // Total amount of mini bar charges
                decimal miscellaneous; // total amount of  miscellaneous
                decimal telephone;    // Total amount of telephone charges
                int nights;
                decimal nightlyRate;
                // Decalre local variables for calculated values.
                decimal additionalCharges;
                decimal subtotal;
                decimal totalCharges;

                // Get values from text boxes and assign to variables. 
                //I use convert. since I was troubleshooting "string not in correct format."
                minibar = Convert.ToDecimal(minibarTextBox.Text);
                miscellaneous = Convert.ToDecimal(miscellaneousTextBox.Text);
                telephone = Convert.ToDecimal(telephoneTextBox.Text);
                // Used int since we only needed whole numbers
                int.TryParse(nightStayTextBox.Text, out nights);
                nightlyRate = Convert.ToDecimal(nightlyRateTextBox.Text);
                // multiply nights * Nightly rate to get room charges
                roomCharges = nights * nightlyRate;
                roomChargeLabel.Text = roomCharges.ToString("c");
                // Adding up the additional charges
                additionalCharges = minibar + miscellaneous + telephone;
                additionalChargeLabel.Text = additionalCharges.ToString("c");

                // Calculate and display subtotal and totals
                subtotal = additionalCharges + roomCharges;
                // simple multiplication of * the tax with the subtotal
                taxAmountLabel.Text = (SALES_TAX_RATE * subtotal).ToString("c");
                subtotalLabel.Text = subtotal.ToString("c");
                // After doing the multiplication above made a formula to add up everything into totalCharges
                totalCharges = subtotal + (subtotal * SALES_TAX_RATE);
                totalChargesLabel.Text = totalCharges.ToString("c");



            }
            catch (Exception ex)
            {
                // Display the default error message
                MessageBox.Show(ex.Message);
            }
        }
                // Clears all textbox values
        private void clearButton_Click(object sender, EventArgs e)
        {
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            nightlyRateTextBox.Text = "";
            roomNumberTextBox.Text = "";
            minibarTextBox.Text = "";
            telephoneTextBox.Text = "";
            miscellaneousTextBox.Text = "";
            roomChargeLabel.Text = "";
            additionalChargeLabel.Text = "";
            subtotalLabel.Text = "";
            taxAmountLabel.Text = "";
            totalChargesLabel.Text = "";
            nightStayTextBox.Text = "";
            checkOutDateLabel.Text = "";

            // Set focus to first input control on form
            checkOutDateLabel.Focus();
        }
            // Closes program
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
