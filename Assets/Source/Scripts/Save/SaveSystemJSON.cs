using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystemJSON : MonoBehaviour
{
    [SerializeField] private  List<Mob> _mobs = new List<Mob>();
    private DataStorage _dataStorage = new DataStorage();
    private string _path;

    private void Load()
    {
        _path = Path.Combine(Application.persistentDataPath, "data.json");

        if (File.Exists(_path))
        {
            _dataStorage = JsonUtility.FromJson<DataStorage>(File.ReadAllText(_path));
            _mobs = _dataStorage.Mobs;
        }
    }

    public void Save()
    {
        var mobs = _mobs;
        _dataStorage.Mobs = mobs;
        File.WriteAllText(_path,JsonUtility.ToJson(_dataStorage));
    }
}
