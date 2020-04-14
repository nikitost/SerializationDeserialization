using System;
using System.Diagnostics;

namespace SerializationDeserialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch SWatch = new Stopwatch(); //необязательное
            int objectsCount = 2000;
            Console.WriteLine("Создание списка объектов...");
            SWatch.Start();
            SerializableSubject[] ObjectForSerialisation = new SerializableSubject[objectsCount]; //стандартный объект для сериалиализации
            for (int x=0; x< objectsCount; x++)
            {
                ObjectForSerialisation[x] = new SerializableSubject();
            }
            SWatch.Stop();
            Console.WriteLine("Объекты созданы за " + SWatch.ElapsedMilliseconds + " мс");
            SWatch.Reset();
            
            Console.WriteLine("\nНАЧИНАЕТСЯ ПРОЦЕСС БИНАРНОЙ СЕРИАЛИЗАЦИИ - ДЕСЕРИАЛИЗАЦИИ");

            BinSerDeser BinaryObject = new BinSerDeser(); //объект реализующий бинарную сериализацию-десериализацию
            long BinarySrlzTime = BinaryObject.BinSerialisation(ref ObjectForSerialisation);
            Console.WriteLine("Нативная (бинарная) сериализация заняла " + BinarySrlzTime + "мс");

            SerializableSubject[] ObjectForBinDeserialisation = new SerializableSubject[objectsCount]; //объект, в который десериализуется
            long BinaryDeSrlzTime = BinaryObject.BinDeserialisation(ref ObjectForBinDeserialisation);
            Console.WriteLine("Нативная (бинарная) десериализация заняла " + BinaryDeSrlzTime + "мс");
            
            Console.WriteLine("\nНАЧИНАЕТСЯ ПРОЦЕСС XML СЕРИАЛИЗАЦИИ - ДЕСЕРИАЛИЗАЦИИ");

            //объект для сериалиализации xml, отличается доработанным словарём, потому что стандартный не сериаизуется в Xml
            XmlSerializableSubject[] ObjectForXMLSerialisation = new XmlSerializableSubject[objectsCount];
            for (int x = 0; x < objectsCount; x++)
                ObjectForXMLSerialisation[x] = new XmlSerializableSubject();

            Console.WriteLine("Подождите, нужно подготовить объект для Xml сериализации и десериализации");
            for (int j = 0; j<objectsCount; j++)
            {
                ObjectForXMLSerialisation[j].Name = ObjectForSerialisation[j].Name;
                ObjectForXMLSerialisation[j].Id = ObjectForSerialisation[j].Id;
                ObjectForXMLSerialisation[j].Weight = ObjectForSerialisation[j].Weight;
                ObjectForXMLSerialisation[j].LettersArray = ObjectForSerialisation[j].LettersArray;
                foreach (string key in ObjectForSerialisation[j].ObjDictionary.Keys)
                {
                    ObjectForXMLSerialisation[j].ObjDictionary.Add(key, ObjectForSerialisation[j].ObjDictionary[key]);
                }
            }
            Console.WriteLine("Объект готов, ждите результатов");
            
            XmlSerDeser XmlObject = new XmlSerDeser(); //объект реализующий xml сериализацию-десериализацию
            long XmlSrlzTime = XmlObject.XmlSerialisation(ref ObjectForXMLSerialisation);
            Console.WriteLine("XML сериализация заняла " + XmlSrlzTime + "мс");

            XmlSerializableSubject[] ObjectForXMLDeserialisation = new XmlSerializableSubject[objectsCount];
            long XmlDeSrlzTime = XmlObject.XmlDeserialisation(ref ObjectForXMLDeserialisation);
            Console.WriteLine("XML десериализация заняла " + XmlDeSrlzTime + "мс");
            
            Console.WriteLine("\nНАЧИНАЕТСЯ ПРОЦЕСС JSON СЕРИАЛИЗАЦИИ - ДЕСЕРИАЛИЗАЦИИ");


            JSONSerDeser JsonObject = new JSONSerDeser(); //объект реализующий json сериализацию-десериализацию
            long JsonSrlzTime = JsonObject.JsonSerialisation(ref ObjectForSerialisation);
            Console.WriteLine("JSON сериализация заняла " + JsonSrlzTime + "мс");

            SerializableSubject[] ObjectForJSONDeserialisation = new SerializableSubject[objectsCount]; //объект, в который десериализуется
            long JsonDeSrlzTime = JsonObject.JsonDeserialisation(ref ObjectForJSONDeserialisation);
            Console.WriteLine("JSON десериализация заняла " + JsonDeSrlzTime + "мс");
        }
    }
}