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
    public partial class Rents_Maintenance : Form
    {
        int OrderID = 0;

        private void ShowAll()
        {
            try
            {
                string query = "SELECT  OrderID, First_Name, Last_Name, Title, RentDate, ReturnDate, Price FROM Orders INNER JOIN Users ON Users.User_ID = Orders.UserID INNER JOIN Movies ON Movies.Movie_ID = Orders.MovieID";
                DataTable users = Queries.ExecuteQuery(query);
                dgvRents.DataSource = users;


            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetAllUsers()
        {
            try
            {
                string query = "SELECT User_ID, First_Name + ' ' + Last_Name as FullName FROM Users";
                comboBoxUsers.DisplayMember = "FullName";
                comboBoxUsers.ValueMember = "User_ID";
                comboBoxUsers.DataSource = Queries.ExecuteQuery(query);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetAllMovies()
        {
            try
            {
                string query = "SELECT * FROM Movies";
                comboBoxMovies.DisplayMember = "Title";
                comboBoxMovies.ValueMember = "Movie_ID";
                comboBoxMovies.DataSource = Queries.ExecuteQuery(query);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Rents_Maintenance()
        {
            InitializeComponent();
        }

        private void Rents_Maintenance_Load(object sender, EventArgs e)
        {
            ShowAll();
            GetAllUsers();
            GetAllMovies();
            dateTimePicker2.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "New")
            {
                comboBoxMovies.Text = "";
                comboBoxUsers.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(7);
                textBoxPrice.Text = "";
                button1.Text = "Insert";
                button2.Enabled = false;
            }
            else if (button1.Text == "Insert")
            {
                //Insert Button
                try
                {
                    if (comboBoxMovies.Text != "" && comboBoxUsers.Text != "")
                    {
                        if (decimal.TryParse(textBoxPrice.Text, out decimal price))
                        {
                            string query = String.Format("INSERT INTO Orders VALUES ({0}, {1}, '{2}', '{3}', '{4}')", comboBoxUsers.SelectedValue, comboBoxMovies.SelectedValue, dateTimePicker1.Text, dateTimePicker2.Text, price);
                            Queries.ExecuteNonquery(query);
                            ShowAll();
                            button1.Text = "New";
                            button2.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Price must be a number");
                        }
                    }
                }
                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string queryStr = String.Format("UPDATE Orders " +
                    "SET UserID = '{0}', " +
                    "MovieID = '{1}', " +
                    "RentDate = '{2}', " +
                    "ReturnDate = '{3}', " +
                    "Price = '{4}' " +
                    "WHERE OrderID = '{5}'", comboBoxUsers.SelectedValue, comboBoxMovies.SelectedValue, dateTimePicker1.Text, dateTimePicker2.Text, textBoxPrice.Text, OrderID);
                Queries.ExecuteNonquery(queryStr);
                ShowAll();
                MessageBox.Show("Record successfully updated!");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvRents_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //DateTime date = Convert.ToDateTime(dgvRents.Rows[e.RowIndex].Cells[3].Value);
            Console.WriteLine(dgvRents.Rows[e.RowIndex].Cells[3].Value.ToString());
            OrderID = Convert.ToInt16(dgvRents.Rows[e.RowIndex].Cells[0].Value);
            comboBoxUsers.Text = dgvRents.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBoxMovies.Text = dgvRents.Rows[e.RowIndex].Cells[2].Value.ToString();
            dateTimePicker1.Text = dgvRents.Rows[e.RowIndex].Cells["RentDate"].Value.ToString();
            dateTimePicker2.Text = dgvRents.Rows[e.RowIndex].Cells["ReturnDate"].Value.ToString();
            textBoxPrice.Text = dgvRents.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            button1.Text = "New";
            button2.Enabled = true;
        }
    }
}
