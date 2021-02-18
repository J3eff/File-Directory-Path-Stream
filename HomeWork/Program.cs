using System;
using System.IO;
using System.Globalization;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the path of your file: ");
            string sourcePath = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                string targetPath = Path.GetDirectoryName(sourcePath) + @"\out\summary.csv";

                Directory.CreateDirectory(Path.GetDirectoryName(targetPath));

                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach (string line in lines)
                    {
                        string[] var = line.Split(',');

                        double total = double.Parse(var[1], CultureInfo.InvariantCulture) * int.Parse(var[2]);
                        sw.WriteLine(var[0] + ", " + total.ToString("F2", CultureInfo.InvariantCulture));
                    }
                }


            }
            catch (IOException e)
            {
                Console.WriteLine("There was an error");
                Console.WriteLine(e.Message);
            }



        }
    }
}
