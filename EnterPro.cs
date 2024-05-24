using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Version2
{
    public partial class EnterPro : Form
    {
        int selectedMetod = 0;

        public EnterPro()
        {
            InitializeComponent();
            density.KeyPress += density_KeyPress;
            specificHeat.KeyPress += specificHeat_KeyPress;
            alpha.KeyPress += alpha_KeyPress;
        }

        private void density_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Проверка на ввод только числовых символов, Backspace и точку
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Проверка на точку или запятую для ввода дробных чисел
            if ((e.KeyChar == '.' || e.KeyChar == ',') && textBox.Text.Contains('.'))
            {
                e.Handled = true;
            }

            // Замена запятой на точку для правильного ввода дробных чисел
            if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
            }

            // Если пользователь начинает вводить десятичную часть с запятой или точки, автоматически добавляем "0."
            if ((textBox.SelectionStart == 0 || textBox.Text == "") && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                textBox.Text = "0" + e.KeyChar;
                textBox.SelectionStart = 2; // Переместить курсор в конец
                e.Handled = true; // Предотвращаем добавление второй точки или запятой
            }

            // Проверка на количество цифр после десятичной точки
            if (textBox.Text.Contains('.'))
            {
                int indexOfDot = textBox.Text.IndexOf('.');
                if (textBox.Text.Length - indexOfDot > 2 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            // Разрешаем вводить точку только после ввода двух цифр
            if ((e.KeyChar == '.' || e.KeyChar == ',') && textBox.Text.Length < 2)
            {
                e.Handled = true;
            }
        }

        private void specificHeat_KeyPress(object sender, KeyPressEventArgs e)
        {
            density_KeyPress(sender, e); // Логика идентична textBox1_KeyPress
        }

        private void alpha_KeyPress(object sender, KeyPressEventArgs e)
        {
            density_KeyPress(sender, e); // Логика идентична textBox1_KeyPress
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(density.Text) || string.IsNullOrEmpty(alpha.Text) || string.IsNullOrEmpty(specificHeat.Text))
            {
                MessageBox.Show("Please fill in all fields!");
            }
            else if (selectedMetod == 0)
            {
                MessageBox.Show("Method not selected!");
            }
            else if (selectedMetod == 1)
            {
                double densityValue = double.Parse(density.Text);
                double specificHeatValue = double.Parse(specificHeat.Text);
                double alphaValue = double.Parse(alpha.Text);

                selectedMetod = 2;
                Singl singl = new Singl(densityValue, specificHeatValue, alphaValue, selectedMetod);
                singl.Show();
                this.Hide();
            }
            else if (selectedMetod == 2)
            {
                TDimen dimen = new TDimen(selectedMetod);
                dimen.Show();
                this.Hide();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            selectedMetod = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedMetod = 2;
        }

        private void back_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();

            this.Close();
        }
    }
}
