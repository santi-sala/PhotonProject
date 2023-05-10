using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private Material _materialOrange;
    [SerializeField] private Material _materialBlue;

    private bool _ringIsTriggered = false;
    void Start()
    {
        GetComponent<MeshRenderer>().material = _materialOrange;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!_ringIsTriggered)
        {
            _ringIsTriggered = true;
            GetComponent<MeshRenderer>().material = _materialBlue;
            other.GetComponent<Score>().OnRingCollected();
        }
    }

    
}
