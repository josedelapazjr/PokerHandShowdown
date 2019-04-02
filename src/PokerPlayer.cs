using System;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public class PokerPlayer : IComparable<PokerPlayer> {
        public string Name { get; private set; }
        public List<CardGroup> CardGroupList { get; private set; }
        
        public PokerPlayer(string name, List<Card> cardList) {
            Name = name;
            CardGroupList = HandEvaluateTool.generateGrouping(cardList);
        }
        
               
        public int CompareTo(PokerPlayer other) {
            var length = Math.Min(this.CardGroupList.Count, other.CardGroupList.Count);
            var index = 0;
            while(index < length) {
                var cardGroup = this.CardGroupList[index];
                var otherCardGroup = other.CardGroupList[index];
                if(otherCardGroup.PokerHand != cardGroup.PokerHand) {
                    return otherCardGroup.PokerHand.CompareTo(cardGroup.PokerHand);
                }
                if(otherCardGroup.Rank != cardGroup.Rank) {
                    return otherCardGroup.Rank.CompareTo(cardGroup.Rank);
                }
                index++;
            }
            return 0;
        }
        
        public void display() {
            Console.WriteLine("{0} => {1}", Name, CardGroupList[0].PokerHand);
            foreach(CardGroup cardGroup in CardGroupList) {
                Console.Write(" {0} => {1} => ", cardGroup.PokerHand, cardGroup.Rank);
                foreach(Card card in cardGroup.CardList) {
                    Console.Write("{0}{1} ", card.Rank, card.Suit);
                }
                Console.WriteLine(""); 
            }  
        }    
    }
}