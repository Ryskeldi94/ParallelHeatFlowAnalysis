using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Version2
{
    public partial class DBMetals : Form
    {
        private List<Metal> metalsList; // объявляем переменную как член класса
        int selectedMetod = 0;

        public DBMetals()
        {
            InitializeComponent();

            comboBoxMetals.DropDownStyle = ComboBoxStyle.DropDownList;

            // Загрузка данных из JSON файла
            string jsonFilePath = "C:\\Users\\Ryskeldi\\Documents\\ParallelHeatFlowAnalysis\\metals.json";
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);

                // Десериализация JSON данных в список металлов
                metalsList = JsonConvert.DeserializeObject<MetalsList>(jsonData).Металлы; // присваиваем значение переменной
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

                if (selectedMetod == 0)
                {
                    MessageBox.Show("Выберети метод тип решение");
                }
                else if (selectedMetod == 1)
                {
                    Singl form = new Singl(density, specificHeat, alpha, selectedMetod); // Передача значений в конструктор
                    form.Show();
                    this.Hide();
                }
                else if (selectedMetod == 2)
                {
                    selectedMetod = 1;
                    TDimen dimen = new TDimen(selectedMetod);
                    dimen.Show();
                    this.Hide();
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
            selectedMetod = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedMetod = 2;
        }

        private void back_Click(object sender, EventArgs e)
        {
            // Create an instance of MainPage and show it
            MainPage mainPage = new MainPage();
            mainPage.Show(); // Show the instance
            this.Close(); // Close the current form
        }
    }

    // Classes for deserializing JSON
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
