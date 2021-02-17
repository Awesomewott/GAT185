using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Range(0, 3)]public float fireRate = 1.0f;

    public GameObject projectile;
    public Transform emitTransdorm;
    //private int ammo = 100;
    float fireTimer = 0;

    //public GameObject bullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           

        //    GameObject gameObject = Instantiate(this.bullet, transform.position , Quaternion.identity);
        //    gameObject.GetComponent<Bullet>().Fire(ray.direction);
          
        //}
    }

    public bool Fire(Vector3 position, Vector3 direction)
    {
        if (fireTimer >= fireRate)
        {
            fireTimer = 0;
            GameObject gameObject = Instantiate(this.projectile, position, Quaternion.identity);
            gameObject.GetComponent<Projectile>().Fire(direction);

            return true;
        }
        return false;
    }

    public bool Fire(Vector3 direction)
    {
        if (fireTimer >= fireRate)
        {
            fireTimer = 0;
            GameObject gameObject = Instantiate(this.projectile, emitTransdorm.position, emitTransdorm.rotation);
            gameObject.GetComponent<Projectile>().Fire(direction);

            return true;
        }
        return false;
    }
}
