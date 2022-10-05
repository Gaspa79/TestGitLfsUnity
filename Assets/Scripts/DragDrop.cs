using Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IInitializePotentialDragHandler
{
    /// <summary>
    /// Pixel per unit of sprite, should/will get initialized on awake
    /// </summary>
    private int PPU = 4;
    private float Scale = 0;

    private Transform myTransform;
    private SpriteRenderer _spiteRenderer;
    private float _zBeforeDrag = -1;
    private BoxCollider2D _boxCollider;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _zBeforeDrag = this.gameObject.transform.position.z;
        this.gameObject.transform.SetZ(0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        myTransform.SetXY(myTransform.position.x + (Scale * eventData.delta.x) / PPU, myTransform.position.y + (Scale * eventData.delta.y) / PPU);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // move z index to where it was beforedrag
        this.gameObject.transform.SetZ(_zBeforeDrag);
        CheckCardCollision();
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        eventData.useDragThreshold = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    private void Awake()
    {
        this.myTransform = GetComponent<Transform>();
        this.Scale =  this.myTransform.localScale.x;
        this.Scale *= (Camera.main.orthographicSize / 1080f);
        this._boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    private void CheckCardCollision()
    {
        Collider2D[] myResults = new Collider2D[10];
        var contactFilter =  new ContactFilter2D();
        contactFilter.useTriggers = true;
        int collides = _boxCollider.OverlapCollider(contactFilter, myResults);
        Debug.Log($"Collides: {collides}");
        if (collides > 0)
        {
            Debug.Log($"Collides with: {myResults[0].name}");
            var collidesWith = myResults[0].gameObject;
            var cardItCollidesWith = collidesWith.GetComponent<Card>();

            if(cardItCollidesWith!=null)
            {
                GetComponent<Card>().InteractWith(cardItCollidesWith);
            }
        }
    }
}
