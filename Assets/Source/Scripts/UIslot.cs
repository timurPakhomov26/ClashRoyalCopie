using System;
using ExitGames.Client.Photon.StructWrapping;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIslot : MonoBehaviour,IDropHandler
{
    public Item _itemCurrentInSlot;
    
    private void Start()
    {
        _itemCurrentInSlot = GetComponentInChildren<Item>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        var previousSlot = otherItemTransform.GetComponentInParent<UIslot>().transform;
        var currentItemTransform = GetComponentInChildren<Item>().transform;
        
        //_itemCurrentInSlot = GetComponentInChildren<Item>();
        
        otherItemTransform.SetParent(transform);
        otherItemTransform.localPosition = Vector3.zero;
        _itemCurrentInSlot = otherItemTransform.GetComponent<Item>();
        
        currentItemTransform.SetParent(previousSlot);
        currentItemTransform.localPosition = Vector3.zero;
        previousSlot.GetComponent<UIslot>()._itemCurrentInSlot = currentItemTransform.GetComponent<Item>();

        var deck = otherItemTransform.GetComponentInParent<Deck>();
        deck.ChangeDeck(GetComponentInChildren<Item>(),otherItemTransform.GetComponent<Item>());
         deck.GetOriginalDeck();


        // otherItemTransform.GetComponent<Item>().ChangeIcon();
    }

    private void Update()
    {
        //_itemCurrentInSlot = GetComponentInChildren<Item>();
    }

    
}
