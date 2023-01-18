using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide_main : MonoBehaviour
{
    // Create an array of slides.
    public Texture[]slides;

    // Index for current slide.
    public int slide_index = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer> ().material.mainTexture= slides [slide_index];
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer> ().material.mainTexture= slides [slide_index];
    }

    public void UpdateVector (int counter) 
    {
        // Prevent the index from going out of bounds.
        counter %= slides.Length;
        // Update the index and if it goes over the max length return to 0.
        slide_index = counter;
        if (slide_index < 0) 
        {
            slide_index = slides.GetLength(0) - 1;
        }
    }
}
