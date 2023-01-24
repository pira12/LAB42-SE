/**
 * Filename: Lever.cs
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

public class Lever : MonoBehaviour
{
    //
    // Summary:
    //     Keybind for squeezing the lever.
    [SerializeField]
    private InputActionReference reference = null;

    //
    // Summary:
    //     Reference to the pin to check if it has been removed.
    [SerializeField] private GameObject pin;

    //
    // Summary:
    //     Variable to check if the controller is close to the pin.
    private bool inProximity = false;

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

    private void Start()
    {
        // Check if an input action reference is set.
        if (reference is null)
        {
            return;
        }

        reference.action.performed += SqueezeLever;
    }

    //
    // Summary:
    //     Squeeze the lever of the fire extinguisher.
    private void SqueezeLever(InputAction.CallbackContext ctx)
    {
        // Check if the pin has been removed.
        if (pin.activeInHierarchy)
        {
            return;
        }

        // Check if the user is in range to squeeze the lever.
        if (gameObject.activeInHierarchy && !inProximity)
        {
            return;
        }

        // TODO: spray the content of the fire extinguisher.
        Debug.Log("Squeezing Lever...");
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
