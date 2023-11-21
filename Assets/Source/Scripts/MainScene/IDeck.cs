using System.Collections.Generic;
using UnityEngine;

public interface IDeck
{
    public void ChangeDeck(ItemBase droppedItem,ItemBase currentItem);
    void Initializeinventory();
    void SetState(Transform parent);
    IEnumerable<Mob> GetOriginalDeck();
}
