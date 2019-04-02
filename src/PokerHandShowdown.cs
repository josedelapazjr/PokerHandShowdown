using System;
using System.Collections.Generic;

namespace PokerHandShowdown
{
    public class PokerHandShowdown {
        public static List<string> GetWinners(List<PokerPlayer> pokerPlayerList) {
            List<string> result = new List<string>();
            pokerPlayerList.Sort();
            result.Add(pokerPlayerList[0].Name);
            foreach(PokerPlayer player in pokerPlayerList[0].TiedPlayerList) {
                result.Add(player.Name);
            }
            return result;
        }
    }   
};