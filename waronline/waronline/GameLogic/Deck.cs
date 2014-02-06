using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waronline.GameLogic
{
    public class Deck
    {
        private static List<Card> staticDeck = BuildDeck();
        private List<Card> deck;
        private Random random = new Random();

        public Deck()
        {
            this.deck = BuildDeck();
        }

        public List<Card> Cards
        {
            get { return this.deck; }
        }

        public Card GetRandomCard()
        {
            Card card = deck.ElementAt(random.Next() % deck.Count);

            deck.Remove(card);

            return card;
        }

        public static Card GetCardFromString(string cardString)
        {
            string[] split = cardString.Split('_');

            Suit suit;
            int value;
            SpecialName specialName;
            bool success = false;
            if (!int.TryParse(split[1], out value))
            {
                if (Enum.TryParse<SpecialName>(split[1], true, out specialName))
                {
                    success = true;
                    value = (int)specialName;
                }
            }

            if (Enum.TryParse<Suit>(split[0], out suit) && success)
            {
                return staticDeck.Where(x => x.Suit == suit && x.Value == value).SingleOrDefault();
            }
            else
            {
                throw new ArgumentException(string.Format("Unrecognized format: {0}", cardString));
            }
        }

        public Card GetCardFromDeck(Card card)
        {
            if (this.deck.Contains(card))
            {
                this.deck.Remove(card);

                return card;
            }

            throw new InvalidOperationException("Card not found in deck");
        }

        // <summary>
        // Gets a <see cref="Card"/> from its string representation.
        // </summary>
        // <param name="card">The string representation of the card</param>
        // <exception cref="ArgumentException">
        // The string representation is invalid.
        // </exception>
        // <remarks>
        // The string representation will look something like this:
        // Heart_10 or Spade_11
        // </remarks>
        public Card GetCardFromDeck(string card)
        {
            return this.GetCardFromDeck(GetCardFromString(card));
        }

        private static List<Card> BuildDeck()
        {
            List<Card> listOfCard = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int i = 1; i < 14; i++)
                {
                    Card newCard = new Card();
                    newCard.Value = i;
                    newCard.Suit = suit;
                    listOfCard.Add(newCard);
                }
            }

            return listOfCard;
        }
    }
}
