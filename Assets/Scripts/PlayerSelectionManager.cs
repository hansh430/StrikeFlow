using UnityEngine.UI;
using UnityEngine;

public class PlayerSelectionManager : MonoBehaviour
{
    [SerializeField] private Vector2 player1Position;
    [SerializeField] private Vector2 player2Position;
    [SerializeField] private Slider player1Slider;
    [SerializeField] private Slider player2Slider;
    private void OnEnable()
    {
        EventHandler.OnPlayerTurnChangedEvent += OnPlayerTurnChange;
    }
    private void OnPlayerTurnChange(Transform strikerTransform, bool isPlayer1Turn)
    {
        if (isPlayer1Turn)
        {
            strikerTransform.position = player1Position;
            player1Slider.gameObject.SetActive(true);
            player2Slider.gameObject.SetActive(false);
            Debug.Log("Player1");
        }
        else
        {
            strikerTransform.position = player2Position;
            player1Slider.gameObject.SetActive(false);
            player2Slider.gameObject.SetActive(true);
            Debug.Log("Player2");
        }
    }
    private void OnDisable()
    {
        EventHandler.OnPlayerTurnChangedEvent -= OnPlayerTurnChange;
    }
}
