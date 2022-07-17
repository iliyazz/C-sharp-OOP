namespace P03Cards
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            
            List<Card> cards = new List<Card>();
            string[] input = Console.ReadLine().Split(", ");
            foreach (var item in input)
            {
                try
                {
                    AddCard(cards, item);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }

        public static void AddCard(List<Card> cards, string item)
        {
            List<string> validCardFaces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            Dictionary<string, string> validCardSuit = new Dictionary<string, string>()
            {
                {"S", "\u2660"},
                {"H", "\u2665"},
                {"D", "\u2666"},
                {"C", "\u2663"}
            };
            string face = item.Split()[0];
            string suit = item.Split()[1];
            if (!validCardFaces.Contains(face) || !validCardSuit.ContainsKey(suit))
            {
                throw new ArgumentException("Invalid card!");
            }

            Card card = new Card(face, validCardSuit[suit]);
            cards.Add(card);
        }

        
    }

    public class Card
    {
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
                this.Face = face;
                this.Suit = suit;
        }
        public string Face { get; set; }
        public string Suit { get; set; }
        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }
    }

}
