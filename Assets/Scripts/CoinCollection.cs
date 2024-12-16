using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private bool isFoul=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.UpdateScore(Striker.isPlayer1Turn,isFoul);  // Access updated score tracking
        }
        if (collision.gameObject.CompareTag("Striker"))
        {
            isFoul = true;
            GameManager.Instance.UpdateScore(Striker.isPlayer1Turn, isFoul);
            isFoul=false;
        }
    }
}
