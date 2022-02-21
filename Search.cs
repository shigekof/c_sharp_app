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
    public partial class Search : Form
    {
        //Declaring global arrays for assigning the membership table data.
        int[] membershipIDs = new int[3];
        string[] membershipTypes = new string[3];

        public Search()
        {
            InitializeComponent();
        }

        //When the Fliter button is clicked.
        private void FilterButton_Click(object sender, EventArgs e)
        {
            //Run the method to retrieve the membership table data.
            retrieveMembershipData();
            int index = -1;
            int membershipID = 0;

            //DataView to see the filtered record
            DataView memberDataView = new DataView(assignment3Task2DataSet.Tables["Member"]);
            string query = "";
            
            if(name.Text != "" && membershipType.SelectedItem != null) //When both inputs are filled.
            {
                //Assign index of membership type the user selected.
                index = Array.IndexOf(membershipTypes, membershipType.Text);

                //Assign membership ID which matches to the membership table data.
                membershipID = membershipIDs[index];

                //Assign query string for filtering the member table data.
                query = "[FirstName] LIKE '" + name.Text + "*'";
                query += " OR[LastName] LIKE '" + name.Text + "*'";
                query += " OR[FirstName] + ' ' + [LastName] LIKE '" + name.Text + "*'";
                query += "And" + " [MembershipID] = " + membershipID;
            }
            else if (name.Text != "" && membershipType.SelectedItem == null) //When only the First Name is filled.
            {
                //Assign query string for filtering the member table data.
                query = "[FirstName] LIKE '" + name.Text + "*'";
                query += " OR[LastName] LIKE '" + name.Text + "*'";
                query += " OR[FirstName] + ' ' + [LastName] LIKE '" + name.Text + "*'";

            }
            else if (name.Text == "" && membershipType.SelectedItem != null) //When only Membership Type is selected.
            {
                //Assign index of membership type the user selected.
                index = Array.IndexOf(membershipTypes, membershipType.Text);

                //Assign membership ID which matches to the membership table data.
                membershipID = membershipIDs[index];

                query = "[MembershipID] = " + membershipID;
            }
            else 
            {
                //Show an error message when a user clicked the Filter button with no input.
                MessageBox.Show("Invalid input. Please spesify First Name and/or Membership Type.");
            }

            //Apply query string to RowFilter.
            memberDataView.RowFilter = query;
            //Show filtered DataView.
            memberDataGridView.DataSource = memberDataView;
        }

        //When the Cancel button is clicked.
        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            //Clear the filter.
            memberDataGridView.DataSource = new DataView(assignment3Task2DataSet.Tables["Member"]);
            //Clear the First Name text box.
            name.Text = "";
            //Clear the Membership Type drop list.
            membershipType.SelectedItem = null;
        }

        //Retrieves the membership data.
        private void retrieveMembershipData()
        {
            int i = 0;
            foreach (DataRow r in assignment3Task2DataSet.Membership.Rows)
            {
                //Assigning the retrieved membership data to each array.
                membershipIDs[i] = Int32.Parse(r["MembershipID"].ToString());
                membershipTypes[i] = r["Description"].ToString();
                i++;
            }

        }

        //Shows the Main Menu screen and closes the Search Members screen.
        private void SearchMainMenuButton_Click(object sender, EventArgs e)
        {
            new MainMenu().Show(); //Shows the Main Menu screen.
            this.Hide(); //Hides the Search Members screen.
        }

        //The message box will appear to show how to use the search members screen when the Help button is clicked.
        private void SearchHelpButton_Click(object sender, EventArgs e)
        {
            string message;

            //Assigning instruction for the search screen to the message variable.
            message = "Search Members Help \r\n \r\n" +
                "Enter member's name and/or select the membership type and click the Filter button. \r\n" +
                "The name can be first name, last name or both with the space in between. \r\n" +
                "You can search with a part of the name. (e.g. if you type 'a' and click the Filter button, the first name starts with 'a' and the last name starts with 'a' will be shown.) \r\n" +
                "To clear the result, click the Clear button. \r\n" +
                "To go back to the main menu, click the Main Menu button. \r\n" +
                "To exit the application, click the Exit button.";
            
            //Shows the message box.
            MessageBox.Show(message);
        }

        //Exits the application when the Exit button is clicked.
        private void SearchExitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        //Updates the data tables.
        private void memberBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.memberBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.assignment3Task2DataSet);

        }

        //Makes the membership table data and the member table data accessible on this form.
        private void Search_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'assignment3Task2DataSet.Membership' table. You can move, or remove it, as needed.
            this.membershipTableAdapter.Fill(this.assignment3Task2DataSet.Membership);
            // TODO: This line of code loads data into the 'assignment3Task2DataSet.Member' table. You can move, or remove it, as needed.
            this.memberTableAdapter.Fill(this.assignment3Task2DataSet.Member);

        }
    }
}
