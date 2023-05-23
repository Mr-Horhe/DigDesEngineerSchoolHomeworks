using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;
using System.Reflection;

namespace MyExe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inpPath = "D:\\c++\\Test\\Test\\test.txt";
            string outPath = "D:\\c++\\Test\\Test\\out.txt";

            string[]inptext = File.ReadAllLines(inpPath);

            Class1 class1 = new Class1();
            var myMethod = typeof(Class1).GetMethod("myDic", BindingFlags.Instance | BindingFlags.NonPublic);
            Dictionary<string, int> myDict = (Dictionary<string, int>)myMethod.Invoke(class1, new object[] { inptext });

            using (StreamWriter writer = new StreamWriter(outPath))
            {
                foreach(var word in myDict)
                {
                    writer.WriteLine("{0}   {1}", word.Key, word.Value);
                }
            }
            Console.WriteLine("Out path: " + outPath);

            Console.ReadLine();

        }
    }
}
