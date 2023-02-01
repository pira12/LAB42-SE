using UnityEngine;

public class InitializeGlobal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the global state
        StateManager.instance.score = 0;
        StateManager.instance.score2 = 0;
        StateManager.instance.score3 = 0;
    }
}
