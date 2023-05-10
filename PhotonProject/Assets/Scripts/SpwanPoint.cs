using UnityEngine;

public class SpwanPoint : MonoBehaviour
{
    [SerializeField] private GameObject _visuals;
    // Start is called before the first frame update
    void Start()
    {
        _visuals.SetActive(false);
    }

}
