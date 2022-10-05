using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cards
{
    public class ForestTree : Card
    {
        public override CardTypes CardType => CardTypes.ForestTree;

        public override void InteractWith(Card otherCard)
        {
            return;
        }
    }
}
