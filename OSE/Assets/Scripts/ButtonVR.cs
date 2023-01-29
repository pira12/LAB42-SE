using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    private Slide_main WB_NEXT;
    private int current_index;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        // Get the current index of the array of slides.
        WB_NEXT = GameObject.FindObjectOfType<Slide_main> ();
        current_index = WB_NEXT.slide_index;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.041f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.169f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void UpdateWB_NEXT()
    {
        // Up the current_idex with one to move to the next slide.
        current_index = WB_NEXT.slide_index;
        current_index++;
        WB_NEXT.UpdateVector(current_index);
    }

    public void UpdateWB_PREV()
    {
        // Up the current_idex with one to move to the next slide.
        current_index = WB_NEXT.slide_index;
        current_index--;
        WB_NEXT.UpdateVector(current_index);
    }
}
