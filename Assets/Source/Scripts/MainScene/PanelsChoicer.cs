using UnityEngine;
using Zenject;

public class PanelsChoicer : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
    private Deck _deck;

    [Inject]
    private void Constructor(Deck deck)
    {
        _deck = deck;
        Debug.Log(_deck);
    }
    
    public void SetPanel(GameObject currentPanel)
    {
        foreach (var panel in _panels)
        {
            panel.SetActive(false);

            if (panel == currentPanel)
            {
                panel.SetActive(true);
            }
        }
    }
}

