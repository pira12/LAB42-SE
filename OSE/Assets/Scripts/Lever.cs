/**
 * Filename: Lever.cs
 * Authors: Yoshi Fu
 * Date: January 2023
 *
 * Summary:
 * Controller for the lever gameObject.
 * Check if the controllers are collide with a box collider before allowing,
 * the lever to be squeezed by the player.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    //
    // Summary:
    //     Variable to check if the lever is squeezed by the player.
    [HideInInspector]
    public bool leverSqueezed = false;

    //
    // Summary:
    //     Keybind for squeezing the lever.
    [SerializeField]
    private InputActionReference reference = null;

    //
    // Summary:
    //     Reference to the pin to check if it has been removed.
    [SerializeField]
    private GameObject pin;

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

        // Add binding for start of button hold.
        reference.action.started += SqueezeLever;

        // Add binding for release of button hold.
        reference.action.performed += UnsqueezeLever;
        reference.action.canceled += UnsqueezeLever;
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
        if (gameObject.activeInHierarchy && inProximity)
        {
            leverSqueezed = true;
        }
    }

    //
    // Summary:
    //     Unsqueeze the lever of the fire extinguisher.
    private void UnsqueezeLever(InputAction.CallbackContext ctx)
    {
        // Check if the lever is being squeezed.
        if (!leverSqueezed) {
            return;
        }

        leverSqueezed = false;
    }
}
