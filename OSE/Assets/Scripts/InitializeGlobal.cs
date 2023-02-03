/**
 * InitializeGlobal.cs
 * Authors: Christiaan Molier
 * Date: January 2023
 * Description: This script is used to initialize/reset the global state.
 */

using UnityEngine;



public class InitializeGlobal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the global state
        StateManager.instance.alarmGeactiveert = false;
        StateManager.instance.brandGeblust = false;
        StateManager.instance.correcteBrandblusserGebruikt = true;
        StateManager.instance.tijd = 0;
    }
}
