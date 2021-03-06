using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_010 : SimTemplate //* Druid of the Flame
    {
        // Choose One - Transform into a 5/2 minion; or a 2/5 minion.
        CardDB.Card fireCat52 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_010t);// 5/2 minion
        CardDB.Card fireHawk25 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_010t2);// 2/5 minion.
        CardDB.Card CatHawk55 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_044b);// 5/5 minion.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            bool hasfandral = false;
            if (p.ownMinions.Find(a => a.name == CardDB.cardName.fandralstaghelm && !a.silenced) != null) hasfandral = true;
            if (hasfandral && own.own)
            {
                p.minionTransform(own, CatHawk55);
            }
            else if (choice == 1)
            {
                p.minionTransform(own, fireCat52);
            }
            else if (choice == 2)
            {
                p.minionTransform(own, fireHawk25);
            }
        }
    }
}