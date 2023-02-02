using UnityEngine;

public class InitializeGlobal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the global state
        StateManager.instance.alarmGeactiveert = false;
        StateManager.instance.brandGeblust = false;
        StateManager.instance.correcteBrandblusserGebruikt = false;
        StateManager.instance.tijd = 0;
    }
}
