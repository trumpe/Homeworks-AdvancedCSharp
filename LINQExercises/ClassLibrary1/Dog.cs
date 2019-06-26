using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Dog
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public int Age { get; set; }
        public Race Race { get; set; }

        public Dog(string name, Color color, int age, Race race)
        {
            Name = name;
            Color = color;
            Age = age;
            Race = race;
        }

        public override string ToString()
        {
            return $"{Name}, color: {Color}, race: {Race} ({Age} years)";
        }
    }

    public enum Race
    {
        Boxer,
        Bulldog,
        Collie,
        Dalmatian,
        Doberman,
        Mutt,
        Mudi,
        Pointer,
        Pug,
        Plott,
        Husky,
        Cocker,
        Chihuahua,
        Retriever,
        Inu,
        Mastiff
    }

    public enum Color
    {
        Brown,
        Black,
        White,
        Golden,
        Silver,
        Mix,
        Olive,
        Maroon
    }
}
