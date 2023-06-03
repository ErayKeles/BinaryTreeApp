namespace BinaryTreeApp
{
    partial class BinaryTreeView
    {
        private System.ComponentModel.IContainer components = null;

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
            this.insertButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.preorderButton = new System.Windows.Forms.Button();
            this.inorderButton = new System.Windows.Forms.Button();
            this.postorderButton = new System.Windows.Forms.Button();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.traversalListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(16, 15);
            this.insertButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(100, 28);
            this.insertButton.TabIndex = 0;
            this.insertButton.Text = "Ekle";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(124, 15);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 28);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Sil";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(232, 15);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 28);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Ara";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // preorderButton
            // 
            this.preorderButton.Location = new System.Drawing.Point(340, 15);
            this.preorderButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.preorderButton.Name = "preorderButton";
            this.preorderButton.Size = new System.Drawing.Size(100, 28);
            this.preorderButton.TabIndex = 3;
            this.preorderButton.Text = "Preorder";
            this.preorderButton.UseVisualStyleBackColor = true;
            this.preorderButton.Click += new System.EventHandler(this.preorderButton_Click);
            // 
            // inorderButton
            // 
            this.inorderButton.Location = new System.Drawing.Point(448, 15);
            this.inorderButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inorderButton.Name = "inorderButton";
            this.inorderButton.Size = new System.Drawing.Size(100, 28);
            this.inorderButton.TabIndex = 4;
            this.inorderButton.Text = "Inorder";
            this.inorderButton.UseVisualStyleBackColor = true;
            this.inorderButton.Click += new System.EventHandler(this.inorderButton_Click);
            // 
            // postorderButton
            // 
            this.postorderButton.Location = new System.Drawing.Point(556, 15);
            this.postorderButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.postorderButton.Name = "postorderButton";
            this.postorderButton.Size = new System.Drawing.Size(100, 28);
            this.postorderButton.TabIndex = 5;
            this.postorderButton.Text = "Postorder";
            this.postorderButton.UseVisualStyleBackColor = true;
            this.postorderButton.Click += new System.EventHandler(this.postorderButton_Click);
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(664, 17);
            this.valueTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(132, 22);
            this.valueTextBox.TabIndex = 6;
            // 
            // traversalListBox
            // 
            this.traversalListBox.FormattingEnabled = true;
            this.traversalListBox.ItemHeight = 16;
            this.traversalListBox.Location = new System.Drawing.Point(398, 383);
            this.traversalListBox.Name = "traversalListBox";
            this.traversalListBox.Size = new System.Drawing.Size(234, 116);
            this.traversalListBox.TabIndex = 7;
            // 
            // BinaryTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.traversalListBox);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.postorderButton);
            this.Controls.Add(this.inorderButton);
            this.Controls.Add(this.preorderButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.insertButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BinaryTreeView";
            this.Text = "Binary Tree View";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button preorderButton;
        private System.Windows.Forms.Button inorderButton;
        private System.Windows.Forms.Button postorderButton;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.ListBox traversalListBox;
    }
}

