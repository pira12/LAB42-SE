using UnityEngine;

public class Timer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        StateManager.instance.tijd += Time.deltaTime;
    }
}
