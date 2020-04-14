using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationDeserialization
{
    [Serializable]
    public class Subject
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Weight { get; set; }
        public char[] LettersArray { get; set; }

        /*public Subject (string name, int id, double weight, char[]letters, Dictionary<int, string> dctnry)
        {
            Name = name;
            Id = id;
            Weight = weight;
            LettersArray = letters;
            dictionaryList = dctnry;
        }*/
        public Subject ()
        {
            Name = RandomName();
            Id = RandomId();
            Weight = RandomWeight();
            LettersArray = RandomArray();
            //ObjDictionary = RandomDictionary();
        }
        private string RandomName()
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
        }
        private int RandomId()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999);
        }
        private double RandomWeight()
        {
            Random random = new Random();
            return random.NextDouble() * (9999999.99 - 1000000.01) + 1000000.01;
        }
        private char[] RandomArray()
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] output = new char[8];
            Random rand = new Random();
            string word = "";
            for (int i = 0; i < 8; i++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);
                output[i] = letters[letter_num];
            }
            return output;
        }
    }
}
