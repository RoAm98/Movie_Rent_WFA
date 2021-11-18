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
    public partial class MovieTitleSearch : Form
    {
        public MovieTitleSearch()
        {
            InitializeComponent();
        }

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


        private void MovieTitleSearch_Load(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string queryStr = String.Format("SELECT * FROM Movies WHERE Title LIKE '%{0}%'", tbKeyword.Text);
                DataTable searchresult = Queries.ExecuteQuery(queryStr);
                dgvMovieList.DataSource = searchresult;
                MessageBox.Show("Here are the Results!");
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
