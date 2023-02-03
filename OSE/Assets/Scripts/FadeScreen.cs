/**
 * FadeScreen.cs
 * Authors: Christiaan Molier
 * Date: January 2023
 * Description: This script is used to fade the screen in and out.
 */

using System.Collections;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;

    public Color fadeColor;

    private Renderer _rend;
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<Renderer>();
        if (fadeOnStart)
            FadeIn();
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }
    
    public void FadeOut()
    {
        Fade(0, 1);
    }

    private void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    private IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            
            _rend.material.SetColor("_Color", newColor);
            
            timer += Time.deltaTime;
            yield return null;
        }
        
        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
            
        _rend.material.SetColor("_Color", newColor2);
    }
}
