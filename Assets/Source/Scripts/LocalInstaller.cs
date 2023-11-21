using UnityEngine;
using Zenject;

public class LocalInstaller : MonoInstaller,IInitializable
{
   
    public override  void InstallBindings()
    {
        //BindMobFactory(); 
     
       // BindInstallerInterface();
    }
    
    private void BindMobFactory()
    {
        Container.Bind<IMobFactory>().To<MobsFactory>().AsSingle();
        Debug.Log("Bind factory in Battle");
    }

    private void BindInstallerInterface()
    {
       // Container.BindInterfacesTo<LocalInstaller>().FromInstance(this).AsSingle();
    }
    

    public void Initialize()
    {
        var mobFactory = Container.Resolve<IMobFactory>();

        mobFactory.Load();

        Debug.Log("Initialize Local");
    }
}
