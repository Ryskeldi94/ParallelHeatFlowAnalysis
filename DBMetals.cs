using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Version2
{
    public partial class DBMetals : Form
    {
        [DllImport("HeatEquationSolver.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr solveHeatEquation1D(double density, double specificHeat, double alpha, int highTempLocation, float initialTemperature, float ambientTemperature, int numSteps, int nx);

        private List<Metal> metalsList; // объявляем переменную как член класса

        public DBMetals()
        {
            InitializeComponent();

            comboBoxMetals.DropDownStyle = ComboBoxStyle.DropDownList;


            // Загрузка данных из JSON файла
            string jsonFilePath = "C:\\Users\\rrysk\\OneDrive\\Рабочий стол\\Диплом\\Диплом граф интерфеис\\Version2\\metals.json";
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);

                // Десериализация JSON данных в список металлов
                metalsList = JsonConvert.DeserializeObject<MetalsList>(jsonData).Металлы; // присваиваем значение переменной
                                                                                          // используем ключевое слово this, чтобы явно указать на член класса
                foreach (var metal in this.metalsList)
                {
                    comboBoxMetals.Items.Add(metal.Название);
                }
            }
            else
            {
                MessageBox.Show("Файл 'metals.json' не найден!");
            }
        }

        private void ShowItems_Click(object sender, EventArgs e)
        {
            // Получаем выбранный металл из ComboBox
            string selectedMetalName = comboBoxMetals.SelectedItem.ToString();
            Metal selectedMetal = metalsList.FirstOrDefault(m => m.Название == selectedMetalName);

            if (selectedMetal != null)
            {
                // Отображаем свойства выбранного металла в MessageBox
                MessageBox.Show(
                                $"Плотность: {selectedMetal.Плотность} г/см³\n" +
                                $"Удельная теплоемкость: {selectedMetal.УдельнаяТеплоемкость} Дж/г·°C\n" +
                                $"Коэффициент теплопроводности: {selectedMetal.КоэффициентТеплопроводности} Вт/м·°C");

            }
            else
            {
                MessageBox.Show("Металл не выбран!");
            }
        }

        private void SelectThis_Click(object sender, EventArgs e)
        {
            string selectedMetalName = comboBoxMetals.SelectedItem.ToString();
            Metal selectedMetal = metalsList.FirstOrDefault(m => m.Название == selectedMetalName);

            if (selectedMetal != null)
            {
                double density = selectedMetal.Плотность;
                double specificHeat = selectedMetal.УдельнаяТеплоемкость;
                double alpha = selectedMetal.КоэффициентТеплопроводности;
                int highTempLocation = 5; // Установите значение на свое усмотрение
                float initialTemperature = 78.0f; // Установите значение на свое усмотрение
                float ambientTemperature = 34.0f; // Установите значение на свое усмотрение
                int numSteps = 100; // Установите значение на свое усмотрение
                int nx = 10; // Установите значение на свое усмотрение

                IntPtr resultPtr = solveHeatEquation1D(density, specificHeat, alpha, highTempLocation, initialTemperature, ambientTemperature, numSteps, nx);

                // Пример обработки результатов
                if (resultPtr != IntPtr.Zero)
                {
                    // Ваш код для обработки результата
                    // Например, преобразование указателя в массив или что-то еще
                }
                else
                {
                    MessageBox.Show("Ошибка при вызове функции из DLL!");
                }
            }
            else
            {
                MessageBox.Show("Металл не выбран!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Singl form3 = new Singl();
            form3.Show();
            this.Hide();
        }
    }

    // Классы для десериализации JSON
    public class Metal
    {
        public int Номер { get; set; }
        public string Название { get; set; }
        public double Плотность { get; set; }
        public double УдельнаяТеплоемкость { get; set; }
        public double КоэффициентТеплопроводности { get; set; }
    }

    public class MetalsList
    {
        public List<Metal> Металлы { get; set; }
    }
}
