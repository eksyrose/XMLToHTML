using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Collections.ObjectModel;
using System.IO;

namespace TestCaseForEcoCompany
{
    public static class XMLToHTML
    {       
        private static string _path = ""; //путь к XML-файлу
        private static XmlDocument originalXml = new XmlDocument();
        public static void SetPathToXMLDocument(string path) //Сохраняем путь к XML-файлу
        {
            XMLToHTML._path = path; //запоминаем путь к файлу в приватной переменной _path для последующей работы с ним в текущем классе
        }

        public static Collection<Record> OpenXMLDocument() //Процедура открытия и чтения XML-документа, возвращающая коллекцию записей
        {
            Collection<Record> AllRecords = new Collection<Record>();
            foreach (XElement level1Element in XElement.Load(_path).Elements("book")) //читаем данные из xml-файла и добавляем их в коллекцию 
            {
                string tempcategory = "";
                string temptitle = "";
                string tempauthor = "";
                string tempprice = "";
                if (level1Element.HasAttributes) //если у элемента есть атрибуты
                {
                    try
                    {
                        tempcategory = level1Element.Attribute("category").Value; //считываем данные элемента
                        temptitle = level1Element.Element("title").Value;
                        // = level1Element.Element("year").Value;
                        tempprice = level1Element.Element("price").Value;

                        StringBuilder authors = new StringBuilder(); //на случай, когда авторов несколько, объединяем их в одну строку
                        foreach (XElement x in level1Element.Elements("author"))
                        {
                            authors.Append(x.Value + "; ");
                        }
                        authors.Remove(authors.Length-2, 2); //удаляем лишнюю точку с запятой и пробел в конце

                        tempauthor = authors.ToString();
                        Record newrecord = new Record(tempcategory, temptitle, tempauthor, tempprice); //создаём новую запись
                        AllRecords.Add(newrecord); //добавляем запись в массив
                    }
                    catch (Exception) { }
                }              
            }
            return AllRecords;        
        }

        public static void AddNewRecordToXMLDocument(Record record) //Добавление новой записи в XML-документ
        {
            if (_path != "") //если путь к файлу указан
            {
                originalXml.Load(_path); //загружаем документ
                XmlNode menu = originalXml.SelectSingleNode("//bookstore"); //выбираем главный узел
                XmlNode newSub = originalXml.CreateNode(XmlNodeType.Element, "book", null); //создаём новый дочерний узел book
                XmlAttribute category = originalXml.CreateAttribute("category"); //создаём атрибут category 
                category.Value = record.Category; //присваиваем ему значение
                newSub.Attributes.Append(category); //добавляем атрибут в узел
                
                //string[] s = {"title", "author", "price"};
                //foreach (string str in s)
 
                XmlNode title = originalXml.CreateNode(XmlNodeType.Element, "title", null); //заголовок
                title.InnerText = record.Title;
                newSub.AppendChild(title); //добавляем заголовок
                XmlNode author = originalXml.CreateNode(XmlNodeType.Element, "author", null); //автор
                author.InnerText = record.Author; //  todo: разделить авторов
                newSub.AppendChild(author); //добавляем автора
                XmlNode price = originalXml.CreateNode(XmlNodeType.Element, "price", null); //цена
                price.InnerText = record.Price;
                newSub.AppendChild(price); //добавляем цену
                menu.AppendChild(newSub); //добавляем созданный узел с атрибутами в XML-файл  
                XMLToHTML.SaveXMLDocument(); //сохраняем документ
            }
        }

        public static void RemoveRecordFromXMLDocument(int index) //Удаление записи из XML-документа
        {
            originalXml.Load(_path);
            XmlNode menu = originalXml.SelectSingleNode("//bookstore"); //выбираем корневой узел
            if (index == 0) menu.RemoveChild(menu.FirstChild); 
            else menu.RemoveChild(menu.ChildNodes.Item(index));
            XMLToHTML.SaveXMLDocument(); //сохраняем документ
        }

        public static void SaveXMLDocument() //Сохранение выбранного XML-документа 
        {
            if ((originalXml != null) && (_path != ""))
                originalXml.Save(_path); 
        }

        public static void SaveXMLDocument(string path) //Сохранение выбранного XML-документа по новому адресу
        {
            if ((originalXml != null) && (path != ""))
            {
                /*XmlWriterSettings s = new XmlWriterSettings();
                s.Indent = true;
                s.NewLineOnAttributes = true; //задаёт отступы
                XmlWriter writer = XmlWriter.Create(_path, s);*/
                
                /*writer.WriteRaw("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                //writer.
                writer.Close();*/
                //originalXml.PreserveWhitespace = true;
                //originalXml.Save(path);
            }
        }

        public static void ConvertToHTML(string pathtotemplate) //Генерация отчёта в HTML на основе существующего XML-файла
        {
            string filename = "report.html";
            if (_path != "") 
            {
                XslCompiledTransform xslt = new XslCompiledTransform(); 
                xslt.Load(pathtotemplate); //загружаем шаблон 
                using (FileStream fs = 
                    new FileStream(Environment.CurrentDirectory + "\\" + filename, FileMode.Create)) { }  //создаём HTML-файл для выгрузки отчёта
                xslt.Transform(_path, Environment.CurrentDirectory + "\\" + filename); //конвертируем XML в HTML и сохраняем в созданном файле
            }
        }

        /*Using LINQ to xml if you are using framework 3.5

using System.Xml.Linq;

XDocument xmlFile = XDocument.Load("books.xml"); 
var query = from c in xmlFile.Elements("catalog").Elements("book")    
            select c; 
foreach (XElement book in query) 
{
    book.Attribute("attr1").Value = "MyNewValue";
}
xmlFile.Save("books.xml");
         * */

        
    }
}
