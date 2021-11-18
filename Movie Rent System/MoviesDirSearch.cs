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
    public partial class MoviesDirSearch : Form
    {
        private void ShowAll()
        {
            try
            {
                string query = "SELECT  Movie_ID, Title, Director, Actors, Genre, Availability, Premiere FROM Movies";
                DataTable movies = Queries.ExecuteQuery(query);
                dgvMovieList.DataSource = movies;


            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public MoviesDirSearch()
        {
            InitializeComponent();
        }

        private void tbKeyword_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string queryStr = String.Format("SELECT * FROM Movies WHERE Director LIKE '%{0}%'", tbKeyword.Text);
                DataTable searchresult = Queries.ExecuteQuery(queryStr);
                dgvMovieList.DataSource = searchresult;
                MessageBox.Show("Here are the Results!");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MoviesDirSearch_Load(object sender, EventArgs e)
        {
            ShowAll();
        }
    }
}
