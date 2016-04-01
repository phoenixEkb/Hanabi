using System;
using System.Collections;
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
            if (!IsEmpty())
                return deck.Dequeue();
            return new Card();
            //catch if empty?
        }

        public bool IsEmpty()
        {
            if (deck.Count() > 0) return false;
            return true;
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

        void RemoveCard(int position)
        {
            Hand.RemoveAt(position);
        }

        public Card Play(int position, Card topDeck)//шта эта делает? переименовать чутка
        {
            Card CardToPlay = Hand[position];
            RemoveCard(position);
            if (topDeck.CardCost != 0)//подумать
                Take(topDeck);
            return (CardToPlay);
        }

        public void Drop(int position, Card topDeck)//TODO - think about connecting this and prev method
        {
            RemoveCard(position);
            if (topDeck.CardCost != 0)
                Take(topDeck);
        }


        //public bool Tell(uint cost, int[] positions)
        //{

        //}

        //public bool Tell(string color, int[] positions)

    }

    class Board
    {
        Dictionary<Color, uint> CardsOnBoard;
        public Board()
        {
            CardsOnBoard = new Dictionary<Color, uint>();
        }

        public bool AddCard(Card CardToAdd)
        {
            if (CardToAdd.CardCost == CardsOnBoard[CardToAdd.CardColor])
            {
                CardsOnBoard[CardToAdd.CardColor] += 1;
                if (CardsOnBoard[CardToAdd.CardColor] == 5)
                {
                    CardsOnBoard[CardToAdd.CardColor] = 0;
                }
                return true;
            }
            return false;
        }

        public uint Cost()
        {
            uint SummaryCardsCost = 0;
            foreach (var Card in CardsOnBoard)
            {
                SummaryCardsCost += Card.Value;
            }
            return SummaryCardsCost;
        }
    }

    public class HanabiGame//TODO: Read about metaclasses in C#
    {
        uint Turns;
        uint CardsPlayed;
        uint Riscs;
        ushort ActivePlayerNumber, InactivePlayerNumber;//TODO: заменить на указатели, менять указатели
        Deck GameDeck;
        Player[] Players;
        Board GameBoard;
        bool GameFinished;

        public HanabiGame()//TODO :divide class initialization and string logics(AKA turn parser)
        {
            Turns = 0;
            CardsPlayed = 0;
            Riscs = 0;
            ActivePlayerNumber = 0;
            InactivePlayerNumber = 1;
            GameDeck = new Deck();
            GameBoard = new Board();
            Players = new Player[2];//TODO - написать конструктор для массива плееров?
            Players[0] = new Player();
            Players[1] = new Player();
            GameFinished = false;



            string inputString = "Start new game with deck R1 G2 B3 W4 Y5 R1 R1 B1 B2 W1 W2 W1";//Console.ReadLine();
            startParser(inputString);
            inputString = Console.ReadLine();
            
            while (!GameFinished&&inputString != null)
            {

                turnParser(inputString);
                Turns++;//если ход корректный

                var temp = ActivePlayerNumber;
                ActivePlayerNumber = InactivePlayerNumber;
                InactivePlayerNumber = temp;
                inputString = Console.ReadLine();//подумать, что делать, если игра окончена.
            }
            Console.WriteLine("Turn:{0}, cards: {1}, with risk: {2}", Turns, CardsPlayed, Riscs);//TODO - проверить корректность после переработки
        }

        void startParser(string line)
        {
            var cards = line.Split(' ').Skip(5).ToArray();
            for (var i = 0; i < cards.Count(); i++)
            {
                Card topDeck = new Card(cards[i]);
                if (i < 5)
                    Players[0].Take(topDeck);
                else if (i >= 5 && i < 10)//handsize, handsize*5
                    Players[1].Take(topDeck);
                else
                    GameDeck.addCard(topDeck);
            }
        }

        void turnParser(string line)
        {
            var action = line.Split(' ');
            switch (action[0])
            {
                case "Play":
                    {
                        //TODO:сделать проверку, а есть ли на этой позиции вообще карта. Вроде ненужно.
                        var topDeck = GameDeck.getCard();
                        var playedCard = Players[ActivePlayerNumber].Play(Int32.Parse(action[2]), topDeck);
                        //risky turn check somewhere here.
                        if (!GameBoard.AddCard(playedCard))
                            GameFinished = true;
                    }
                    break;
                case "Drop":
                    {
                        //TODO:сделать проверку, а есть ли на этой позиции вообще карта
                        var topDeck = GameDeck.getCard();
                        Players[ActivePlayerNumber].Drop(Int32.Parse(action[2]), topDeck);
                    }
                    break;

                case "Tell":
                    {
                        if (action[1] == "color")
                        {
                                
                        }
                        else
                        {

                        }
                    }
                    break;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            HanabiGame newGame = new HanabiGame();
        }
    }
}
