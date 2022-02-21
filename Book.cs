using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 BIT502 Fundamentals of Programming
 Assignment3 Task2
 Shigeko Fujimoto
 Student number:5047829
*/

namespace Assignment3Task2
{
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
        }

        //Shows the Main Menu screen and closes the Book Classes screen.
        private void BookMainMenuButton_Click(object sender, EventArgs e)
        {
            new MainMenu().Show(); //Shows the Main Menu screen.
            this.Hide(); //Hides the Book Classes screen.
        }

        //The message box will appear to show how to use the book classes screen when the Help button is clicked.
        private void BookHelpButton_Click_1(object sender, EventArgs e)
        {
            string message;

            //Assigning instruction for the Book Classes screen to the message variable.
            message = "Book Classes Help \r\n \r\n" +
                "Enter the Member ID, select the Class and Slot, choose the Start Date and click the Submit button. \r\n" +
                "To cancel, click the Cancel button. \r\n" +
                "To go back to the main menu, click the Main Menu button. \r\n" +
                "To exit the application, click the Exit button.";
            
            //Shows the message box.
            MessageBox.Show(message);
        }

        //Exits the application when the Exit button is clicked.
        private void BookExitButton_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
