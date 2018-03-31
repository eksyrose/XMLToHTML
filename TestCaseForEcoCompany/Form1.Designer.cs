namespace TestCaseForEcoCompany
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OpenXML = new System.Windows.Forms.Button();
            this.SaveXML = new System.Windows.Forms.Button();
            this.ConvertToHTML = new System.Windows.Forms.Button();
            this.DeleteRecord = new System.Windows.Forms.Button();
            this.AddRecord = new System.Windows.Forms.Button();
            this.OpenXMLDialog = new System.Windows.Forms.OpenFileDialog();
            this.openXSLDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveXMLAs = new System.Windows.Forms.Button();
            this.saveXMLDialog = new System.Windows.Forms.SaveFileDialog();
            this.Book = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Book,
            this.Author,
            this.Category,
            this.Price});
            this.dataGridView1.Location = new System.Drawing.Point(30, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(449, 244);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // OpenXML
            // 
            this.OpenXML.Location = new System.Drawing.Point(30, 13);
            this.OpenXML.Name = "OpenXML";
            this.OpenXML.Size = new System.Drawing.Size(75, 23);
            this.OpenXML.TabIndex = 1;
            this.OpenXML.Text = "Open XML";
            this.OpenXML.UseVisualStyleBackColor = true;
            this.OpenXML.Click += new System.EventHandler(this.OpenXML_Click);
            // 
            // SaveXML
            // 
            this.SaveXML.Location = new System.Drawing.Point(111, 13);
            this.SaveXML.Name = "SaveXML";
            this.SaveXML.Size = new System.Drawing.Size(75, 23);
            this.SaveXML.TabIndex = 2;
            this.SaveXML.Text = "Save XML";
            this.SaveXML.UseVisualStyleBackColor = true;
            // 
            // ConvertToHTML
            // 
            this.ConvertToHTML.Location = new System.Drawing.Point(363, 12);
            this.ConvertToHTML.Name = "ConvertToHTML";
            this.ConvertToHTML.Size = new System.Drawing.Size(116, 23);
            this.ConvertToHTML.TabIndex = 3;
            this.ConvertToHTML.Text = "Convert To HTML";
            this.ConvertToHTML.UseVisualStyleBackColor = true;
            this.ConvertToHTML.Click += new System.EventHandler(this.ConvertToHTML_Click);
            // 
            // DeleteRecord
            // 
            this.DeleteRecord.Location = new System.Drawing.Point(30, 329);
            this.DeleteRecord.Name = "DeleteRecord";
            this.DeleteRecord.Size = new System.Drawing.Size(98, 23);
            this.DeleteRecord.TabIndex = 4;
            this.DeleteRecord.Text = "Delete Record";
            this.DeleteRecord.UseVisualStyleBackColor = true;
            this.DeleteRecord.Click += new System.EventHandler(this.DeleteRecord_Click);
            // 
            // AddRecord
            // 
            this.AddRecord.Location = new System.Drawing.Point(404, 329);
            this.AddRecord.Name = "AddRecord";
            this.AddRecord.Size = new System.Drawing.Size(75, 23);
            this.AddRecord.TabIndex = 5;
            this.AddRecord.Text = "Add Record";
            this.AddRecord.UseVisualStyleBackColor = true;
            this.AddRecord.Click += new System.EventHandler(this.AddRecord_Click);
            // 
            // OpenXMLDialog
            // 
            this.OpenXMLDialog.Filter = "XML files *.xml|*.xml";
            // 
            // openXSLDialog
            // 
            this.openXSLDialog.Filter = "XSL files *.xsl|*.xsl";
            // 
            // SaveXMLAs
            // 
            this.SaveXMLAs.Location = new System.Drawing.Point(192, 13);
            this.SaveXMLAs.Name = "SaveXMLAs";
            this.SaveXMLAs.Size = new System.Drawing.Size(94, 23);
            this.SaveXMLAs.TabIndex = 6;
            this.SaveXMLAs.Text = "Save XML as...";
            this.SaveXMLAs.UseVisualStyleBackColor = true;
            this.SaveXMLAs.Click += new System.EventHandler(this.SaveXMLAs_Click);
            // 
            // saveXMLDialog
            // 
            this.saveXMLDialog.DefaultExt = "xml";
            this.saveXMLDialog.Filter = "XML files *.xml|*.xml";
            // 
            // Book
            // 
            this.Book.HeaderText = "Book";
            this.Book.Name = "Book";
            this.Book.ReadOnly = true;
            // 
            // Author
            // 
            this.Author.HeaderText = "Author";
            this.Author.Name = "Author";
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 394);
            this.Controls.Add(this.SaveXMLAs);
            this.Controls.Add(this.AddRecord);
            this.Controls.Add(this.DeleteRecord);
            this.Controls.Add(this.ConvertToHTML);
            this.Controls.Add(this.SaveXML);
            this.Controls.Add(this.OpenXML);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button OpenXML;
        private System.Windows.Forms.Button SaveXML;
        private System.Windows.Forms.Button ConvertToHTML;
        private System.Windows.Forms.Button DeleteRecord;
        private System.Windows.Forms.Button AddRecord;
        private System.Windows.Forms.OpenFileDialog OpenXMLDialog;
        private System.Windows.Forms.OpenFileDialog openXSLDialog;
        private System.Windows.Forms.Button SaveXMLAs;
        private System.Windows.Forms.SaveFileDialog saveXMLDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}

