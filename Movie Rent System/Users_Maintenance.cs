using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie_Rent_System
{
    public partial class Users_Maintenance : Form
    {
        int UserID = 0;

        private void ShowAll()
        {
            try
            {
                string query = "SELECT  User_ID, First_Name, Last_Name, Phone, Address, Email FROM Users";
                DataTable users = Queries.ExecuteQuery(query);
                dgvUsers.DataSource = users;


            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Users_Maintenance()
        {
            InitializeComponent();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Users_Maintenance_Load(object sender, EventArgs e)
        {
            ///Onload info
            ///
            ShowAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "New")
            {
                textBoxFName.Text = "";
                textBoxLName.Text = "";
                textBoxPh.Text = "";
                textBoxAdr.Text = "";
                textBoxEm.Text = "";
                button1.Text = "Insert";
                button2.Enabled = false;
            }
            else if (button1.Text == "Insert")
            {
                //Insert Button
                try
                {
                    if (textBoxFName.Text != "" && textBoxLName.Text != "" && textBoxPh.Text != "" && textBoxAdr.Text != "" && textBoxEm.Text != "")
                    {
                        string query = String.Format("INSERT INTO Users VALUES ('{0}','{1}', '{2}', '{3}', '{4}')", textBoxFName.Text, textBoxLName.Text, textBoxPh.Text, textBoxAdr.Text, textBoxEm.Text);
                        Queries.ExecuteNonquery(query);
                        ShowAll();
                        button1.Text = "New";
                        button2.Enabled = true;
                    }
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string queryStr = String.Format("UPDATE Users " +
                    "SET First_Name = '{0}', " +
                    "Last_Name = '{1}', " +
                    "Phone = '{2}', " +
                    "Address = '{3}', " +
                    "Email = '{4}' " +
                    "WHERE User_ID = '{5}'", textBoxFName.Text, textBoxLName.Text, textBoxPh.Text, textBoxAdr.Text, textBoxEm.Text, UserID);
                Queries.ExecuteNonquery(queryStr);
                ShowAll();
                MessageBox.Show("Record successfully updated!");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUsers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            UserID = Convert.ToInt16(dgvUsers.Rows[e.RowIndex].Cells[0].Value);
            textBoxFName.Text = dgvUsers.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxLName.Text = dgvUsers.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxPh.Text = dgvUsers.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxAdr.Text = dgvUsers.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBoxEm.Text = dgvUsers.Rows[e.RowIndex].Cells[5].Value.ToString();
            button1.Text = "New";
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ///delete
            ///
            DialogResult answer = MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                try
                {
                    string queryStr = String.Format("DELETE FROM Users WHERE User_ID = {0}", UserID);
                    Queries.ExecuteNonquery(queryStr);
                    ShowAll();
                    MessageBox.Show("Record successfully deleted!");
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBoxFName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
