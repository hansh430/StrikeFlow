using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static Action<Transform,bool> OnPlayerTurnChangedEvent;
}
