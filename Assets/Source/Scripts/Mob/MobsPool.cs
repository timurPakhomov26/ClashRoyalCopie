using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Zenject;

public class MobsPool : MonoBehaviourPunCallbacks
{
    public const int CountOfItems = 6;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private List<Mob> _mobs;

    private Queue<GameObject> _pool;
    private IMobFactory _mobsFactory;

    [Inject]
    private void Constructor(IMobFactory mobsFactory)
    {
        _mobsFactory = mobsFactory;
        Debug.Log(_mobsFactory);
    }
    private void Start()
    {
        _pool = new Queue<GameObject>(_mobsFactory.CreatePool(CountOfItems,3,Vector3.one));
    }
    

    private bool HasFreeElement(out GameObject element)
    {
        foreach (var mono in _pool.ToArray())
        {
            if (mono.gameObject.activeInHierarchy == false)  
            {
                if (mono.GetComponent<Mob>().MobInformation.Name != _inventory.ItemType.GetComponent<Mob>().MobInformation.Name) 
                    continue;
                
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }

    public void GetFreeElement(Vector3 position)
    {
        if (HasFreeElement(out var element))
             element.transform.position = position;
        
        /* if (AutoExpand == true)
             return CreateObject(true);*/

        //throw new System.Exception($"There is not element in pool of type{typeof(Mob)}");
    }

}
