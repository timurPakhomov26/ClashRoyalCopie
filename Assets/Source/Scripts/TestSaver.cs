using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class TestSaver : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private List<string> _names;

    public int Count => _count;
    public List<string> Names => _names;

    private void Start()
    {
        
        Debug.Log(_count);
    }

    [ContextMenu("Save")]
    public void Save(List<Mob> actualDeck)
    {
        var json = JsonUtility.ToJson(this);
        File.WriteAllText(GetFilePath(ref actualDeck),json);
    }
    
    [ContextMenu("Load")]
    public void Load(ref List<Mob> actualDeck)
    {
        var json = File.ReadAllText(GetFilePath(ref actualDeck));
         JsonUtility.FromJsonOverwrite(json,this);
    }

    private string GetFilePath( ref List<Mob> actualDeck)
    {
        return Application.persistentDataPath + $"/{actualDeck}.so";
    }
}
