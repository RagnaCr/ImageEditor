
namespace SP_coursework
{
    partial class ShuffleColorsDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RadioButton sequentialModeRadioButton;
        private System.Windows.Forms.RadioButton customModeRadioButton;
        private System.Windows.Forms.ComboBox fromComboBox;
        private System.Windows.Forms.ComboBox toComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;

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
            this.sequentialModeRadioButton = new System.Windows.Forms.RadioButton();
            this.customModeRadioButton = new System.Windows.Forms.RadioButton();
            this.fromComboBox = new System.Windows.Forms.ComboBox();
            this.toComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sequentialModeRadioButton
            // 
            this.sequentialModeRadioButton.AutoSize = true;
            this.sequentialModeRadioButton.Location = new System.Drawing.Point(12, 12);
            this.sequentialModeRadioButton.Name = "sequentialModeRadioButton";
            this.sequentialModeRadioButton.Size = new System.Drawing.Size(158, 21);
            this.sequentialModeRadioButton.TabIndex = 0;
            this.sequentialModeRadioButton.TabStop = true;
            this.sequentialModeRadioButton.Text = "Послідовний режим";
            this.sequentialModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // customModeRadioButton
            // 
            this.customModeRadioButton.AutoSize = true;
            this.customModeRadioButton.Location = new System.Drawing.Point(12, 39);
            this.customModeRadioButton.Name = "customModeRadioButton";
            this.customModeRadioButton.Size = new System.Drawing.Size(159, 21);
            this.customModeRadioButton.TabIndex = 1;
            this.customModeRadioButton.TabStop = true;
            this.customModeRadioButton.Text = "Режим користувача";
            this.customModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // fromComboBox
            // 
            this.fromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromComboBox.FormattingEnabled = true;
            this.fromComboBox.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.fromComboBox.Location = new System.Drawing.Point(12, 89);
            this.fromComboBox.Name = "fromComboBox";
            this.fromComboBox.Size = new System.Drawing.Size(121, 24);
            this.fromComboBox.TabIndex = 2;
            // 
            // toComboBox
            // 
            this.toComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toComboBox.FormattingEnabled = true;
            this.toComboBox.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.toComboBox.Location = new System.Drawing.Point(150, 89);
            this.toComboBox.Name = "toComboBox";
            this.toComboBox.Size = new System.Drawing.Size(121, 24);
            this.toComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Поміняти колір:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "З коліором:";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 130);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(196, 130);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // ShuffleColorsDialog
            // 
            this.AcceptButton = this.okButton;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(284, 165);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toComboBox);
            this.Controls.Add(this.fromComboBox);
            this.Controls.Add(this.customModeRadioButton);
            this.Controls.Add(this.sequentialModeRadioButton);
            this.Name = "ShuffleColorsDialog";
            this.Text = "Shuffle Colors";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}