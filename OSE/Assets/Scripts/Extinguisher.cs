using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlusserType
{
    c02,
    metaal,
    poeder,
    schuim,
    vet
}

public class Extinguisher : MonoBehaviour
{
    [SerializeField]
    private float amountExtinguishedPerSecond = 0.3f;

    [SerializeField]
    private BlusserType type;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out RaycastHit hit, 100f) && hit.collider.TryGetComponent(out Fire fire))
        {
            // Check if the correct extinguisher is used.
            if (type == fire.type)
            {
                fire.TryExtinguish(amountExtinguishedPerSecond * Time.deltaTime);
            }
            else
            {
                StateManager.instance.correcteBrandblusserGebruikt = false;
            }
        }
    }
}
