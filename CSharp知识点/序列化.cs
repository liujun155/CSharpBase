using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharp知识点
{
    /**
     * 序列化是指将对象转换为可传输或存储的格式，通常为二进制或文本格式。
     * 反序列化是将存储在文件或网络中的数据，如JSON或XML格式的数据流，还原为相应的.NET对象的过程。
     * 一般利用Newtonsoft.Json包序列化json
     */

    [Serializable]
    public class SerializeEnt
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    #region JSON序列化
    public class JsonSerializeExample
    {
        public static void Run()
        {
            SerializeEnt ent = new SerializeEnt { Name = "张三", Age = 18 };

            // 序列化json
            var json = JsonConvert.SerializeObject(ent);
            Console.WriteLine($"Serialized JSON: {json}");

            // 反序列化
            var deserializedEnt = JsonConvert.DeserializeObject<SerializeEnt>(json);
            Console.WriteLine($"Deserialized JSON: Name:{deserializedEnt.Name},Age:{deserializedEnt.Age}");
        }
    }
    #endregion

    #region XML序列化
    public class XmlSerializeExample
    {
        public static void Run()
        {
            SerializeEnt ent = new SerializeEnt { Name = "李四", Age = 20 };

            // 序列化xml
            string xmlString = SerializeToXml(ent);
            Console.WriteLine($"Serialized XML:");
            Console.WriteLine(xmlString);

            // 反序列化
            var deserializedEnt = DeserializeFromXml<SerializeEnt>(xmlString);
            Console.WriteLine($"Deserialized JSON: Name:{deserializedEnt.Name},Age:{deserializedEnt.Age}");
        }

        // 将对象序列化为XML字符串
        static string SerializeToXml<T>(T obj)
        {
            // 创建XmlSerializer实例
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            // 创建StringWriter实例
            StringWriter writer = new StringWriter();
            // 使用XmlSerializer序列化对象到StringWriter
            serializer.Serialize(writer, obj);
            // 返回序列化后的XML字符串
            return writer.ToString();
        }

        static T DeserializeFromXml<T>(string xmlString)
        {
            // 创建XmlSerializer实例
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            // 创建StringReader实例
            StringReader reader = new StringReader(xmlString);
            // 使用XmlSerializer反序列化对象
            object obj = serializer.Deserialize(reader);
            // 将反序列化后的对象转换为指定类型
            return (T)obj;
        }
    }
    #endregion
}
