using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Inventory : MonoBehaviour
{
    public Mob ItemType { get; private set; }
    
    [SerializeField] private Mob got; // can delete
    
    [SerializeField] private List<Mob> _mobs;
    [SerializeField] private List<ItemBase> _items;

    [SerializeField] private Image _nextMobSprite;
    
    private  Dictionary<ItemBase,Mob> _mobsInItems = new Dictionary<ItemBase, Mob>();
    
    private Deck _deck;

    [Inject]
    private void Constructor(Deck deck)
    {
        _deck = deck;
        Debug.Log(_deck);
    }

   private void OnEnable()
   {
       InputChecker.MobInField += ChangeMobs;
       InputChecker.MobInField += ChangeItems;
   }

   private void Start()
   {
       _mobs = _deck.GetOriginalDeck().ToList();
       Debug.Log(_mobs);
       Debug.Log("_mobs count in Inventory is " + _mobs.Count);
       foreach (var mob in _mobs)
       {
           Debug.Log(mob);
       }
       
       for (int i = 0; i < _items.Count; i++)
       {
           _mobsInItems.Add(_items[i],_mobs[i]);
           Debug.Log(_mobsInItems.Count);
       }

       ChangeItems();
   }

   private void OnDisable()
   {
       InputChecker.MobInField -= ChangeMobs; 
       InputChecker.MobInField -= ChangeItems;
   }

   public void OnInputItem(ItemBase item)
    {
        ItemType = _mobsInItems[item];
        got = _mobsInItems[item]; // can delete, only for inspector
    }
    
    private void ChangeMobs()
    {
        foreach (var mob in _mobs.ToList())
        {
            if (mob == ItemType)
            {
                _mobs.Remove(mob);
                _mobs.Add(mob);
            }
        }
        
        ItemType = null;
        got = null;
    }

    private void ShowNextMob()
    {
        _nextMobSprite.sprite = _mobs[_items.Count].MobInformation.MobSprite;
    }

    private void ChangeItems()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].ChangeIcon(_mobs[i].MobInformation.MobSprite);
            _items[i].ChangeManaCost(_mobs[i].MobInformation.ManaCost);
            _mobsInItems.Remove(_items[i]);
            _mobsInItems.Add(_items[i],_mobs[i]);
        }
        
        ShowNextMob();
    }

    /*public IEnumerable<Mob> GetAllMobs()
    {
        return _mobs.ToList();
    }*/
}
