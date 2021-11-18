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
    public partial class Movies_Home : Form
    {
        public Movies_Home()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Movies_Maintenance mov_maint = new Movies_Maintenance();
            mov_maint.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users_Maintenance users_maint = new Users_Maintenance();
            users_maint.ShowDialog();
        }

        private void rentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rents_Maintenance rents_maint = new Rents_Maintenance();
            rents_maint.ShowDialog();
        }

        private void titleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieTitleSearch titleSearch = new MovieTitleSearch();
            titleSearch.ShowDialog();
        }

        private void directorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoviesDirSearch dirSearch = new MoviesDirSearch();
            dirSearch.ShowDialog();
        }

        private void genreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieGenSearch genSearch = new MovieGenSearch();
            genSearch.ShowDialog();
        }
    }
}
