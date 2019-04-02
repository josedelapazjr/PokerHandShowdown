using System;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public class PokerHandShowdown {
        public List<PokerPlayer> PokerPlayerList { get; private set; }

        public PokerHandShowdown(List<PokerPlayer> pokerPlayerList) {
            PokerPlayerList = pokerPlayerList;    
        }

        public string GetWinner() {
            PokerPlayerList.Sort();
            return PokerPlayerList[0].Name;
        }
    }   
};