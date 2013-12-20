using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleTest
{
    public class SerializeTest
    {
        public static void Test()
        {
            SerializeNow();
            //DeSerializeNow();
        }

        public static void SerializeNow()
        {
            ConcreteClassToSerializeA c = new ConcreteClassToSerializeA();
            c.Name = "asdf";
            c.Age = 12;
            FileStream fileStream = new FileStream("e:\\temp1.txt", FileMode.Create);
            XmlSerializer b = new XmlSerializer(typeof(ClassToSerialize));
            b.Serialize(fileStream, c);
            fileStream.Close();
        }

        public static void DeSerializeNow()
        {
            object c = null;
            FileStream fileStream = new FileStream("e:\\temp1.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            XmlSerializer b = new XmlSerializer(typeof(ClassToSerialize));
            c = b.Deserialize(fileStream);
            Console.WriteLine(c.ToString());
            fileStream.Close();
        }
    }

    [Serializable]
    [XmlInclude(typeof(ConcreteClassToSerializeA))]
    [XmlInclude(typeof(ConcreteClassToSerializeB))]
    public class ClassToSerialize
    {
        public string Name { get; set; }
        //public bool CanExecute(string name)
        //{
        //    return string.IsNullOrEmpty(name) ? false : true;
        //}
    }

    [Serializable]
    public class ConcreteClassToSerializeA : ClassToSerialize
    {
        public int Age { get; set; }
    }

    [Serializable]
    public class ConcreteClassToSerializeB : ClassToSerialize
    {
        public string Gender { get; set; }
    }


}
