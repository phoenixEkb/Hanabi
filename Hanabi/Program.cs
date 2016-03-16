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
                case ('W'): CardColor = Color.White; break;
                    
                default: CardColor = Color.Empty; break;//or throw some exception
            }

            CardCost = (uint)char.GetNumericValue(cardInfo[1]);
        }
        

    }

    class Deck
    {
        Queue<Card> deck;

        public Deck()
        {
            deck = new Queue<Card>();
        }

        public void addCard(Card newCard)
        {
            deck.Enqueue(newCard);//add to end
        }

        public Card getCard()
        {
            return deck.Dequeue();
            //catch if empty?
        }
    }

    class Player
    {
        List<Card> Hand;

        public Player()
        {
            Hand = new List<Card>();//can specify the size
        }

        public void Take(Card newCard)
        {
            Hand.Add(newCard);
        }

        public Card Play(int position,Card topDeck)
        {
            Card CardToPlay = Hand[position];
            Hand.RemoveAt(position);
            if (topDeck.CardCost!=0)
            Hand.Add(topDeck);
            return (CardToPlay);
        }

        //bool Tell(int[] costs)
        //{

        //}

        //bool Tell()

    }


    public class Game//TODO: Read about metaclasses in C#
    {
        uint Turns;
        uint CardsPlayed;
        uint Riscs;
        ushort ActivePlayer;
        Deck GameDeck;
        Player[] Players;

       public Game()//TODO :divide class initialization and string logics(AKA turn parser)
        {
            Turns = 0;
            CardsPlayed = 0;
            Riscs = 0;
            ActivePlayer = 1;
            GameDeck = new Deck();
            Players = new Player[2];//TODO - написать конструктор для массива плееров?
            Players[0] = new Player();
            Players[1] = new Player();
            string inputString = "Start new game with deck R1 G2 B3 W4 Y5 R1 R1 B1 B2 W1 W2 W1";//Console.ReadLine();
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
            var cards = Line.Split(' ').Skip(5).ToArray();
            for (var i = 0; i < cards.Count(); i++)
            {
                Card topDeck = new Card(cards[i]);
                if (i < 5)
                    Players[0].Take(topDeck);
                else if (i >= 5 && i < 10)//TODO check this out
                    Players[1].Take(topDeck);
                else
                    GameDeck.addCard(topDeck);
            }
        }
        
        void turnParser(string line)
        {
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game newGame = new Game();
        }
    }
}
