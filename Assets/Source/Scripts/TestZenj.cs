using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class TestZenj : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("Hello World!");
        //  Container.Bind<Greeter>().AsSingle().NonLazy();
    }
    
}

public class Greeter
{
    public Greeter(string message)
    {
        Debug.Log(message);
    }
}
