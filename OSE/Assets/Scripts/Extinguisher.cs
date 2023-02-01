using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlusserType
{
    co2,
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
        Vector3 origin = gameObject.transform.position;
        Vector3 direction = gameObject.transform.forward;

        // Cast a ray from origin to direction and check for collision.
        if (Physics.Raycast(origin, direction, out RaycastHit hit, 100f) &&
            hit.collider.TryGetComponent(out Fire fire))
        {
            // Check if the fire extinguisher is of the right type.
            if (fire.type == type)
            {
                fire.TryExtinguish(amountExtinguishedPerSecond * Time.deltaTime);
            }
        }
    }


}
