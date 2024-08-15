using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_coursework
{
    public partial class NoiseSettingsForm : Form
    {
        public string NoiseType { get; private set; }
        public float Mean { get; private set; }
        public float Variance { get; private set; }

        public NoiseSettingsForm()
        {
            InitializeComponent();
        }

        private void NoiseSettingsForm_Load(object sender, EventArgs e)
        {
            // Установка значений по умолчанию
            noiseTypeComboBox.SelectedIndex = 0; // Выбираем первый элемент (Gaussian) по умолчанию
            meanNumericUpDown.Value = 0;
            varianceNumericUpDown.Value = 0.01m;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            NoiseType = noiseTypeComboBox.SelectedItem.ToString();
            Mean = (float)meanNumericUpDown.Value;
            Variance = (float)varianceNumericUpDown.Value;

            // Проверка на допустимость значений
            if (NoiseType == "Gaussian" && Variance <= 0)
            {
                MessageBox.Show("Variance must be greater than 0 for Gaussian noise.");
                return;
            }

            if (NoiseType == "Speckle" && Variance <= 0)
            {
                MessageBox.Show("Variance must be greater than 0 for Speckle noise.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
