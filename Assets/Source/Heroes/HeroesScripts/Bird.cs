using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class Bird : Mob
{
    private void Start()
    {
            _photonView = GetComponent<PhotonView>();
        
    }
    
    public override void Attack()
    {
       Debug.Log(_mobInfo.DamagePerSecond);
    }
    public override void Move()
    {
        base.Move();
    }
}
