using UnityEngine;

public class InitializeGlobal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the global state
        StateManager.instance.alarmGeactiveert = true;
        StateManager.instance.brandGeblust = true;
        StateManager.instance.correcteBrandblusserGebruikt = true;
        StateManager.instance.tijd = 0;
    }
}
