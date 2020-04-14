using System;
using System.Collections.Generic;

namespace SerializationDeserialization
{
    [Serializable]
    public class SerializableSubject : Subject
    {
        public Dictionary<string, int> ObjDictionary { get; set; }
        public SerializableSubject():base()
        {
            ObjDictionary = RandomDictionary();
        }
        private Dictionary<string, int> RandomDictionary()
        {
            Dictionary<string, int> tempDict = new Dictionary<string, int>();
            Random rnd = new Random();
            int RowsCount = rnd.Next(100, 200);
            string DictVal;
            for (int i = 0; i < RowsCount; i++)
            {
                DictVal = RandomVal();
                tempDict.Add(DictVal, i);
            }
            return tempDict;
        }
        private string RandomVal()
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            Random rand = new Random();
            string word = "";
            for (int i = 0; i < 20; i++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);
                word += letters[letter_num];
            }
            return word;
        }
    }
}
