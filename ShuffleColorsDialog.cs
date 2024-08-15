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
    public partial class ShuffleColorsDialog : Form
    {
        public string SelectedMode { get; private set; }
        public Dictionary<string, string> SelectedComponentSwap { get; private set; }

        public ShuffleColorsDialog()
        {
            InitializeComponent();
            SelectedComponentSwap = new Dictionary<string, string>();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (sequentialModeRadioButton.Checked)
            {
                SelectedMode = "Sequential";
            }
            else if (customModeRadioButton.Checked)
            {
                SelectedMode = "Custom";
                SelectedComponentSwap[fromComboBox.SelectedItem.ToString()] = toComboBox.SelectedItem.ToString();
            }
            DialogResult = DialogResult.OK;
        }
    }

}
