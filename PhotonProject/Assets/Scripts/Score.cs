using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtScore;

    private int _score;

    private void Start()
    {
        _score = 0;
        _txtScore.text = _score.ToString() + " / 5";
    }

    public void OnRingCollected()
    {
        _score++;
        _txtScore.text = _score.ToString() + " / 5";
        if (_score >= 3)
        {
            WinnerManager.Instance.OnPlayerWon(Player.Instance.GetOwnersName());            
        }
        Debug.Log(_score);
    }
}
