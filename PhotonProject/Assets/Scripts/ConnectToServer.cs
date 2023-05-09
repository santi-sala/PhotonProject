using UnityEngine;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the server");
        // Joining a lobby
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        // Loading a scene
        PhotonNetwork.LoadLevel("Lobby");
    }

}
