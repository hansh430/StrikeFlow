using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text player1Score;
    [SerializeField] private TMP_Text player2Score;
    private void OnEnable()
    {
        EventHandler.OnPlayerScoreUpdateEvent += UpdatePlayerScore;
    }
    private void UpdatePlayerScore(bool isPlayer1,int score)
    {
        if(isPlayer1)
        {
            player1Score.text=score.ToString();
        }
        else
        {
            player2Score.text=score.ToString(); 
        }
    }
    private void OnDisable()
    {
        EventHandler.OnPlayerScoreUpdateEvent -= UpdatePlayerScore;
    }
}
