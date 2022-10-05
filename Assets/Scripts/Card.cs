using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cards
{
    public abstract class Card : MonoBehaviour
    {
        public abstract CardTypes CardType { get; }

        public abstract void InteractWith(Card otherCard);

        public void PositionallyAttachTo(Card othercard)
        {
            var otherCardPosition = othercard.gameObject.transform.position;
            var newPosition = new Vector3(otherCardPosition.x, otherCardPosition.y - 75, otherCardPosition.z - 2);
            if(otherCardPosition.z < 5)
            {
                Debug.Log("Hey we have the stupid problem of reaching the camera!");
            }
            
            this.gameObject.transform.position = newPosition;
        }    
    }

    public enum CardTypes
    {
        Person = 0,
        ForestTree = 1,
    }

}
