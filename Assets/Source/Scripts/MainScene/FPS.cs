using UnityEngine;
using Zenject;

public class FPS : MonoBehaviour
{

    private void Start()
    {
        Application.targetFrameRate = 40;
    }
}
