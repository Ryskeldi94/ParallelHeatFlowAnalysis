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
    public partial class TDimen : Form
    {
       
        public TDimen()
        {
            InitializeComponent();
            highTempLocation.KeyPress += textBox1_KeyPress; // Привязываем событие KeyPress к textBox1
            ambientTemperature.KeyPress += textBox2_KeyPress;
            initialTemperature.KeyPress += textBox3_KeyPress;
            textBox5.KeyPress += textBox5_KeyPress;

        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка на ввод только цифр и Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Проверка на ввод только числовых символов, Backspace и точку
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Проверка на точку или запятую для ввода дробных чисел
            if ((e.KeyChar == '.' || e.KeyChar == ',') && textBox.Text.Contains('.') && textBox.Text.Contains(','))
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
        }




        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Проверка на ввод только числовых символов, Backspace и точку
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Проверка на точку или запятую для ввода дробных чисел
            if ((e.KeyChar == '.' || e.KeyChar == ',') && textBox.Text.Contains('.') && textBox.Text.Contains(','))
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(highTempLocation.Text) || string.IsNullOrEmpty(ambientTemperature.Text) || string.IsNullOrEmpty(initialTemperature.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
            }
            else
            {

                // Здесь можно выполнить действия, которые нужно совершить при заполненных полях
            }
        }

        

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка на ввод только цифр и Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
