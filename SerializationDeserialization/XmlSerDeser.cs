using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;

namespace SerializationDeserialization
{
    class XmlSerDeser
    {
        private long SerialisationTime;
        private long DeserialisationTime;
        Stopwatch SWatch;
        public XmlSerDeser()
        {
            SWatch = new Stopwatch();
            SerialisationTime = 0;
            DeserialisationTime = 0;
        }
        public long XmlSerialisation(ref XmlSerializableSubject[] SerializableObject)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(XmlSerializableSubject[]));
            Stream str = new FileStream("X.xml", FileMode.Create, FileAccess.Write, FileShare.None);
            SWatch.Start();
            formatter.Serialize(str, SerializableObject);
            SWatch.Stop();
            SerialisationTime = SWatch.ElapsedMilliseconds;
            SWatch.Reset();
            str.Flush();
            str.Close();
            return SerialisationTime;
        }
        public long XmlDeserialisation(ref XmlSerializableSubject[] DeSerializableObject)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(XmlSerializableSubject[]));
            Stream str = new FileStream("X.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            SWatch.Start();
            DeSerializableObject = (XmlSerializableSubject[])formatter.Deserialize(str);
            SWatch.Stop();
            DeserialisationTime = SWatch.ElapsedMilliseconds;
            SWatch.Reset();
            str.Flush();
            str.Close();
            return DeserialisationTime;
        }
    }
}