using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/*
 BIT502 Fundamentals of Programming
 Assignment3 Task2
 Shigeko Fujimoto
 Student number:5047829
*/

namespace Assignment3Task2
{
    public partial class RegistrationForm : Form
    {
        //Declaring global variables.
        string fName;
        string lName;
        string stAddress;
        string mobNumber;
        string emAddress;
        DateTime dob;
        string duration;
        string paymentMethod;
        string paymentFrequency;
        DateTime expiryDate;
        int[] extraIds = new int[4];
        double baseMCost = 0;
        double totalExtras = 0;
        double totalDisc = 0;
        double netMCost = 0;
        double regularPayment = 0;
        int membershipID;
        int[] membershipIDs = new int[3];
        string[] membershipTypes = new string[3];

        public RegistrationForm()
        {
            InitializeComponent();
        }

        //Makes the membership table data and the member table data accessible on this form.
        private void MembershipRegistrationForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'assignment3Task2DataSet.Membership' table. You can move, or remove it, as needed.
            this.membershipTableAdapter.Fill(this.assignment3Task2DataSet.Membership);
            // TODO: This line of code loads data into the 'assignment3Task2DataSet.Member' table. You can move, or remove it, as needed.
            this.memberTableAdapter.Fill(this.assignment3Task2DataSet.Member);

        }

        // Calculation button method
        private void calcButton_Click(object sender, EventArgs e)
        {
            //Assigning initial texts for the membership costs to show. I used labels to show the claculation result instead of text boxes to avoid users changing the value after the calculation is done.
            totalMembershipCost.Text = "$ ";
            extraCharges.Text = "$ ";
            totalDiscount.Text = "$ ";
            netMembershipCost.Text = "$ ";
            regularPaymentAmount.Text = "$ ";

            //Assining the result of the error checking method.
            bool errorCheck = errorCheckingForCalcButton();

            //When the error check result is true, there is an error.
            if (errorCheck)
            {
                MessageBox.Show("Invalid input. Please make sure that you fill up all the required fields.");
            }
            else // When the error check result is false, there is no error.
            {
                //Resets all the cost in case the user wants to recalculate the cost with different options.
                baseMCost = 0;
                totalExtras = 0;
                totalDisc = 0;
                netMCost = 0;
                regularPayment = 0;

                //Assign values to the extraIDs array.
                assignExtraIds();

                //Showing the costs to the screen.
                totalMembershipCost.Text += baseMembershipCost().ToString();
                extraCharges.Text += extraChargeCalc().ToString();
                totalDiscount.Text += discountCalc().ToString();
                netMembershipCost.Text += netMembershipCostCalc().ToString();
                regularPaymentAmount.Text += regularPaymentCalc().ToString();
            }
        }

        //Submit button method
        private void submitButton_Click(object sender, EventArgs e)
        {
            //Checking if the calculation is done. The regular payment amount method is executed at last so if regular payment amount has more than two texts (because initial texts are "$ "), then all the calculations are done." )
            if(regularPaymentAmount.Text.Length > 2)
            {
                //Saving the data to the data table.
                saveToDatabase();
                MessageBox.Show("Submitted successfully. Thank you!");
                this.Hide(); //Hiding the current form.
                RegistrationForm form = new RegistrationForm();
                form.Show(); //Showing the new form.
            }
            else
            {
                //Error message for when the users clicked Submit button before they click the Calculate button.
                MessageBox.Show("Please click the Calculate button to calculate the membership cost.");
            }
        }

        //Cancel button method
        private void cancelButton_Click(object sender, EventArgs e)
        {
            //Telling the user that the registration is canceled.
            MessageBox.Show("Registration is canceled.");
            this.Hide(); //Hiding the current form.
            RegistrationForm form = new RegistrationForm();
            form.Show(); //Showing the new form.
        }

        //Error checking method for when Calculation button is clicked.
        private bool errorCheckingForCalcButton()
        {
            bool tResult = errorCheckingForTextboxes(); //Assigning the result of the error checking method for text boxes.
            bool rResult = errorCheckingForRadioButtons(); //Assigning the result of the error checking method for radio buttons.
            bool[] results = { tResult, rResult }; //Assigning the above variables to an array.

            return (results.Contains(true)); //Checking if the above array contains the value "true". If it does, there is an error.
        }

        // Error checking method for the text boxes.
        private bool errorCheckingForTextboxes()
        {
            bool[] results = new bool[4]; //Creating new array to store the checking results.
            //Creating array to store the texts from text boxes.
            string[] details = { firstName.Text, lastName.Text, address.Text, mobileNumber.Text };

            //for loop to check if the text boxes are empty.
            for (int i = 0; i < details.Length; i++)
            {
                if (details[i] != "")
                {
                   results[i] = true; //Store the value "true" to the result array if the text box is not empty.
                }
                else
                {
                    results[i] = false; //Store the value "false' to the result array if the text box is empty.
                }
            }

            return (results.Contains(false)); //If the results array contains "false", it returns true (that means there is an error).

        }

        //Error checking method for radio buttons.
        private bool errorCheckingForRadioButtons()
        {
            bool[] results = new bool[4]; //Creating new array to store the checking results.
            //Creating the jagged array to store the boolean value whether the radio buttons are checked or not.
            bool[][] eachResults =
            {
                new bool[] { typeBasic.Checked, typeRegular.Checked, typePremium.Checked },
                new bool[] { dur3months.Checked, dur12months.Checked, dur24months.Checked },
                new bool[] { paymentDirect.Checked, paymentCredit.Checked },
                new bool[] { frequencyWeekly.Checked, frequencyMonthly.Checked }
            };

            //for loop to store the results if one of the radio buttons from each option is checked.
            for (int i = 0; i < eachResults.Length; i++)
            {
                results[i] = eachResults[i].Contains(true); //If it contains "true", one of the radio buttons are checked.
            }

            //If the results array contains "false", that means it has an error (returns "true").
            return (results.Contains(false));

        }

        //Method to assign ids for check box items.
        private void assignExtraIds()
        {
            //double[] id = new double[4]; //Creating new array to store the ids.
            //Creating new array to store the boolean values.
            bool[] checkboxes = { unlimitedAccess.Checked, personalTrainer.Checked, dietConsultation.Checked, fitnessVideos.Checked };

            //for loop to store ids to the id array.
            for (int i = 0; i < checkboxes.Length; i++)
            {
                if(checkboxes[i])
                {
                    extraIds[i] = 1; //Stores the id "1" if the check box is checked.
                }
            }
        }

        //Method to assign the base membership cost.
        private double baseMembershipCost()
        {
            //Creating new array to store boolean values.
            bool[] membership = { typeBasic.Checked, typeRegular.Checked, typePremium.Checked };
            //Creating array to store the membership costs.
            double[] baseMembershipCosts = { 10, 15, 20 };

            //for loop to assign the value of the base membership cost
            for (int i = 0; i < membership.Length; i++)
            {
                if (membership[i])
                {
                    baseMCost = baseMembershipCosts[i]; //If the radio button is checked, the corresponding membership cost is assigned.
                }
            }

            return (baseMCost); //Returning the chosen base membership cost.
        }

        //Method to calculate extra charges.
        private double extraChargeCalc()
        {
            double[] extraCharges = { 1, 20, 20, 2 }; // Storing costs for the extra charges.

            //for loop to calculate the extra charges
            for (int i = 0; i < extraIds.Length; i++)
            {
                double eachExtraCharge = extraCharges[i] * extraIds[i];
                totalExtras += eachExtraCharge;
            }

            return (totalExtras); //Returning total extra charges.
        }

        //Method to calculate the total discount.
        private double discountCalc()
        {
            //Discount rate for direct dibit.
            double debitDiscountRate = 0.01;

            //Storing durations to an array.
            bool[] duration = { dur3months.Checked, dur12months.Checked, dur24months.Checked };
            double[] durationDiscounts = { 0, 2, 5 }; //Storing discount amount for each duration.

            //Diclaring variable for duration and direct debit.
            double durationDiscount = 0;
            double debitDiscount = 0;

            //for loop to assign the duration discount amount.
            for (int i = 0; i < duration.Length; i++)
            {
                if (duration[i])
                {
                    durationDiscount = durationDiscounts[i];
                }
            }

            //Calculating the direct debit discount amount.
            if (paymentDirect.Checked)
            {
                debitDiscount = baseMCost * debitDiscountRate;
            }

            //Calculating total discount amount.
            totalDisc = durationDiscount + debitDiscount;

            return (totalDisc); //Returning total discount amount.
        }

        //Method to calculate the net membership cost.
        private double netMembershipCostCalc()
        {
            //Calculating the net membership cost.
            netMCost = baseMCost - totalDisc + totalExtras;

            return (netMCost); //Returning the net membership cost.
        }

        //Method to calculate the regular payment amount.
        private double regularPaymentCalc()
        {
            
            if (frequencyMonthly.Checked) //When monthly payment is checked.
            {
                regularPayment = Math.Round(netMCost / 7 * 30, 2); //Dividing the net membership cost by 7 and multiplying by 30. Rounding up the answer to two dicimal places.
            }
            else //When monthly payment is not checked.
            {
                regularPayment = netMCost; //Assinging the new membership cost as the weekly regular payment because it is the same amount.
            }

            return (regularPayment); //Returning the regular payment amount.
        }

        //Shows the Main Menu screen and closes the Member Registration Form screen.
        private void RegistrationMainMenuButton_Click(object sender, EventArgs e)
        {
            new MainMenu().Show(); //Shows the Main Menu screen.
            this.Hide(); //Hides the Member Registration Form screen.
        }

        //The message box will appear to show how to use the registration form when the Help button is clicked.
        private void RegistrationHelpButton_Click(object sender, EventArgs e)
        {
            string message;

            //Assigning instruction for the registration form to the message variable.
            message = "Registration Form Help \r\n \r\n" +
                "Fill up all the mandatory fields, select the options and click the Calculate button to calculate the costs. \r\n" +
                "If you reselect the options, click the Calculate button again. \r\n" +
                "Once the calculation is done, click the Submit button. \r\n" +
                "You will not be able to submit the form until you calculate the cost. \r\n" +
                "To cancel, click the Cancel button. \r\n" +
                "To go back to the main menu, click the Main Menu button. \r\n" +
                "To exit the application, click the Exit button.";
            
            //Shows the message box.
            MessageBox.Show(message);
        }

        //Exits the application when the Exit button is clicked.
        private void RegistrationExitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        //Method to save the input data to the Member table of the database.
        private void saveToDatabase()
        {
            //Excute all the methods to assign the input values to the variables.
            assignDetails();
            assignMemberhsipID();
            assignDuration();
            assignExpiryDate();
            assignPaymentFrequency();
            assignPaymentMethod();

            //Add new row and put data into the Member table.
            Assignment3Task2DataSet.MemberRow newMemberRow = assignment3Task2DataSet.Member.NewMemberRow();
            newMemberRow.MemberID = assignment3Task2DataSet.Member.Count + 1;
            newMemberRow.FirstName = fName;
            newMemberRow.LastName = lName;
            newMemberRow.Address = stAddress;
            newMemberRow.Mobile = mobNumber;
            newMemberRow.EmailAddress = emAddress;
            newMemberRow.DOB = dob;
            newMemberRow.Duration = duration;
            newMemberRow.PaymentMethod = paymentMethod;
            newMemberRow.PaymentFrequency = paymentFrequency;
            newMemberRow._24_7Access = extraIds[0];
            newMemberRow.PersonalTrainer = extraIds[1];
            newMemberRow.DietConsultation = extraIds[2];
            newMemberRow.FitnessVideos = extraIds[3];
            newMemberRow.MembershipExpiryDate = expiryDate;
            newMemberRow.MembershipID = membershipID;

            //Adds the newly created row to the Member table.
            assignment3Task2DataSet.Member.Rows.Add(newMemberRow);
            //Updates the member table.
            memberTableAdapter.Update(assignment3Task2DataSet.Member);

        }

        //Assigns the values to the variables for the contact details.
        private void assignDetails()
        {
            fName = firstName.Text;
            lName = lastName.Text;
            stAddress = address.Text;
            mobNumber = mobileNumber.Text;
            emAddress = emailAddress.Text;
            dob = dobPicker.Value;
        }

        //Method to assign the options to the variable to write it to a file.
        private void assignMemberhsipID()
        {
            //Retrieving the membership data from the Membership table.
            int i = 0;
            foreach (DataRow r in assignment3Task2DataSet.Membership.Rows)
            {
                membershipIDs[i] = Int32.Parse(r["MembershipID"].ToString());
                membershipTypes[i] = r["Description"].ToString();
                i++;
            }

            //Storing the option boolean values to an array.
            bool[] membershipOptions = { typeBasic.Checked, typeRegular.Checked, typePremium.Checked };
            
            //for loop to assign the option names and the options.
            for (int k = 0; k < membershipOptions.Length; k++)
            {
                if (membershipOptions[k]) //When the membership option is checked.
                {
                    int membershipTypeIndex = Array.IndexOf(membershipTypes, membershipTypes[k]);
                    membershipID = membershipIDs[membershipTypeIndex]; //Assign membership ID.
                }
            }
        }

        //Assigns the value to the duration variable.
        private void assignDuration()
        {
            //Storing the option boolean values to an array.
            bool[] durations = {dur3months.Checked, dur12months.Checked, dur24months.Checked };

           
            //Storing the options to an array.
            string[] durationItems = { "3 months", "12 months", "24 months" };

            //for loop to assign the option names and the options.
            for (int i = 0; i < durations.Length; i++)
            {
                if (durations[i]) //When the duration option is checked.
                {
                     duration = durationItems[i]; //Assign the corresponding value to the variable.
                }
            }
        }
        
        //Assigns the value to the paymentMethod variable.
        private void assignPaymentMethod()
        {
            //Storing the option boolean values to an array.
            bool[] paymentMethods = {paymentDirect.Checked, paymentCredit.Checked };

            //Storing the options to an array.
            string[] paymentItems = { "Direct debit", "Credit card" };

            //for loop to assign the option names and the options.
            for (int i = 0; i < paymentMethods.Length; i++)
            {
                if (paymentMethods[i]) //When the payment method option is checked.
                {
                    paymentMethod = paymentItems[i]; //Assign the corresponding value to the variable.
                }
            }
        }
        
        //Assigns the value to the paymentFrequency.
        private void assignPaymentFrequency()
        {
            //Storing the option boolean values to an array.
            bool[] frequency = { frequencyWeekly.Checked, frequencyMonthly.Checked };

           
            //Storing the options to an array.
            string[] frequencyItems = { "Weekly", "Monthly" };

            //for loop to assign the option names and the options.
            for (int i = 0; i < frequency.Length; i++)
            {
                if (frequency[i]) //When the payment frequency option is checked.
                {
                     paymentFrequency = frequencyItems[i]; //Assign the corresponding value to the variable.
                }
                else
                {
                    continue; //Skip when the option is not checked.
                }
            }
        }

        //Assigns the value to the expiryDate variable.
        private void assignExpiryDate()
        {
            if (dur3months.Checked) //When the option "3 months" is checked.
            {
                expiryDate = DateTime.Now.AddMonths(3); //Add 3 months to the registration date which is the current date.
            }
            else if (dur12months.Checked) //When the option "12 months" is checked.
            {
                expiryDate = DateTime.Now.AddMonths(12); //Add 12 months to the registration date which is the current date.
            }
            else //When the option "24 months" is checked.
            {
                expiryDate = DateTime.Now.AddMonths(24); //Add 24 months to the registration date which is the current date.
            }
        }

        //Updates the data tables.
        private void memberBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.memberBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.assignment3Task2DataSet);

        }
    }
}
