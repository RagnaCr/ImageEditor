using System.Windows.Forms;

namespace SP_coursework
{
    partial class NoiseSettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox noiseTypeComboBox;
        private NumericUpDown meanNumericUpDown;
        private NumericUpDown varianceNumericUpDown;
        private Button okButton;
        private Button cancelButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.noiseTypeComboBox = new System.Windows.Forms.ComboBox();
            this.meanNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.varianceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.meanNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varianceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // noiseTypeComboBox
            // 
            this.noiseTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.noiseTypeComboBox.FormattingEnabled = true;
            this.noiseTypeComboBox.Items.AddRange(new object[] {
            "Gaussian",
            "Speckle"});
            this.noiseTypeComboBox.Location = new System.Drawing.Point(16, 15);
            this.noiseTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.noiseTypeComboBox.Name = "noiseTypeComboBox";
            this.noiseTypeComboBox.Size = new System.Drawing.Size(160, 24);
            this.noiseTypeComboBox.TabIndex = 0;
            // 
            // meanNumericUpDown
            // 
            this.meanNumericUpDown.DecimalPlaces = 2;
            this.meanNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.meanNumericUpDown.Location = new System.Drawing.Point(16, 48);
            this.meanNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.meanNumericUpDown.Name = "meanNumericUpDown";
            this.meanNumericUpDown.Size = new System.Drawing.Size(160, 22);
            this.meanNumericUpDown.TabIndex = 1;
            // 
            // varianceNumericUpDown
            // 
            this.varianceNumericUpDown.DecimalPlaces = 2;
            this.varianceNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.varianceNumericUpDown.Location = new System.Drawing.Point(16, 80);
            this.varianceNumericUpDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.varianceNumericUpDown.Name = "varianceNumericUpDown";
            this.varianceNumericUpDown.Size = new System.Drawing.Size(160, 22);
            this.varianceNumericUpDown.TabIndex = 2;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(16, 112);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 28);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(124, 112);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "мат. очік.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "дисперсія";
            // 
            // NoiseSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 155);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.varianceNumericUpDown);
            this.Controls.Add(this.meanNumericUpDown);
            this.Controls.Add(this.noiseTypeComboBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NoiseSettingsForm";
            this.Text = "Noise Settings";
            this.Load += new System.EventHandler(this.NoiseSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.meanNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varianceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private Label label2;
    }

}