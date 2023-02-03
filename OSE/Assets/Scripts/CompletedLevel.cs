/**
 * CompletedLevel.cs
 * Authors: Christiaan Molier
 * Date: January 2023
 * Description: This script is used to check if the player has completed the level. If not the door to the next level will be red and the player can't go to the next level.
 */
using UnityEngine;

public class CompletedLevel : MonoBehaviour
{

    public GameObject door;
    void Start()
    {
        if (!StateManager.instance.alarmGeactiveert || !StateManager.instance.brandGeblust || !StateManager.instance.correcteBrandblusserGebruikt)
        {
            // change color of the child object called "DoorNextLevel" to red
            //door.GetComponent<Collider>().enabled = false;
            door.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
