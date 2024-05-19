using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Version2
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ChoiceShow_Click(object sender, EventArgs e)
        {
            DBMetals form2 = new DBMetals();
            // Показываем новую форму
            form2.Show();

            this.Hide();
        }

        private void ChoiceIn_Click(object sender, EventArgs e)
        {
            Singl form3 = new Singl();
            form3.Show();
            this.Hide();
        }
    }
}
