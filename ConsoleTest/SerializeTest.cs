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
        //http://stackoverflow.com/questions/3167932/c-sharp-wcf-when-is-it-appropriate-to-use-the-knowntype-attribute
        public static void Test()
        {
            //SerializeNow();
            DeSerializeNow();
        }

        public static void SerializeNow()
        {
            ConcreteClassToSerialize c = new ConcreteClassToSerialize();
            c.Name = "123";
            FileStream fileStream = new FileStream("e:\\temp5.txt", FileMode.Create);
            DataContractSerializer b = new DataContractSerializer(typeof(ConcreteClassToSerialize));
            b.WriteObject(fileStream, c);
            fileStream.Close();
        }

        public static void DeSerializeNow()
        {
            object c = null;
            FileStream fileStream = new FileStream("e:\\temp5.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            DataContractSerializer b = new DataContractSerializer(typeof(ClassToSerialize));
            fileStream.Seek(0, SeekOrigin.Begin);
            c = b.ReadObject(fileStream);
            Console.WriteLine(c.ToString());
            fileStream.Close();
        }
    }

    //[Serializable]
    [DataContract]
    [KnownType(typeof(ConcreteClassToSerialize))]
    public class ClassToSerialize
    {
        //public int id = 100;
        //public string name = "Name";
        //public string Sex = "男";

        [DataMember]
        public string Name { get; set; }
    }

    //[Serializable]
    [DataContract]
    public class ConcreteClassToSerialize : ClassToSerialize
    {
        [DataMember]
        //public int age = 90;
        public int Age { get; set; }
    }


}
