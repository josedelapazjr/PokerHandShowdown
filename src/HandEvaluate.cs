using System;
using System.Linq;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public class HandEvaluate {
        private const int NUMBER_OF_CARDS =  5;
        public static List<CardGroup> generateGrouping(List<Card> cardList) {
            if(isValidCardList(cardList)) {
                cardList.Sort();
                var cardGroupList = isFlush(cardList) 
                    ? new List<CardGroup> { new CardGroup(PokerHand.Flush, cardList )}
                    : cardList.GroupBy(card => card.Rank).Select( group => {
                        List<Card> cardListPerGroup = group.ToList();
                        if(isThreeOfAKind(cardListPerGroup)) return new CardGroup(PokerHand.ThreeOfAKind, cardListPerGroup);
                        if(isPair(cardListPerGroup)) return new CardGroup(PokerHand.OnePair, cardListPerGroup);
                        return new CardGroup(PokerHand.HighCard, cardListPerGroup);    
                }).ToList(); 
                cardGroupList.Sort();
                return cardGroupList;   
            }
            return new List<CardGroup>();
        } 

        public static bool isFlush(List<Card> cardList) {
            return cardList.GroupBy(card => card.Rank).Count() == NUMBER_OF_CARDS && cardList.GroupBy(card => card.Suit).Count() == 1;
        }
        public static bool isValidCardList(List<Card> cardList) {
            return cardList.GroupBy(card => new { card.Rank, card.Suit}).Where(group => group.Count() > 1).Count() == 0;
        }

        private static bool isThreeOfAKind(List<Card> cardList) {
            return cardList.Count() == 3;
        }

        private static bool isPair(List<Card> cardList) {
            return cardList.Count() == 2;
        }
    }

};