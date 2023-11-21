using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Object = UnityEngine.Object;

public class Deck : MonoBehaviour,IDeck
{
    [SerializeField] private GridLayoutGroup _gridLayout;
    [SerializeField] private List<Object> _mobs;

    [SerializeField] private List<ItemBase> _items;
    [SerializeField] private List<UIslot> _uIslots;

    private readonly Dictionary<ItemBase, Mob> _mobsInItems = new Dictionary<ItemBase, Mob>();
    private readonly Dictionary<ItemBase, UIslot> _currentDeck = new Dictionary<ItemBase, UIslot>();
    
    private IMobFactory _mobsFactory;
    private List<Mob> _originalMobsDeck = new List<Mob>();

    private bool _deckWasChanged = false;

    [Inject]
    private void Construct(IMobFactory mobsFactory)
    {
        _mobsFactory = mobsFactory;
    }
    

    public void Initializeinventory()
    {
        _mobs = _mobsFactory.GetAllMobs().ToList();

        SetDictionary();
        SetUIitems();
    }

    public void SetState(Transform parent)
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        gameObject.SetActive(true);
    }
    
    private void SetUIitems()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].ChangeIcon(_mobs[i].GetComponent<Mob>().MobInformation.MobSprite);
            _items[i].ChangeManaCost(_mobs[i].GetComponent<Mob>().MobInformation.ManaCost);
        }
    }

    private void SetDictionary()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _mobsInItems.Add(_items[i], _mobs[i].GetComponent<Mob>());
            _currentDeck.Add(_items[i],_uIslots[i]);
            _originalMobsDeck.Add(_mobsInItems[_items[i]]);
        }
    }

    public void ChangeDeck(ItemBase droppedItem, ItemBase currentItem)
    {
        var previousSlot = _currentDeck[droppedItem];
        var currentSlot = currentItem.GetComponentInParent<UIslot>();

        _currentDeck.Remove(droppedItem);
        _currentDeck[droppedItem] = currentSlot;
        
        _currentDeck.Remove(currentItem);
        _currentDeck[currentItem] = previousSlot;
        
        SetUIitems();
        GetRightDeck();
    }

    public IEnumerable<Mob> GetOriginalDeck() =>  _originalMobsDeck;
    
    
   private Dictionary<UIslot,ItemBase> GetItemsInSlots()
   {
       var deck = new Dictionary<UIslot, ItemBase>();
       
       foreach (var slot in _uIslots)
           deck.Add(slot,slot._itemCurrentInSlot);
       
       return deck;
   }

   private void GetRightDeck()
   {
       var dictionary = GetItemsInSlots();
       var items = new List<ItemBase>();

       foreach (var element in dictionary)
           items.Add(element.Value);

       if (_mobsInItems.Count > 0)
       {
           int j = 0;
           
           foreach (var element in _mobsInItems )
               _originalMobsDeck.Remove(_mobsInItems[items[j++]]);
       }
       
       int i = 0;
       foreach (var element in _mobsInItems )
           _originalMobsDeck.Add(_mobsInItems[items[i++]]);
       
   }
   

}
