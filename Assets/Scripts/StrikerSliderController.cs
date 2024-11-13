using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikerSliderController : MonoBehaviour
{
    [SerializeField] private Slider strikerSlider;
    [SerializeField] private Transform striker;
    
  
    public void MoveStriker()
    {
        striker.position=new Vector3(strikerSlider.value, striker.position.y, 0);
    }
   
}
