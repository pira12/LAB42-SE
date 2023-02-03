/**
 * Filename: Pin.cs
 * Authors: Yoshi Fu
 * Date: January 2023
 *
 * Summary:
 * Controller for the lever gameObject.
 * Check if the controllers are collide with a box collider before allowing,
 * the user to remove the pin form the fire extinguisher.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pin : MonoBehaviour
{
    //
    // Summary:
    //     Keybind for removing the pin.
    [SerializeField]
    private InputActionReference reference = null;

    //
    // Summary:
    //     Mesh of the pin to disable (disabling gameObject disables sound).
    [SerializeField]
    private GameObject pinMesh;

    //
    // Summary:
    //     Bool to check if the pin is in the fire extinguisher.
    private bool hasPin = true;

    //
    // Summary:
    //     Bool to check if the controller is close to the pin.
    private bool inProximity = false;

    //
    // Summary:
    //     Audio fragment to play when removing pin.
    private AudioSource sound;

    //
    // Summary:
    //     On enable, monitor the action and trigger callbacks.
    private void OnEnable()
    {
        reference.action.Enable();
    }

    //
    // Summary:
    //     On trigger enter, the controller is in range of the pin.
    private void OnTriggerEnter(Collider other)
    {
        inProximity = true;
    }

    //
    // Summary:
    //     On trigger exit, the controller is out of range of the pin.
    private void OnTriggerExit(Collider other)
    {
        inProximity = false;
    }

    //
    // Summary:
    //     On start, add the RemovePin function to the action reference.
    private void Start()
    {
        // Check if an input action reference is set.
        if (reference is null)
        {
            return;
        }

        sound = GetComponent<AudioSource>();
        reference.action.performed += RemovePin;
    }

    //
    // Summary:
    //     Remove the pin from the fire extinguisher.
    private void RemovePin(InputAction.CallbackContext ctx)
    {
        // Check if there is a pin to be removed.
        if (!hasPin)
        {
            return;
        }

        // Check if the user is in range to remove the pin.
        if (gameObject.activeInHierarchy && !inProximity)
        {
            return;
        }

        // Hide the pin and its components.
        sound.Play();
        hasPin = false;
        pinMesh.SetActive(false);
    }
}
