using System;
using System.Linq;
using System.Collections.Generic;

namespace PokerHandShowdown
{
     public enum PokerHand {
        HighCard,
        OnePair,
        ThreeOfAKind,
        Flush
    }
    public class CardGroup : IComparable<CardGroup> {
        public PokerHand PokerHand { get; private set; }
        public List<Card> CardList { get; private set; }
        public CardRank Rank { get; private set; }
        
        public CardGroup(PokerHand pokerHand, List<Card> cardList) {
            PokerHand = pokerHand;
            CardList = cardList;
            Rank = cardList[0].Rank;
        }
        
        public int CompareTo(CardGroup other) {
            return other.PokerHand.CompareTo(this.PokerHand);
        }
    }
};