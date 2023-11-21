using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller, IInitializable
{
    [SerializeField] private GameObject _deckPrefab;
    private Deck _deckContainer;

    public override  void InstallBindings()
    {
        
        BindMobFactory(); 
        BindInstallerInterface();
        BindOtherDeck();
    }

    private void BindOtherDeck()
    {
        _deckContainer = Container
                  .InstantiatePrefabForComponent<Deck>(_deckPrefab, transform.position, Quaternion.identity,null);

       // Container.Bind<Deck>().FromComponentInNewPrefab (_deckContainer).AsSingle();
       Container.Bind<Deck>().FromInstance(_deckContainer).AsSingle();
      // Container.Bind<Deck>().FromNewComponentOnNewPrefab(_deckContainer).AsSingle();
    }

    private void BindMobFactory()
    {
        Container.Bind<IMobFactory>().To<MobsFactory>().AsSingle();
        Debug.Log("Bind factory ");
    }

    private void BindInstallerInterface() => Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
    
    
    public void Initialize()
    {
        var deckParent = FindObjectOfType<DeckChanger>().transform;
        var mobFactory = Container.Resolve<IMobFactory>();

        mobFactory.Load();

        //var deck = Container.Resolve<Deck>();
        
        Debug.Log(_deckContainer + " deck in initializable");
        _deckContainer.Initializeinventory();
        _deckContainer.SetState(deckParent);
        

        Debug.Log("Initialize ");
    }
}
