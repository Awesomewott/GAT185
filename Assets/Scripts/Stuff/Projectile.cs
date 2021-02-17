using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [Range(0, 5)] public float lifespan = 1;
    [Range(1, 100)] public float speed = 10.0f;
    public bool destroyOnHit = false;
    public GameObject destroyFX;

   // public GameObject spawnGunParticles;
    //public AudioSource bulletColideWood;
    //public AudioSource bulletColideRock;
    //public AudioSource bulletColideHuman;
    //public AudioSource bulletColideTree;

   // public float lifetime = 5;
   // public bool useLifetime = false;

    private void Start()
    {
        //bulletColide = GetComponent<AudioSource>();
        Destroy(gameObject, lifespan);
    }

    private void OnDestroy()
    {
        if (destroyFX != null)
        {
            Instantiate(destroyFX, transform.position, transform.rotation);
        }
    }

    public void Fire(Vector3 forward)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(forward * speed, ForceMode.VelocityChange);
        //Instantiate(spawnGunParticles, transform);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (destroyOnHit)
        {
            Destroy(gameObject);
        }

    //    if (collision.gameObject.tag == "Wood")
    //    {
    //        bulletColideWood.Play();
    //    }

    //    else if (collision.gameObject.tag == "Tree")
    //    {
    //        bulletColideTree.Play();
    //    }

    //    else if (collision.gameObject.tag == "Rock")
    //    {
    //        bulletColideRock.Play();
    //    }

    //    else if (collision.gameObject.tag == "Human")
    //    {
    //        bulletColideHuman.Play();

    //    }

    }


}
