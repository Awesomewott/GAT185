using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    public float healthMax;
    public float decay;
    public Slider slider;
    public bool destroyOnDeath = false;
    public GameObject destroySpawnObject;
    public UnityEvent deathEvent;


    public float health { get; set; }
    public bool isDead { get; set; }

    void Start()
    {
        health = healthMax;
    }

    void Update()
    {

        if (slider != null && Game.Instance.State == Game.eState.Game)
        {
            AddHealth(-Time.deltaTime * decay);
            slider.value = health / healthMax;
        }

        if (health <= 0 && !isDead)
        {
            isDead = true;
            deathEvent?.Invoke();
            if (destroySpawnObject != null)
            {
                Instantiate(destroySpawnObject, transform.position, transform.rotation);
            }
            if (destroyOnDeath) GameObject.Destroy(gameObject);
        }
        //if (Game.Instance.State == Game.eState.Game)
        //{
        //    AddHealth(-Time.deltaTime * decay);
        //}
        //slider.value = health / healthMax;
       
    }

    public void AddHealth(float healHealth)
    {
        this.health += healHealth;
        this.health = Mathf.Clamp(this.health, 0 , healthMax);
    }
}
