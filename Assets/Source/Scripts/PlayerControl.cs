using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] private PhotonView _photonView;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if(_photonView.IsMine == false)
             return;
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Time.deltaTime * new Vector3(5,0,0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Time.deltaTime * new Vector3(5,0,0));
        }
    }
}
