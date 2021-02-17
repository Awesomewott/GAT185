using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    public float healing = 10;
    public GameObject spawnObject;
    

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();
        if(health != null)
        {
           health.AddHealth(healing);
            if(spawnObject != null)
            {
                GameObject gameobject = Instantiate(spawnObject, transform.position, transform.rotation);
                Destroy(gameobject, 2);
            }

           Destroy(gameObject);
        }
    }
}
