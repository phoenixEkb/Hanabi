using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanabi
{
    enum Color { Empty, Red, Green, Blue, Yellow, White };

    struct Card
    {
        public Color CardColor;
        public uint CardCost;

        public Card(string color, uint cost)
        {
            //if (cost > 5 || cost < 0) throw exception;
            CardCost = cost;
            switch (color)
            {
                case ("Red"): case ("R"): CardColor = Color.Red; break;
                case ("Green"): case ("G"): CardColor = Color.Green; break;
                case ("Blue"): case ("B"): CardColor = Color.Blue; break;
                case ("Yellow"): case ("Y"): CardColor = Color.Yellow; break;
                case ("White"): case ("W"): CardColor = Color.White; break;
                case ("Empty"): CardColor = Color.Empty; break;//
                default: CardColor = Color.Empty; break;//or throw some exception
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Card ex = new Card("Red", 2);
            Console.WriteLine(ex.CardColor.ToString()+" "+ex.CardCost);
        }
    }
}
