using Photon.Pun;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public const float TimeForGame = 125;
    [SerializeField] private TextMeshProUGUI _timeLeftText;
    [SerializeField] private float _seconds;
    [SerializeField] private float _minutes;

    private void Start()
    {
        _minutes = (int)TimeForGame / 60;
        _seconds = (int)TimeForGame % 60;
        SetLeftTimeText();
    }

    private void Update()
    {
        if(TimeForGame > 0)
        {
            _seconds = (float) PhotonNetwork.Time;
            if (_seconds <= 0)
            {
                _seconds = 60;
                _minutes--;
            }

            SetLeftTimeText();
        }
    }

    private void SetLeftTimeText()
    {
        _timeLeftText.text = $"{(int)_minutes}:{(int)_seconds} ";
    }
}
