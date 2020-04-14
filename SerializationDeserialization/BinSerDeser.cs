using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;

namespace SerializationDeserialization
{
    class BinSerDeser
    {
        private long SerialisationTime;
        private long DeserialisationTime;
        Stopwatch SWatch;
        public BinSerDeser()
        {
            SWatch = new Stopwatch();
            SerialisationTime = 0;
            DeserialisationTime = 0;
        }
        public long BinSerialisation(ref SerializableSubject[] SerializableObject)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream str = new FileStream("S.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            SWatch.Start();
            formatter.Serialize(str, SerializableObject);
            SWatch.Stop();
            SerialisationTime = SWatch.ElapsedMilliseconds;
            SWatch.Reset();
            str.Close();
            return SerialisationTime;
        }
        public long BinDeserialisation(ref SerializableSubject[] DeSerializableObject)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream str = new FileStream("S.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            SWatch.Start();
            DeSerializableObject = (SerializableSubject[])formatter.Deserialize(str);
            SWatch.Stop();
            DeserialisationTime = SWatch.ElapsedMilliseconds;
            SWatch.Reset();
            str.Close();
            return DeserialisationTime;
        }
    }
}
