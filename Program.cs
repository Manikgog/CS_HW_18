using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_HW_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Задание: "Скрытая передача данных"

            Вам нужно разработать программу на C#, которая позволяет скрыто передавать данные, 
            используя три разных формата сохранения: обычный текстовый файл, JSON и XML. 
            Программа должна включать следующие аспекты: основы С#, ООП, Generics, 
            работу с файлами, делегаты и события.

            Шаги для выполнения задания:

            Создайте класс "DataTransfer", который будет отвечать за скрытую передачу данных. 
            Этот класс должен содержать основную логику для передачи данных в различных форматах.

            Внутри класса "DataTransfer" создайте динамические события:

            "DataSent" - событие, возникающее при успешной передаче данных.
            "DataReceived" - событие, возникающее при успешном получении данных.
            Реализуйте методы для передачи данных в каждом из трех форматов 
            (текстовый файл, JSON и XML) внутри класса "DataTransfer". В каждом методе:

            Создайте делегат, который будет отвечать за запись и чтение данных в нужном формате.
            Используйте делегат, чтобы записать или прочитать данные из файла соответствующего формата.
            Генерируйте событие "DataSent" или "DataReceived" после успешной передачи или получения данных.
            Создайте методы в главном классе программы для демонстрации работы вашей 
            реализации скрытой передачи данных:

            Создайте экземпляр класса "DataTransfer".
            Зарегистрируйте обработчики событий "DataSent" и "DataReceived".
            Вызовите методы передачи данных в каждом из трех форматов.
            В обработчиках событий выведите соответствующие сообщения об успешной 
            передаче или получении данных.*/


            
            Data str = new Data("Hello world!");

            DataTransfer dataTransfer = new DataTransfer();
            dataTransfer.DataSent += (string s) => { Console.WriteLine(s); };
            dataTransfer.DataReceived += (string s) => { Console.WriteLine(s); };
            string path_xml_file = "C:\\Users\\Maksim\\source\\repos\\CS_HW_18\\output.xml";
            string path_json_file = "C:\\Users\\Maksim\\source\\repos\\CS_HW_18\\output.json"; 
            string path_txt_file = "C:\\Users\\Maksim\\source\\repos\\CS_HW_18\\output.txt";

            dataTransfer.WriteToXMLFile(path_xml_file, str);
            dataTransfer.WriteToJsonFile(path_json_file, str);
            dataTransfer.WriteToTxtFile(path_txt_file, str);

            Object obj = dataTransfer.ReadXMLFile(path_xml_file);
            Console.WriteLine(obj.ToString());
            Object obj1 = dataTransfer.ReadJsonFile(path_json_file);
            Console.WriteLine(obj1.ToString());

        }
    }
}
