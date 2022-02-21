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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        //Shows the Membership Registration Form screen and hides the Main Menu screen.
        private void RegisterMenuButton_Click(object sender, EventArgs e)
        {
            new RegistrationForm().Show(); //Shows the Membership Registration Form.
            this.Hide(); //Hides the Main Menu screen.
        }

        //Shows the Search Members screen and hides the Main Menu screen.
        private void SearchMenuButton_Click(object sender, EventArgs e)
        {
            new Search().Show(); //Shows the Search Members screen.
            this.Hide(); //Hides the Main Menu screen.
        }

        //Shows the Book Classes screen and hides the Main Menu screen.
        private void BookMenuButton_Click(object sender, EventArgs e)
        {
            new Book().Show(); //Shows the Book Classes screen.
            this.Hide(); //Hides the Main Menu screen.
        }

        //Shows the message box for the instruction for the user to help understand how to use the Main Menu screen.
        private void HelpMenuButton_Click(object sender, EventArgs e)
        {
            string message;

            //Assigning instruction for the search screen to the message variable.
            message = "Main Menu Help \r\n \r\n" +
                "Click the Register button to register a new member. \r\n" +
                "Click the Search Members button to search the existing members. \r\n" +
                "Click the Book Classes button to book the fitness classes. \r\n" +
                "If you need the instructions for each screen, click the Help button on the each screen. \r\n" +
                "To exit the application, click the Exit button.";

            //Show the message box.
            MessageBox.Show(message);
        }

        //Exits the application when the Exit button is clicked.
        private void ExitMenuButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
