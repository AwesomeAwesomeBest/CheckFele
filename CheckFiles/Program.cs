using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace CheckFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter FileReport = new StreamWriter("Result.txt", false, Encoding.UTF8);
            StreamReader startPath = new StreamReader("start_path.txt");
            FileReport.WriteLine("CN; CNL; CNE; CNEL; Проерка наличия файла");

            using (TextFieldParser tfp = new TextFieldParser("List.csv", Encoding.GetEncoding(1251)))
            {
                tfp.TextFieldType = FieldType.Delimited;
                tfp.SetDelimiters(";");
                string b = startPath.ReadLine();

                while (!tfp.EndOfData)
                {
                    string[] tfp_massive = tfp.ReadFields();
                    string a = tfp_massive[3];
                    string c = b + a;
                    FileReport.Write(tfp_massive[0] + ";" + tfp_massive[1] + ";" + tfp_massive[2] + ";" + tfp_massive[3] + ";");
                    if (File.Exists(c) == true)
                        FileReport.WriteLine("Файл на месте");
                    else
                        FileReport.WriteLine("Файл отсутствует");
                }

            }

            FileReport.Close();
        }
    }
}
