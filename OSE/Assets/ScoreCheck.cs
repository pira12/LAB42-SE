using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCheck : MonoBehaviour
    {
    private void OnTriggerEnter(Collider col)
        {
            StateManager.instance.alarmGeactiveert = true;
        }
    }