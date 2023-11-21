using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleLobby : MonoBehaviourPunCallbacks
{
    

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        
        Debug.Log($"Enter {newPlayer.NickName}");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"Left {otherPlayer.NickName}");
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
}
