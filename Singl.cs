using System;
using System.Linq;
using System.Windows.Forms;

namespace Version2
{
    public partial class Singl : Form
    {
        public Singl()
        {
            InitializeComponent();
            textBox1.KeyPress += textBox1_KeyPress; // Привязываем событие KeyPress к textBox1
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получение введенной пользователем суммы
            if (double.TryParse(textBox1.Text, out double amount))
            {
                // Действия с введенной суммой
                MessageBox.Show($"Вы ввели сумму: {amount}");
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму.");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка на ввод только числовых символов или Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Проверка на точку для ввода дробных чисел
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        
    }
}
