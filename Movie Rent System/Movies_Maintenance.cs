using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Movie_Rent_System
{
    public partial class Movies_Maintenance : Form
    {
        int MovieID = 0;




        private void ShowAll()
        {
            try
            {
                string query = "SELECT  Movie_ID, Title, Director, Actors, Genre, Availability, Premiere FROM Movies";
                DataTable movies = Queries.ExecuteQuery(query);
                dgvMovies.DataSource = movies;


            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Movies_Maintenance()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "New")
            {
                textBoxTitle.Text = ""; 
                textBoxDirector.Text = "";
                textBoxActor.Text = "";
                textBoxGenre.Text = "";
                checkBoxAva.Checked = false;
                checkBoxPre.Checked = false;
                button1.Text = "Insert";
                button2.Enabled = false;
            }
            else if (button1.Text == "Insert")
            {
                //Insert Button
                try
                {
                    if (textBoxTitle.Text != "" && textBoxDirector.Text != "" && textBoxActor.Text != "" && textBoxGenre.Text != "")
                    {
                        string query = String.Format("INSERT INTO Movies VALUES ('{0}','{1}', '{2}', '{3}', '{4}', '{5}')", textBoxTitle.Text, textBoxDirector.Text, textBoxActor.Text, textBoxGenre.Text, checkBoxAva.Checked, checkBoxPre.Checked);
                        Console.WriteLine(checkBoxAva.Checked);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //textBoxTitle.Text = dgvMovies.Rows[e.RowIndex].Cells[1].Value.ToString();
            //textBoxDirector.Text = dgvMovies.Rows[e.RowIndex].Cells[2].Value.ToString();
            //textBoxActor.Text = dgvMovies.Rows[e.RowIndex].Cells[3].Value.ToString();
            //textBoxGenre.Text = dgvMovies.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void Movies_Maintenance_Load(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string queryStr = String.Format("UPDATE Movies " +
                    "SET Title = '{0}', " +
                    "Director = '{1}', " +
                    "Actors = '{2}', " +
                    "Genre = '{3}', " +
                    "Availability = '{4}', " +
                    "Premiere = '{5}' " +
                    "WHERE Movie_ID = '{6}'", textBoxTitle.Text, textBoxDirector.Text, textBoxActor.Text, textBoxGenre.Text, checkBoxAva.Checked, checkBoxPre.Checked, MovieID);
                Queries.ExecuteNonquery(queryStr);
                    ShowAll();
                MessageBox.Show("Record successfully updated!");
            }
            catch(SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvMovies_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            MovieID = Convert.ToInt16(dgvMovies.Rows[e.RowIndex].Cells[0].Value);
            textBoxTitle.Text = dgvMovies.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxDirector.Text = dgvMovies.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxActor.Text = dgvMovies.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxGenre.Text = dgvMovies.Rows[e.RowIndex].Cells[4].Value.ToString();
            checkBoxAva.Checked = Convert.ToBoolean(dgvMovies.Rows[e.RowIndex].Cells[5].Value);
            checkBoxPre.Checked = Convert.ToBoolean(dgvMovies.Rows[e.RowIndex].Cells[6].Value);
            button1.Text = "New";
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                try
                {
                    string queryStr = String.Format("DELETE FROM Movies WHERE Movie_ID = {0}", MovieID);
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
    }
}
