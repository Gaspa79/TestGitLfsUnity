using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cards
{
    public class Person : Card
    {
        public override CardTypes CardType => Cards.CardTypes.Person;

        public override void InteractWith(Card otherCard)
        {
            switch (otherCard.CardType)
            {
                case CardTypes.ForestTree:
                    this.PositionallyAttachTo(otherCard);
                    break;

                default:
                    // bounce
                    break;
            }
        }
    }
}