using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;
    public AudioSource source;
    public AudioClip explosion;


    private void OnCollisionEnter(Collision collision)
    {
        
        GameObject impact = Instantiate(impactEffect, transform.position, Quaternion.identity);
     
        Destroy(impact, 2);
        Destroy(gameObject);

        source.PlayOneShot(explosion);
    }
}
