using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class AllMobsForDeck : MonoBehaviour
{
   [SerializeField] private List<Object> _freeMobsObjects = new List<Object>();
   [SerializeField] private List<Item> _items;
   [SerializeField] private List<UIslot> _uIslots;
   
   private readonly Dictionary<Item, Mob> _freeMobs = new Dictionary<Item, Mob>();
   private readonly Dictionary<Item,UIslot> _currentDeck = new Dictionary<Item, UIslot>();
   
   private IMobFactory _mobFactory;

   [Inject]
   private void Constructor(IMobFactory mobFactory)
   {
      _mobFactory = mobFactory;

   }

   private void Start()
   {
      var allMobs = _mobFactory.GetAllMobs().ToList();
      
       SetFreeMobs(allMobs);
       SetUIitems();
      
   }

   /*private void SetDictionary(List<Object> allMobs)
   {
      for (int i = _deck.MobsCount, j =0; i < allMobs.Count;i++,j++)
         _freeMobs.Add(_items[j],_freeMobsObjects[i].GetComponent<Mob>());
      
      Debug.Log(_freeMobs.Count);
   }*/

   private void SetFreeMobs(List<Object> allMobs)
   {
      var count = allMobs.Count - _items.Count;

      for (int i = count, j = 0; j < _items.Count; j++, i++)
      {
         _freeMobsObjects.Add(allMobs[i]);
         _currentDeck.Add(_items[j],_uIslots[j]);
      }
   }
   
   private void SetUIitems()
   {
      for (int i = 0; i < _items.Count; i++)
      {
         _items[i].ChangeIcon(_freeMobsObjects[i].GetComponent<Mob>().MobInformation.MobSprite);
         _items[i].ChangeManaCost(_freeMobsObjects[i].GetComponent<Mob>().MobInformation.ManaCost);
      }
   }

   public void ChangeDeck(Item droppedItem,Item currentItem)
   {
      var previousSlot = _currentDeck[droppedItem];
      var currentSlot = currentItem.GetComponentInParent<UIslot>();

      _currentDeck[droppedItem] = currentSlot;
      _currentDeck[currentItem] = previousSlot;
      
   }
}
