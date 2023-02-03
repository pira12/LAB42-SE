using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    AudioSource sound;
    [SerializeField, Range(0f, 1.0f)] private float currentIntensity = 1.0f;
    private float [] startIntensities = new float[0];

    [SerializeField] private ParticleSystem [] fireParticleSystems = new ParticleSystem[0];

    float timeLastWatered = 0;
    [SerializeField] private float regenDelay = 2.5f;
    [SerializeField] private float regenRate = 0.1f;

    [SerializeField] public BlusserType type;

    private bool isLit = true;

    private void Start()
    {
        // Play the sound of the fire.
        sound = GetComponent<AudioSource>();
        sound.Play();
        startIntensities = new float[fireParticleSystems.Length];

        // use the set intensities for the emission rate of the fire.
        for (int i = 0; i < fireParticleSystems.Length; i++)
        {
            startIntensities[i] = fireParticleSystems[i].emission.rateOverTime.constant;
        }
    }



    private void Update()
    {
        // Check if the fire is still on and the intensity is high enough too stay on.
        if (isLit && currentIntensity < 1.0f && Time.time - timeLastWatered >= regenDelay)
        {
            currentIntensity += regenRate * Time.deltaTime;
            ChangeIntensity();
        }
    }

    public bool TryExtinguish(float amount)
    {
        timeLastWatered = Time.time;
        currentIntensity -= amount;

        ChangeIntensity();

        // The fire has stopped.
        if (currentIntensity <= 0 )
        {
            isLit = false;
            sound.Stop();
            StateManager.instance.brandGeblust = true;
            return true;
        }

        return false;
    }

    private void ChangeIntensity()
    {
        // The emission rate is linked to the intensity.
        for (int i = 0; i < fireParticleSystems.Length; i++)
        {
            var emission = fireParticleSystems[i].emission;
            emission.rateOverTime =  currentIntensity * startIntensities[i];
        }
    }
}
