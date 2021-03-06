﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public GameObject reticle;
    public GameObject gauge;
    public GameObject weapon;
    public float damage;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider entity)
    {
        //entity.gameObject.GetComponent<AsteroidsDesintegration>().health -= 5;
        Debug.Log(entity.gameObject.name);
        //Debug.Log(entity.gameObject.GetComponent<AsteroidsDesintegration>().health);
        //Destroy(gameObject)
        Entity temp = entity.GetComponentInParent<Entity>();
        if (temp != null)
        {
            temp.takeDammage((int)damage);
            if (reticle != null)
            {
                reticle.GetComponent<OnHitColorChange>().OnHit();
                if (weapon != null)
                {

                    if ((temp.health <= 0) && (temp.tag == "Enemy"))
                    {
                        if (weapon.name == "Dual Blasters")
                        {
                            weapon.GetComponent<DualBlastersScript>().DestroyEnemyAnimation(temp.transform);
                        }
                        if (weapon.name == "Bomb Launcher")
                        {
                            weapon.GetComponent<BombLauncherScript>().DestroyEnemyAnimation(temp.transform);
                        }
                    }
                }
            }
            if (gauge != null && temp.name != "Asteroid")
            {
                gauge.GetComponent<HealthGaugeDisplay>().DisplayHealthOnHit(temp.health, temp.maxHP, temp.name);
            }
        }

        Destroy(gameObject);
    }

    public void SetParent(GameObject _reticle, GameObject _gauge, GameObject _weapon)
    {
        reticle = _reticle;
        gauge = _gauge;
        weapon = _weapon;
    }
}
