using System;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(PhotonTransformView), 
                  typeof(PhotonView))]

[RequireComponent (typeof(Animator),
                  typeof(Rigidbody))]
public abstract class Mob : MonoBehaviour, IPunObservable
{
    [SerializeField] protected MobInfo _mobInfo;
    public MobInfo MobInformation => _mobInfo;
    [SerializeField] protected PhotonView _photonView;


    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }

    public virtual void Move()
    {
      // Debug.Log(this);
    }
    public abstract void Attack();
    public virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }
}
