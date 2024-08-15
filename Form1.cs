using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_coursework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm child = new ChildForm();
            child.MdiParent = this;
            child.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tiff"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ChildForm child = new ChildForm();
                child.MdiParent = this;
                child.LoadImage(openFileDialog.FileName);
                child.Show();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm child)
            {
                SaveImage(child);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm child)
            {
                SaveAsImage(child);
            }
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm child)
            {
                child.Close();
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is ChildForm childForm && childForm.HasUnsavedChanges)
                {
                    var result = MessageBox.Show("Сохранить изменения?", "Выход", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        SaveImage(childForm);
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            Application.Exit();
        }

        private void SaveImage(ChildForm child)
        {
            if (child != null)
            {
                if (!string.IsNullOrEmpty(child.FilePath))
                {
                    child.SaveImage();
                }
                else
                {
                    string path = SaveAsImage(child);
                    if (!string.IsNullOrEmpty(path))
                    {
                        child.FilePath = path;
                    }
                }
            }
        }
        private string SaveAsImage(ChildForm child)
        {
            return child != null ? child.SaveImageAs() : string.Empty;
        }

        // Color Inversion
        private void taskToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm child)
            {
                using (var dialog = new ShuffleColorsDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        child.ShuffleColors(dialog.SelectedMode, dialog.SelectedComponentSwap);
                    }
                }
            }
        }
        // Noise to img
        private void taskToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm child)
            {
                using (var noiseSettingsForm = new NoiseSettingsForm())
                {
                    if (noiseSettingsForm.ShowDialog() == DialogResult.OK)
                    {
                        string noiseType = noiseSettingsForm.NoiseType;
                        float mean = noiseSettingsForm.Mean;
                        float variance = noiseSettingsForm.Variance;
                        child.Imnoise(noiseType, mean, variance);
                    }
                }
            }
        }

        // інформація о фотокартці
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is ChildForm child)
            {
                MessageBox.Show(child.GetImageInfo(), "Information");
            }
        }

    }
}

