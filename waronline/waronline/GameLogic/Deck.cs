using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waronline.GameLogic
{
    public class Deck
    {
        private List<Card> deck = new List<Card>();

        public Deck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int i = 1; i < 14; i++)
                {
                    Card newCard = new Card();
                    newCard.Value = i;
                    newCard.Suit = suit;
                    deck.Add(newCard);
                }
            }
        }

        public List<Card> Cards
        {
            get { return this.deck; }
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
        public Card GetCard(string card)
        {
            string[] split = card.Split('_');

            Suit suit;
            int value;
            if (Enum.TryParse<Suit>(split[0], out suit) && int.TryParse(split[1], out value))
            {
                return deck.Where(x => x.Suit == suit && x.Value == value).Single();
            }
            else
            {
                throw new ArgumentException(string.Format("Unrecognized format: {0}", card));
            }
        }
    }
}
