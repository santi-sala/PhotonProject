using UnityEngine;
using Photon.Pun;
using System;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }
    
    [SerializeField] GameObject _playerPrefab;
    private SpwanPoint[] _spawnPointList;
    private Transform _spawn;

    private void Awake()
    {
        Instance = this;
        _spawnPointList = GetComponentsInChildren<SpwanPoint>();
        _spawn = GetSpawnPoint();
    }

    public Transform GetSpawnPoint()
    {
        return _spawnPointList[UnityEngine.Random.Range(0, _spawnPointList.Length)].transform;
            
    }

    void Start()
    {
        
        Debug.Log("X: " + _spawn.position.x.ToString() +"\n" + "Y: " + _spawn.position.y.ToString() + "\n" + "Z: " + _spawn.position.z.ToString() + "\n");
        PhotonNetwork.Instantiate(_playerPrefab.name, _spawn.position, _spawn.rotation);
    }

}
