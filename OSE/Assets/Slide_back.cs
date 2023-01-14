using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide_back : MonoBehaviour
{
    private Slide_main WB_BACK;
    private int current_index;

    // Start is called before the first frame update
    void Start()
    {
        // Get the current index of the array of slides.
        WB_BACK = GameObject.FindObjectOfType<Slide_main> ();
        current_index = WB_BACK.slide_index;
    }

    // Update is called once per frame
    public void UpdateWB_BACK()
    {
        // Up the current_idex with one to move to the previous slide.
        current_index = WB_BACK.slide_index;
        current_index--;
        WB_BACK.UpdateVector(current_index);
    }
}