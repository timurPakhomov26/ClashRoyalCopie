using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public class MobsFactory : IMobFactory
{
    private readonly string[] MobsNames =   {  "Jeday", "Rasta", "Tolstyak", "Valkiry", "Wolf", "WolfWoman","Boss","Bird"};

    private readonly List<Object> _mobs = new List<Object>();

    private readonly Queue<GameObject> _pool = new Queue<GameObject>();
    
    
    public void Load()
    {
        foreach (var mob in MobsNames)
        {
            var newMob = Resources.Load(mob);
            _mobs.Add(newMob);
        }
    }

    public IEnumerable<GameObject> CreatePool(int mobsCount,int countOfForm, Vector3 position,bool isActiveByDefolt = false)
    {
        for (int i = 0; i < mobsCount; i++)
        {
            for (int j = 0; j < countOfForm; j++)
            {
                var creatingObject = PhotonNetwork.Instantiate(_mobs[i].name, position, Quaternion.identity);
                creatingObject.gameObject.SetActive(isActiveByDefolt);
                _pool.Enqueue(creatingObject);
            }
        }

        return _pool.ToList();
    }

    public IEnumerable<Object> GetAllMobs()
    {
        return _mobs.ToList();
    }
}