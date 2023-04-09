using System;
using System.Text;
using System.IO;

namespace Ex6
{
    class Program
    {
        static string titles = "ID#Дата записи#Ф.И.О.#Возраст#Рост#Дата рождения#Место рождения";

        static void Main(string[] args)
        {
            if (!File.Exists(@"data.txt"))
                WriteNewLine(titles);
            else
                NextTask();

            Console.ReadKey();
        }

        static void NextTask()
        {
            Console.WriteLine("1 - отобразить содержимое файла\n2 - ввести новые данные");
            CheckKey(Console.ReadLine());
        }

        static void CheckKey(string key)
        {
            switch (key)
            {
                case "1":
                    ShowData();
                    break;
                case "2":
                    EnterData();
                    break;
                default:
                    Console.WriteLine("Неверная команда");
                    CheckKey(Console.ReadLine());
                    break;
            }
        }

        static void ShowData()
        {
            string[] text = File.ReadAllLines(@"data.txt");
            foreach (string line in text)
            {
                string[] dataInLine = line.Split('#');
                Console.WriteLine($"{dataInLine[0], 3} {dataInLine[1], 17} {dataInLine[2], 32} {dataInLine[3], 7} {dataInLine[4], 4} {dataInLine[5], 13} {dataInLine[6], 20}");
            }
            Console.WriteLine("\n");
            NextTask();
        }

        static void EnterData()
        {
            StringBuilder strB = new StringBuilder(100);
            int linesCount = 0;
            using (StreamReader sr = new StreamReader("data.txt", Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null) linesCount++;
            }

            foreach (string el in titles.Split('#'))
            {
                if (el == "ID")
                    strB.Append(linesCount.ToString());
                else
                {
                    Console.Write($"{el}: ");
                    strB.AppendFormat("{0}{1}", "#", Console.ReadLine());
                }
            }

            WriteNewLine(strB.ToString());
        }

        static void WriteNewLine(string text)
        {
            using (StreamWriter sw = new StreamWriter("data.txt", true, Encoding.UTF8))
            {
                sw.WriteLine(text);
            }
            NextTask();
        }
    }
}
