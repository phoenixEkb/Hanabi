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

        public Card(string cardInfo)
        {
            switch (cardInfo[0])
            {
                case ('R'): CardColor = Color.Red; break;
                case ('G'): CardColor = Color.Green; break;
                case ('B'): CardColor = Color.Blue; break;
                case ('Y'): CardColor = Color.Yellow; break;
                case ('W'):
                    CardColor = Color.White; break;
                    CardColor = Color.Empty; break;//
                default: CardColor = Color.Empty; break;//or throw some exception
            }
            CardCost =
        }
    }

    public class Game//TODO: Read about metaclasses in C#
    {
        uint Turns;
        uint CardsPlayed;
        uint Riscs;
        ushort ActivePlayer;
        Game()
        {
            Turns = 0;
            CardsPlayed = 0;
            Riscs = 0;
            ActivePlayer = 1;
            string inputString = Console.ReadLine();
            startParser(inputString);
            inputString = Console.ReadLine();
            while (inputString != null)
            {
                turnParser(inputString);
                inputString = Console.ReadLine();
            }
            Console.WriteLine("Turn: " + Turns + ", cards: " + CardsPlayed + ", with risk: " + Riscs);
        }
        void startParser(string Line)
        {
            var cards = Line.Split(' ').Skip(5);
            for (var i = 0; i < cards.Count(); i++)
            {
                if (i < 5)
                  //  FirstPlayer.addCard(Card(cards[i][1],cards[i][2]));
                else if (i < 10 && i > 5)//TODO check this out
                    //SecondPlayer.addCard(cards[i]);
                else
                    Deck.addCard(Card(cards[i]));
            }
        }
        void turnParser(string line)
        {

        }
    }

    class Deck
    {
        List<Card> deck;

        Deck()
        {
            deck = new List<Card>();
        }

        void addCard(Card newCard)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Card ex = new Card("Red", 2);
            Console.WriteLine(ex.CardColor.ToString() + " " + ex.CardCost);
        }
    }
}
