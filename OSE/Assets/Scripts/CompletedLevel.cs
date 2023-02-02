using UnityEngine;

public class CompletedLevel : MonoBehaviour
{

    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        if (!StateManager.instance.alarmGeactiveert || !StateManager.instance.brandGeblust || !StateManager.instance.correcteBrandblusserGebruikt)
        {
            // change color of the child object called "DoorNextLevel" to red
            door.GetComponent<Collider>().enabled = false;
            door.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
