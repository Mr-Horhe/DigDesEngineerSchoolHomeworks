using System;
using System.Reflection;

namespace MyAbstract
{
    abstract class Cat
    {
        public string name;
        public string color;

        public Cat()
        {
            name = "Barsic";
            color = "gray";
        }   
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //var temp = typeof(Cat);
            var abs = typeof(RuntimeTypeHandle).GetMethod("Allocate", BindingFlags.Static | BindingFlags.NonPublic);

            var absObj = (Cat)abs.Invoke(null, new object[] { typeof(Cat) });

            typeof(Cat).GetConstructor(Type.EmptyTypes).Invoke(absObj, new object[0]);

            Console.WriteLine(absObj.name + " is "+absObj.color+" cat");
        }
    }
}
