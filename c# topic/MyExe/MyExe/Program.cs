using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;
using System.Reflection;
using System.Diagnostics;

namespace MyExe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к исходному файлу");
            string inpPath = "D:\\c++\\Test\\Test\\Voina-i-Mir.txt";//Console.ReadLine(); 
            Console.WriteLine("Введите путь к выходному файлу");
            string outPath = "D:\\c++\\Test\\Test\\out.txt";
            Console.WriteLine("Введите путь к выходному файлу со временем выполнения");
            string outTimePath = outPath+"/../outTime.txt";
            
            List<string> timeList = new List<string>();
            Class1 class1 = new Class1();

            string inptext = File.ReadAllText(inpPath);

            Stopwatch stopWatch = new Stopwatch();

            var myMethod = typeof(Class1).GetMethod("myDic", BindingFlags.Instance | BindingFlags.NonPublic);
            stopWatch.Start();
            Dictionary<string, int> myDict = (Dictionary<string, int>)myMethod.Invoke(class1, new object[] { inptext });
            stopWatch.Stop();
            //Console.WriteLine(stopWatch.ElapsedMilliseconds);
            timeList.Add("Normal: "+stopWatch.ElapsedMilliseconds.ToString());
            //Stopwatch stop = new Stopwatch();
            stopWatch.Restart();
            //Writing(myDict, outPath);
            stopWatch.Start();
            var myDictParallel = class1.myDicParallel(inptext);
            stopWatch.Stop();
            timeList.Add("Parallel: " + stopWatch.ElapsedMilliseconds.ToString());
            //Console.WriteLine(stop.ElapsedMilliseconds);

            Writing(myDictParallel, outPath);

            WriteTime(timeList, outTimePath);

            Console.WriteLine("Out path: " + outPath);
            Console.WriteLine("outtime path: " + outTimePath);

            Console.ReadLine();

        }

        private static void Writing(Dictionary<string, int> sortedDic, string outPath)
        {
            using (StreamWriter writer = new StreamWriter(outPath))
            {
                foreach (var word in sortedDic)
                {
                    writer.WriteLine("{0}   {1}", word.Key, word.Value);
                }
            }
        }

        private static void WriteTime(List<string> timeList, string outPath)
        {
            using (StreamWriter writer = new StreamWriter(outPath))
            {
                foreach (var word in timeList)
                {
                    writer.WriteLine(word);
                }
            }
        }
    }
}
