using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.IO;

namespace SerializationDeserialization
{
    class JSONSerDeser
    {
        private long SerialisationTime;
        private long DeserialisationTime;
        Stopwatch SWatch;
        public JSONSerDeser()
        {
            SWatch = new Stopwatch();
            SerialisationTime = 0;
            DeserialisationTime = 0;
        }
    public long JsonSerialisation(ref SerializableSubject[] SerializableObject)
        {
            string jsonString;
            SWatch.Start();
            jsonString = JsonSerializer.Serialize(SerializableObject);
            File.WriteAllText("J.json", jsonString);
            SWatch.Stop();
            SerialisationTime = SWatch.ElapsedMilliseconds;
            SWatch.Reset();
            return SerialisationTime;
        }
        public long JsonDeserialisation(ref SerializableSubject[] DeSerializableObject)
        {
            string jsonString;
            SWatch.Start();
            jsonString = File.ReadAllText("J.json");
            DeSerializableObject = JsonSerializer.Deserialize<SerializableSubject[]>(jsonString);
            SWatch.Stop();
            DeserialisationTime = SWatch.ElapsedMilliseconds;
            SWatch.Reset();
            return DeserialisationTime;
        }
    }
}
