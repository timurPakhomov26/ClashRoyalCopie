using Photon.Pun;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Lobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI _logText;
    [SerializeField] private FPS _fps;
    [SerializeField] private Camera _mainCamera;
    
    
    private void Start()
    {
        PhotonNetwork.NickName = "Player " + Random.Range(1,10202);
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster()
    {
        Log($"Connected To Master   {PhotonNetwork.NickName}");
       
    }

    public void CreateRoom()
    {
         _mainCamera.transform.rotation = new Quaternion(84,0,0,0);
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
       
    }

    public void JoinRoom()
    {
        _mainCamera.transform.rotation = new Quaternion(84,180,0,0);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Log("Connected To Room");
        
        PhotonNetwork.LoadLevel("Battle");
    }
    
    private void Log(string message)
    {
        Debug.Log(message);
        _logText.text += "/n";
        _logText.text = message;
    }
    
}
