using UnityEngine;
using Photon.Pun;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] private TMP_Text _txtPLayerName;

    public string _playerName;

    private void Awake()
    {
        Instance = this;
    }
    //private int _score;
    void Start()
    {
        _playerName = GetComponent<PhotonView>().Owner.NickName;
        _txtPLayerName.text = _playerName;
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.position = SpawnManager.Instance.GetSpawnPoint().position;
        transform.rotation = SpawnManager.Instance.GetSpawnPoint().rotation;
    }

    public string GetOwnersName()
    {
        return _playerName;
    }

}
