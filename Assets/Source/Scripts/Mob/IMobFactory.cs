using System.Collections.Generic;
using UnityEngine;

public interface IMobFactory
{
   void Load();
   IEnumerable<GameObject> CreatePool(int mobsCount,int countOfForm, Vector3 position,bool isActiveByDefolt = false);

   IEnumerable<Object> GetAllMobs();
}
