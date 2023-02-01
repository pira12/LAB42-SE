using UnityEngine;

public class CompletedLevel : MonoBehaviour
{
    public bool completed;

    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        StateManager.instance.score += 1;
        if (!completed)
        {
            // change color of the child object called "DoorNextLevel" to red
            door.GetComponent<Collider>().enabled = false;
            door.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
