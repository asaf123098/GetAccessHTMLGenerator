namespace GetAccessHTMLGenerator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.productName = new System.Windows.Forms.TextBox();
            this.imageLink = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.generateHtmlButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rowsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addRowButton = new System.Windows.Forms.Button();
            this.removeSelectedButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line Header:";
            // 
            // productName
            // 
            this.productName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productName.Location = new System.Drawing.Point(92, 14);
            this.productName.Name = "productName";
            this.productName.Size = new System.Drawing.Size(305, 20);
            this.productName.TabIndex = 1;
            this.productName.TextChanged += new System.EventHandler(this.productName_TextChanged);
            // 
            // imageLink
            // 
            this.imageLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageLink.Location = new System.Drawing.Point(92, 44);
            this.imageLink.Name = "imageLink";
            this.imageLink.Size = new System.Drawing.Size(305, 20);
            this.imageLink.TabIndex = 3;
            this.imageLink.TextChanged += new System.EventHandler(this.imageLink_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Image Link:";
            // 
            // description
            // 
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.description.Location = new System.Drawing.Point(92, 75);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(305, 102);
            this.description.TabIndex = 5;
            this.description.TextChanged += new System.EventHandler(this.description_TextChanged);
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
            this.generateHtmlButton.Location = new System.Drawing.Point(441, 381);
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
            this.pictureBox1.Location = new System.Drawing.Point(403, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // rowsList
            // 
            this.rowsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rowsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.rowsList.HideSelection = false;
            this.rowsList.Location = new System.Drawing.Point(92, 194);
            this.rowsList.Name = "rowsList";
            this.rowsList.Size = new System.Drawing.Size(506, 181);
            this.rowsList.TabIndex = 8;
            this.rowsList.UseCompatibleStateImageBehavior = false;
            this.rowsList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Picture";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Header";
            this.columnHeader2.Width = 142;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 305;
            // 
            // addRowButton
            // 
            this.addRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addRowButton.Enabled = false;
            this.addRowButton.Location = new System.Drawing.Point(403, 154);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(75, 23);
            this.addRowButton.TabIndex = 9;
            this.addRowButton.Text = "Add Row";
            this.addRowButton.UseVisualStyleBackColor = true;
            this.addRowButton.Click += new System.EventHandler(this.addRowButton_Click);
            // 
            // removeSelectedButton
            // 
            this.removeSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeSelectedButton.Location = new System.Drawing.Point(484, 154);
            this.removeSelectedButton.Name = "removeSelectedButton";
            this.removeSelectedButton.Size = new System.Drawing.Size(114, 23);
            this.removeSelectedButton.TabIndex = 10;
            this.removeSelectedButton.Text = "Remove Selected";
            this.removeSelectedButton.UseVisualStyleBackColor = true;
            this.removeSelectedButton.Click += new System.EventHandler(this.removeSelectedButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 417);
            this.Controls.Add(this.removeSelectedButton);
            this.Controls.Add(this.addRowButton);
            this.Controls.Add(this.rowsList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.generateHtmlButton);
            this.Controls.Add(this.description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.imageLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.productName);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(645, 350);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.Text = "Get Aaaaaaaccess";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox productName;
        private System.Windows.Forms.TextBox imageLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button generateHtmlButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView rowsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button addRowButton;
        private System.Windows.Forms.Button removeSelectedButton;
    }
}

