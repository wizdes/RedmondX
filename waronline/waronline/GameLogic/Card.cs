using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waronline.GameLogic
{
    public enum Suit
    {
        Heart,
        Spade,
        Diamond,
        Club
    }

    public enum SpecialName
    {
        None,
        Ace,
        Jack,
        Queen,
        King
    }

    public class Card
    {
        private int value;

        public int Value 
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;

                switch (this.value)
                {
                    case 1:
                        this.SpecialName = SpecialName.Ace;
                        break;
                    case 11:
                        this.SpecialName = SpecialName.Jack;
                        break;
                    case 12:
                        this.SpecialName = SpecialName.Queen;
                        break;
                    case 13:
                        this.SpecialName = SpecialName.King;
                        break;
                    default:
                        this.SpecialName = SpecialName.None;
                        break;
                }
            }
        }

        public Suit Suit { get; set; }

        public SpecialName SpecialName { get; set; }

        public static bool operator ==(Card c1, Card c2)
        {
            return (c1.Suit == c2.Suit) && (c1.Value == c2.Value);
        }

        public static bool operator !=(Card c1, Card c2)
        {
            return (c1.Suit != c2.Suit) || (c1.Value != c2.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Card))
            {
                return false;
            }

            Card other = (Card)obj;

            return (this.Suit == other.Suit) && (this.Value == other.Value);
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            hashCode ^= this.Suit.GetHashCode();
            hashCode ^= this.Value.GetHashCode();
            return hashCode;
        }
    }
}
