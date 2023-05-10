using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public const string GAME_SCENE = "Game";

    [SerializeField] private Button _btnJoinRoom;
    [SerializeField] private Button _btnCreateRoom;
    [SerializeField] private Button _btnQuit;
    [SerializeField] private TMP_InputField _intputFieldPlayerName;

    private void Awake()
    {
        _btnJoinRoom.onClick.AddListener(() =>
        {
            if (_intputFieldPlayerName.text.Length < 1)
            {
                return;
            }
            JoinRoom();
        });

        _btnCreateRoom.onClick.AddListener(() =>
        {
            CreateRoom();
        });

        _btnQuit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    private void JoinRoom()
    {
        // This will try to join the room
        PhotonNetwork.NickName = _intputFieldPlayerName.text;
        PhotonNetwork.JoinRandomRoom();
    }

    public void CreateRoom()
    {
        // If there is no room to join it will create one
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // If there is no room to join it will create one
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2} );
    }

    public override void OnJoinedRoom()
    {
        // Joining a room but loading the scene
        PhotonNetwork.LoadLevel(GAME_SCENE);
    }
}
