/**
 * TeleportPlayer.cs
 * Authors: Christiaan Molier
 * Date: January 2023
 * Description: This script is used to teleport the player to a new location.
 */

using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject teleportLocation;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(teleportLocation.transform.position.x, player.transform.position.y, teleportLocation.transform.position.z);
        }

    }
}
