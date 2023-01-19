/**
 * Filename: HandController.cs
 * Authors: Yoshi Fu
 * Date: January 2023
 *
 * Summary:
 * Controller for a hand object.
 * Set the animation variable based on the input of the (oculus) controller.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof (ActionBasedController))]
public class HandController : MonoBehaviour
{
    ActionBasedController controller;

    [SerializeField] private Hand hand;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        hand.SetGrip(controller.selectAction.action.ReadValue<float>());
        hand.SetTrigger(controller.activateAction.action.ReadValue<float>());
    }
}
