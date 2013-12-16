using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestModel;

namespace ConsoleTest
{
    public class LinqTest
    {
        public static void Test()
        {
            List<Person> personList1 = new List<Person>(){new Person(){Id = 2,IsMale = true, Height = 178.5, Name = null}};
            List<Person> personList2 = new List<Person>() { new Person() { Id = 3, IsMale = true, Height = 178.5, Name = "Test2" } };
            var list = personList1.Union(personList2).ToArray();
            Console.WriteLine(list[0].Name);
        }
    }
}
