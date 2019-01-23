namespace CopyStructure
{
    partial class CopyStructForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.copyStructureButton = new System.Windows.Forms.Button();
            this.saveSameButton = new System.Windows.Forms.Button();
            this.SaveNewButton = new System.Windows.Forms.Button();
            this.newNameTextBox = new System.Windows.Forms.TextBox();
            this.newNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // copyStructureButton
            // 
            this.copyStructureButton.Location = new System.Drawing.Point(76, 43);
            this.copyStructureButton.Name = "copyStructureButton";
            this.copyStructureButton.Size = new System.Drawing.Size(98, 31);
            this.copyStructureButton.TabIndex = 0;
            this.copyStructureButton.Text = "Copy Structure";
            this.copyStructureButton.UseVisualStyleBackColor = true;
            this.copyStructureButton.Click += new System.EventHandler(this.copyStructureButton_Click);
            // 
            // saveSameButton
            // 
            this.saveSameButton.Location = new System.Drawing.Point(59, 175);
            this.saveSameButton.Name = "saveSameButton";
            this.saveSameButton.Size = new System.Drawing.Size(136, 23);
            this.saveSameButton.TabIndex = 1;
            this.saveSameButton.Text = "Save At Same Directory";
            this.saveSameButton.UseVisualStyleBackColor = true;
            this.saveSameButton.Click += new System.EventHandler(this.saveSameButton_Click);
            // 
            // SaveNewButton
            // 
            this.SaveNewButton.Location = new System.Drawing.Point(59, 204);
            this.SaveNewButton.Name = "SaveNewButton";
            this.SaveNewButton.Size = new System.Drawing.Size(136, 23);
            this.SaveNewButton.TabIndex = 2;
            this.SaveNewButton.Text = "Save At New Directory";
            this.SaveNewButton.UseVisualStyleBackColor = true;
            this.SaveNewButton.Click += new System.EventHandler(this.saveNewButton_Click);
            // 
            // newNameTextBox
            // 
            this.newNameTextBox.Location = new System.Drawing.Point(59, 131);
            this.newNameTextBox.Name = "newNameTextBox";
            this.newNameTextBox.Size = new System.Drawing.Size(136, 20);
            this.newNameTextBox.TabIndex = 3;
            this.newNameTextBox.TextChanged += new System.EventHandler(this.newNameTextBox_TextChanged);
            // 
            // newNameLabel
            // 
            this.newNameLabel.AutoSize = true;
            this.newNameLabel.Location = new System.Drawing.Point(78, 115);
            this.newNameLabel.Name = "newNameLabel";
            this.newNameLabel.Size = new System.Drawing.Size(96, 13);
            this.newNameLabel.TabIndex = 4;
            this.newNameLabel.Text = "New Project Name";
            // 
            // copyStructForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 255);
            this.Controls.Add(this.newNameLabel);
            this.Controls.Add(this.newNameTextBox);
            this.Controls.Add(this.SaveNewButton);
            this.Controls.Add(this.saveSameButton);
            this.Controls.Add(this.copyStructureButton);
            this.Name = "copyStructForm";
            this.Text = "Copy Strucrure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button copyStructureButton;
        private System.Windows.Forms.Button saveSameButton;
        private System.Windows.Forms.Button SaveNewButton;
        private System.Windows.Forms.TextBox newNameTextBox;
        private System.Windows.Forms.Label newNameLabel;
    }
}

