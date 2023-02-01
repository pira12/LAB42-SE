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
    //     Keybind for squeezing the lever.
    [SerializeField]
    private InputActionReference reference = null;

    //
    // Summary:
    //     Reference to the pin to check if it has been removed.
    [SerializeField]
    private GameObject pinMesh;

    //
    // Summary:
    //     GameObject with the particle system.
    [SerializeField]
    private GameObject hose;

    //
    // Summary:
    //     Variable to toggle the emission of the particle system.
    private ParticleSystem.EmissionModule emission;

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

    //
    // Summary:
    //     On start, check and connect the input action reference to functions.
    private void Start()
    {
        // Check if an input action reference is set.
        if (reference is null)
        {
            return;
        }

        // Play the particle system, but disable the emission.
        ParticleSystem particleSystem = hose.GetComponent<ParticleSystem>();
        emission = particleSystem.emission;
        emission.enabled = false;
        particleSystem.Play();

        // Connect the input action reference with the functions to execute.
        reference.action.started += SqueezeLever;
        reference.action.performed += UnsqueezeLever;
        reference.action.canceled += UnsqueezeLever;
    }

    //
    // Summary:
    //     Squeeze the lever of the fire extinguisher.
    private void SqueezeLever(InputAction.CallbackContext ctx)
    {
        // Check if the pin has been removed and the user is in range.
        if (pinMesh.activeInHierarchy || !inProximity)
        {
            return;
        }

        emission.enabled = true;
        hose.SetActive(true);
    }

    //
    // Summary:
    //     Unsqueeze the lever of the fire extinguisher.
    private void UnsqueezeLever(InputAction.CallbackContext ctx)
    {
        // Check if the lever is being squeezed.
        if (!hose.activeInHierarchy) {
            return;
        }

        emission.enabled = false;
        hose.SetActive(false);
    }
}
