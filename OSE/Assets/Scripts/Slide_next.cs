using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide_next : MonoBehaviour
{
    private Slide_main WB_NEXT;
    private int current_index;

    // Start is called before the first frame update
    void Start()
    {
        // Get the current index of the array of slides.
        WB_NEXT = GameObject.FindObjectOfType<Slide_main> ();
        current_index = WB_NEXT.slide_index;
    }

    // Update is called once per frame
    public void UpdateWB_NEXT()
    {
        // Up the current_idex with one to move to the next slide.
        current_index = WB_NEXT.slide_index;
        current_index++;
        WB_NEXT.UpdateVector(current_index);
    }
}
