using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int player1Score = 0;
    public int player2Score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps GameManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(bool isPlayer1, bool isFoul)
    {
        if (isPlayer1)
        {
            player1Score++;
            Debug.Log("Player 1 Score: " + player1Score);
            EventHandler.OnPlayerScoreUpdateEvent(isPlayer1, player1Score);
        }
        else
        {
            player2Score++;
            Debug.Log("Player 2 Score: " + player2Score);
            EventHandler.OnPlayerScoreUpdateEvent(isPlayer1, player2Score);
        }
    }
}