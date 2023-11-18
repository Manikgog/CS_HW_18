using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CS_HW_18
{
    public class DataTransfer
    {
        public event Action<string> DataSent;
        public event Action<string> DataReceived;
        public void WriteToJsonFile(string path, Data data)
        {
            string outputJson = JsonConvert.SerializeObject(data);

            System.IO.File.WriteAllText(path, outputJson);

            DataSent?.Invoke("json файл " + path + " успешно отправлен.");

            Data dataFromFile = ReadJsonFile(path);

            if (data.Equals(dataFromFile))
            {
                DataReceived?.Invoke("json файл " + path + " успешно получен.");
            }
        }
        public void WriteToXMLFile(string path, Data data)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Data));
            using (FileStream fstream = new FileStream(path, FileMode.Truncate))
            {
                xml.Serialize(fstream, data);
            }
            DataSent?.Invoke("xml файл " + path + " успешно отправлен.");

            Data dataFromFile = ReadXMLFile(path);

            if (data.Equals(dataFromFile))
            {
                DataReceived?.Invoke("xml файл " + path + " успешно получен.");
            }
        }

        public void WriteToTxtFile(string path, Data data)
        {
            UnicodeEncoding unicode = new UnicodeEncoding();                    // объект для задания кодировки для считывания и записи
            using (StreamWriter writer = new StreamWriter(path, false, unicode))    // запись буфера в файл
            {
                StringBuilder stringBuilder = new StringBuilder();
                
                stringBuilder = stringBuilder.Append(data.ToString());
                
                writer.Write(stringBuilder.ToString()); // запись строки в файл
            }
            DataSent?.Invoke("текстовый файл " + path + " успешно отправлен.");

            Data dataFromFile = ReadTxtFile(path);

            if (data.Equals(dataFromFile))
            {
                DataReceived?.Invoke("текстовый файл " + path + " успешно получен.");
            }
        }

        public Data ReadJsonFile(string path)
        {
            string json = System.IO.File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Data>(json);
        }

        public Data ReadXMLFile(string path)
        {

            XDocument xdoc = XDocument.Load(path);
            
            XElement Data_ = xdoc.Element("Data");
            Data obj = new Data(Data_.Element("data")?.Value);
            
            return obj;
        }

        public Data ReadTxtFile(string path)
        {
            return new Data(System.IO.File.ReadAllText(path)); 
        }
    }
}
