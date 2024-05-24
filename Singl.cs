using System;
using System.Linq;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Version2
{
    public partial class Singl : Form
    {
        private double _density;
        private double _specificHeat;
        private double _thermalConductivity;

        // Конструктор с параметрами для передачи свойств металла
        // Property to store the selected method value
        public int SelectedMethod { get; set; }

        // Constructor
        public Singl(double density, double specificHeat, double thermalConductivity, int selectedMethod)
        {
            InitializeComponent();
            highTempLocation.KeyPress += textBox1_KeyPress; // Привязываем событие KeyPress к textBox1
            ambientTemperature.KeyPress += textBox2_KeyPress;
            initialTemperature.KeyPress += textBox3_KeyPress;

            _density = density;
            _specificHeat = specificHeat;
            _thermalConductivity = thermalConductivity;
            SelectedMethod = selectedMethod; // Store the selected method value
        }

        public Singl()
        {
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2_KeyPress(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(highTempLocation.Text) || string.IsNullOrEmpty(ambientTemperature.Text) || string.IsNullOrEmpty(initialTemperature.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
            }
            else
            {
                double density = _density;
                double specificHeat = _specificHeat;
                double alpha = _thermalConductivity;

                string highTemp = highTempLocation.Text;
                string ambientTemp = ambientTemperature.Text;
                string initialTemp = initialTemperature.Text;

                int highTempValue = int.Parse(highTemp);
                float ambientTempValue = float.Parse(ambientTemp);
                float initialTempValue = float.Parse(initialTemp);

                soket(density, specificHeat, alpha, highTempValue, ambientTempValue, initialTempValue);
            }
        }

        private void ambientTemperature_TextChanged(object sender, EventArgs e)
        {

        }

        static void soket(double density, double specificHeat, double alpha, int highTempLocation, float initialTemperature, float ambientTemperature)
        {
            string server = "127.0.0.1";
            int port = 54000;

            try
            {
                using (TcpClient client = new TcpClient(server, port))
                {
                    NetworkStream stream = client.GetStream();

                    int numSteps = 100;
                    int nx = 10;

                    byte[] data = BitConverter.GetBytes(density);
                    stream.Write(data, 0, data.Length);

                    data = BitConverter.GetBytes(specificHeat);
                    stream.Write(data, 0, data.Length);

                    data = BitConverter.GetBytes(alpha);
                    stream.Write(data, 0, data.Length);

                    data = BitConverter.GetBytes(highTempLocation);
                    stream.Write(data, 0, data.Length);

                    data = BitConverter.GetBytes(initialTemperature);
                    stream.Write(data, 0, data.Length);

                    data = BitConverter.GetBytes(ambientTemperature);
                    stream.Write(data, 0, data.Length);

                    data = BitConverter.GetBytes(numSteps);
                    stream.Write(data, 0, data.Length);

                    data = BitConverter.GetBytes(nx);
                    stream.Write(data, 0, data.Length);

                    // Выделение буфера правильного размера для результатов двойной точности
                    data = new byte[nx * numSteps * sizeof(double)];
                    stream.Read(data, 0, data.Length);

                    double[] result = new double[nx * numSteps];
                    Buffer.BlockCopy(data, 0, result, 0, data.Length);

                    // Где-то в вашем коде после получения результатов

                    // Формируем текстовое представление результатов
                    string resultsText = "Результаты:\r\n";
                    for (int i = 0; i < numSteps; ++i)
                    {
                        for (int j = 0; j < nx; ++j)
                        {
                            resultsText += result[i * nx + j] + " ";
                        }
                        resultsText += "\r\n";
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (SelectedMethod == 1)
            {
                DBMetals dbMetalsForm = new DBMetals();
                dbMetalsForm.Show();
                this.Close();
            }
            else if (SelectedMethod == 2)
            {
                EnterPro enterProForm = new EnterPro();
                enterProForm.Show();
                this.Close();
            }
        }
    }
}