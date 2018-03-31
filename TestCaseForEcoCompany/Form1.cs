using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace TestCaseForEcoCompany
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 4; //указываем число колонок
            dataGridView1.Columns[0].Name = "Book";
            dataGridView1.Columns[1].Name = "Author";
            dataGridView1.Columns[2].Name = "Category";
            dataGridView1.Columns[3].Name = "Price";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //режим выделения - выделять можно только строку целиком
            
            SaveXML.Enabled = false; //пока пользователь не выбрал файл, эти кнопки неактивны
            ConvertToHTML.Enabled = false;
            DeleteRecord.Enabled = false;
            AddRecord.Enabled = false;
            SaveXMLAs.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void OpenXML_Click(object sender, EventArgs e) //кнопка открытия XML-файла
        {
            OpenXMLDialog.ShowDialog(); //показываем диалог открытия файла
            if (OpenXMLDialog.FileName != "") //если пользователь выбрал файл
            {
                try
                {
                    XMLToHTML.SetPathToXMLDocument(OpenXMLDialog.FileName); //запоминаем путь к файлу
                    LoadRecordsToDataGridView(); //загружаем записи из файла в DataGridView
           
                    SaveXML.Enabled = true; //когда пользователь выбрал файл, данные кнопки становятся активными
                    ConvertToHTML.Enabled = true;
                    DeleteRecord.Enabled = true;
                    AddRecord.Enabled = true;
                    //SaveXMLAs.Enabled = true;
                }
                catch (Exception ex)
                {
                    string[] s = { "что-то пошло не так при открытии...", ex.Message, "", "" };

                    dataGridView1.Rows.Add(s);
                    dataGridView1.Refresh();
                }
            }
        }

        private void ClearDataGridView() //очистка DataGridView
        {
            while (dataGridView1.Rows.Count>1) 
            {
                dataGridView1.Rows.RemoveAt(0);
            }
        }

        private void LoadRecordsToDataGridView() //загрузка записей в DataGridView
        {
            try
            {
                Collection<Record> AllRecords = new Collection<Record>();
                AllRecords = XMLToHTML.OpenXMLDocument(); //открываем документ и считываем из него записи
                foreach (Record r in AllRecords)
                {
                    string[] s = { r.Title, r.Author, r.Category, r.Price }; //запоминаем данные в массиве строк
                    dataGridView1.Rows.Add(s); //выводим данные в DataGridView
                    dataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            {
                string[] s = { "что-то пошло не так при записи...", ex.Message, "", "" };

                dataGridView1.Rows.Add(s);
                dataGridView1.Refresh();
            }
        }

        private void DeleteRecord_Click(object sender, EventArgs e) //кнопка удаления записи из XML-файла
        {
            if (dataGridView1.RowCount > 1) //если в DataGridView есть данные, т.е. файл, из которого они загружены, не пустой и корректный
            {
                DataGridViewSelectedRowCollection d = dataGridView1.SelectedRows; //получаем коллекцию выделенных пользователем строк
                //DataGridViewSelectedCellCollection c = dataGridView1.SelectedCells;
                if (d.Count == 1) //пока мы можем удалить только строку за раз (хотя можно и групповое удаление сделать, если очень надо)
                {
                    foreach (DataGridViewRow r in d) 
                    {
                        try
                        {
                            XMLToHTML.RemoveRecordFromXMLDocument(r.Index);
                        }
                        catch (InvalidOperationException) { }
                    }
                }
                else MessageBox.Show("Можно удалить только одну строку за раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //dataGridView1.ClearSelection(); 
            }
            ClearDataGridView(); //очищаем DataGridView
            LoadRecordsToDataGridView(); //загружаем обновлённые данные из файла в DataGridView
            dataGridView1.Refresh();
        }

        private void AddRecord_Click(object sender, EventArgs e) //кнопка добавления записи в XML-файл
        {
            Form2 form2 = new Form2(); //создаём форму для ввода данных
            form2.ShowDialog(); //показываем форму, в которой пользователь вводит данные, и в ней вызываем процедуру добавления в файл новой записи
            ClearDataGridView(); //очищаем DataGridView
            LoadRecordsToDataGridView(); //загружаем обновлённые данные из файла в DataGridView
            dataGridView1.Refresh();
        }

        private void ConvertToHTML_Click(object sender, EventArgs e) //кнопка конвертации XML в HTML
        {
            MessageBox.Show("После нажатия кнопки OK откроется диалоговое окно. Пожалуйста, выберите шаблон файла для конвертации (в формате XSL).", "Выбор шаблона", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            openXSLDialog.ShowDialog(); //открываем диалог, в котором пользователь должен выбрать шаблон конвертации
            if (openXSLDialog.FileName != "") XMLToHTML.ConvertToHTML(openXSLDialog.FileName); //если пользователь выбрал шаблон - конвертируем текущий файл в HTML
            MessageBox.Show("Созданный HTML-отчёт находится по адресу " + Environment.CurrentDirectory, "Отчёт успешно создан!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void SaveXMLAs_Click(object sender, EventArgs e)
        {
            //saveXMLDialog.ShowDialog();
            //if (saveXMLDialog.FileName != "") XMLToHTML.SaveXMLDocument(saveXMLDialog.FileName);
        }
    }
}
