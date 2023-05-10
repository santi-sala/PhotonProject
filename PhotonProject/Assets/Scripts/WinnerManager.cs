using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinnerManager : MonoBehaviourPunCallbacks
{
    public static WinnerManager Instance { get; private set; }

       
    [SerializeField] TextMeshProUGUI _txtWinner;
    [SerializeField] Button _btnBackToLobby;

    private void Awake()
    {
        Instance = this;

        _btnBackToLobby.onClick.AddListener(() =>
        {
            PhotonNetwork.LeaveRoom();
        });
    }

    private void Start()
    {
        Hide();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(ConnectToServer.LOBBY_SCENE);

        
    }

    public void OnPlayerWon(string playerName)
    {
        Show();
        _txtWinner.text = "The winner is: " + playerName;
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
