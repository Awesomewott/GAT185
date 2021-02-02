using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [Range(0, 5)] public float lifespan = 1;
    [Range(1, 100)] public float speed = 10.0f;

    public GameObject spawnGunParticles;
    public AudioSource bulletColideWood;
    public AudioSource bulletColideRock;
    public AudioSource bulletColideHuman;
    public AudioSource bulletColideTree;

    public float lifetime = 5;
    public bool useLifetime = false;

    private void Start()
    {
        //bulletColide = GetComponent<AudioSource>();
        Destroy(gameObject, 2);
    }
    public void Fire(Vector3 forward)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(forward * speed, ForceMode.VelocityChange);
        Instantiate(spawnGunParticles, transform);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wood")
        {
            bulletColideWood.Play();
        }

        else if (collision.gameObject.tag == "Tree")
        {
            bulletColideTree.Play();
        }

        else if (collision.gameObject.tag == "Rock")
        {
            bulletColideRock.Play();
        }

        else if (collision.gameObject.tag == "Human")
        {
            bulletColideHuman.Play();

        }

    }


}
