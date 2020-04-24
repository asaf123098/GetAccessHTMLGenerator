namespace GetAccessHTMLGenerator
{
    partial class DescriptionGenerator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DescriptionGenerator));
            this.label1 = new System.Windows.Forms.Label();
            this.lineHeader = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.generateHtmlButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rowsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addRowButton = new System.Windows.Forms.Button();
            this.imageLink = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rowsListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.suppliersWarranties = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.rowsListContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line Header:";
            // 
            // productName
            // 
            this.lineHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineHeader.Location = new System.Drawing.Point(115, 45);
            this.lineHeader.Name = "productName";
            this.lineHeader.Size = new System.Drawing.Size(331, 20);
            this.lineHeader.TabIndex = 1;
            this.lineHeader.TextChanged += new System.EventHandler(this.ProductName_TextChanged);
            // 
            // description
            // 
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.description.Location = new System.Drawing.Point(115, 75);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(331, 118);
            this.description.TabIndex = 5;
            this.description.TextChanged += new System.EventHandler(this.Description_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description:";
            // 
            // generateHtmlButton
            // 
            this.generateHtmlButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generateHtmlButton.Enabled = false;
            this.generateHtmlButton.Location = new System.Drawing.Point(490, 455);
            this.generateHtmlButton.Name = "generateHtmlButton";
            this.generateHtmlButton.Size = new System.Drawing.Size(157, 23);
            this.generateHtmlButton.TabIndex = 6;
            this.generateHtmlButton.Text = "Generate HTML";
            this.generateHtmlButton.UseVisualStyleBackColor = true;
            this.generateHtmlButton.Click += new System.EventHandler(this.generateHtmlButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(452, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // rowsList
            // 
            this.rowsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rowsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.rowsList.FullRowSelect = true;
            this.rowsList.HideSelection = false;
            this.rowsList.Location = new System.Drawing.Point(115, 259);
            this.rowsList.Name = "rowsList";
            this.rowsList.Size = new System.Drawing.Size(532, 181);
            this.rowsList.TabIndex = 8;
            this.rowsList.UseCompatibleStateImageBehavior = false;
            this.rowsList.View = System.Windows.Forms.View.Details;
            this.rowsList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListedItemsList_MouseClick);
            this.rowsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RowsList_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Picture";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Header";
            this.columnHeader2.Width = 105;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 313;
            // 
            // addRowButton
            // 
            this.addRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addRowButton.Enabled = false;
            this.addRowButton.Location = new System.Drawing.Point(452, 170);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(195, 23);
            this.addRowButton.TabIndex = 9;
            this.addRowButton.Text = "Add Row";
            this.addRowButton.UseVisualStyleBackColor = true;
            this.addRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // imageLink
            // 
            this.imageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageLink.Location = new System.Drawing.Point(115, 14);
            this.imageLink.Name = "imageLink";
            this.imageLink.Size = new System.Drawing.Size(331, 20);
            this.imageLink.TabIndex = 12;
            this.imageLink.TextChanged += new System.EventHandler(this.ImageLink_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Image Link:";
            // 
            // rowsListContextMenuStrip
            // 
            this.rowsListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.rowsListContextMenuStrip.Name = "contextMenuStrip1";
            this.rowsListContextMenuStrip.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteClicked);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(18, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 31);
            this.label4.TabIndex = 13;
            this.label4.Text = "Warranty And Returns:";
            // 
            // suppliersWarranties
            // 
            this.suppliersWarranties.FormattingEnabled = true;
            this.suppliersWarranties.Location = new System.Drawing.Point(115, 211);
            this.suppliersWarranties.Name = "suppliersWarranties";
            this.suppliersWarranties.Size = new System.Drawing.Size(331, 34);
            this.suppliersWarranties.TabIndex = 14;
            // 
            // DescriptionGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 491);
            this.Controls.Add(this.suppliersWarranties);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.imageLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addRowButton);
            this.Controls.Add(this.rowsList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.generateHtmlButton);
            this.Controls.Add(this.description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lineHeader);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(645, 459);
            this.Name = "DescriptionGenerator";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.Text = "Description Generator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.rowsListContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lineHeader;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button generateHtmlButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView rowsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button addRowButton;
        private System.Windows.Forms.TextBox imageLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip rowsListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox suppliersWarranties;
    }
}

