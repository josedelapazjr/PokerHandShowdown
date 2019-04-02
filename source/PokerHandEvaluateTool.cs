using System;
using System.Linq;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public class PokerHandEvaluateTool {
        private const int NUMBER_OF_CARDS =  5;
        private const int NUMBER_OF_CARDS_THREE_OF_A_KIND =  3;
        private const int NUMBER_OF_CARDS_PAIR =  2;
        public static List<CardGroup> generateCardGrouping(List<Card> cardList) {
            if(isValidCardList(cardList)) {
                cardList.Sort();
                var cardGroupList = isFlush(cardList) 
                    ? new List<CardGroup> { new CardGroup(PokerHand.Flush, cardList )}
                    : cardList.GroupBy(card => card.Rank).Select( group => {
                        List<Card> cardListPerGroup = group.ToList();
                        if(cardListPerGroup.Count() == NUMBER_OF_CARDS_THREE_OF_A_KIND) return new CardGroup(PokerHand.ThreeOfAKind, cardListPerGroup);
                        if(cardListPerGroup.Count() == NUMBER_OF_CARDS_PAIR) return new CardGroup(PokerHand.OnePair, cardListPerGroup);
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
    }

};