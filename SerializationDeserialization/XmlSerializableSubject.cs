using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationDeserialization
{
    [Serializable]
    public class XmlSerializableSubject : Subject
    {
        public SerializableDictionary<string, int> ObjDictionary { get; set; }
        public XmlSerializableSubject()// : base()
        {
            base.Name = "";
            base.Id = new int();
            base.LettersArray = new char[8];
            base.Weight = new double();
            ObjDictionary = new SerializableDictionary<string, int>();
            //ObjDictionary = RandomDictionary();
        }
        /*
        private SerializableDictionary<int, string> RandomDictionary()
        {
            SerializableDictionary<int, string> tempDict = new SerializableDictionary<int, string>();
            Random rnd = new Random();
            int RowsCount = rnd.Next(100, 200);
            string DictVal;
            for (int i = 0; i < RowsCount; i++)
            {
                DictVal = RandomVal();
                tempDict.Add(i, DictVal);
            }
            return tempDict;
        }
        private string RandomVal()
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            Random rand = new Random();
            string word = "";
            for (int i = 0; i < 8; i++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);
                word += letters[letter_num];
            }
            return word;
        }*/
    }
}
