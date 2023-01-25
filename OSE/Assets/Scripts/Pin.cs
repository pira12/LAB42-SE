/**
 * Filename: Pin.cs
 * Authors: Yoshi Fu
 * Date: January 2023
 *
 * Summary:
 * [TODO]
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
    //     Bool to check if the controller is close to the pin.
    private bool inProximity = false;

    //
    // Summary:
    //     Bool to check if the pin is in the fire extinguisher.
    private bool hasPin = true;

    //
    // Summary:
    //     On enable, monitor the action and trigger callbacks.
    private void OnEnable()
    {
        reference.action.Enable();
    }

    //
    // Summary:
    //     On disable, stop monitoring the action and triggering callbacks.
    private void OnDisable()
    {
        reference.action.Disable();
    }

    //
    // Summary:
    //     On trigger enter, the controller is in range of the pin.
    private void OnTriggerEnter()
    {
        inProximity = true;
    }

    //
    // Summary:
    //     On trigger exit, the controller is out of range of the pin.
    private void OnTriggerExit()
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
        Debug.Log("Removing Pin...");
        gameObject.SetActive(false);
    }
}
