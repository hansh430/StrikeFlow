using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikerSliderController : MonoBehaviour
{
    [SerializeField] private Slider strikerSlider;
    [SerializeField] private Transform striker;
    private void OnEnable()
    {
        EventHandler.OnPlayerTurnChangedEvent += OnPlayerTurnChange;
    }
    public void MoveStriker()
    {
        striker.position=new Vector3(strikerSlider.value, striker.position.y, 0);
    }
    private void OnPlayerTurnChange()
    {
        strikerSlider.value = 0;
    }
    private void OnDisable()
    {
        EventHandler.OnPlayerTurnChangedEvent -= OnPlayerTurnChange;
    }
}
