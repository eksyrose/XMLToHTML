using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestCaseForEcoCompany
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // todo: проверить на непустые
            Record r = new Record(textBoxCategory.Text, textBoxTitle.Text, textBoxAuthor.Text, textBoxPrice.Text); 
            //создаём новую запись, используя данные из textbox-ов
            XMLToHTML.AddNewRecordToXMLDocument(r); //добавляем запись в документ
            this.Close(); //закрываем форму
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close(); //закрываем форму
        }
        
    }
}
