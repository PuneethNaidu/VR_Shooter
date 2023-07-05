using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public int enemyHP = 100;
    public Slider HealthBar;
    public GameObject projectile;
    public Transform projectilePoint;
    public AudioSource source;
    public AudioClip fireSound;

    public Animator animator;
    public GameObject enemy;

    private void Update()
    {
        HealthBar.value = enemyHP;
    }
    public void Shoot()
    {
        Rigidbody rb = Instantiate(projectile, projectilePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        source.PlayOneShot(fireSound);
       
        
        rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
        rb.AddForce(transform.up * 7, ForceMode.Impulse);
        Destroy(rb, 10f);
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        Debug.Log(enemyHP);

        if (enemyHP <= 0)
        {
            //play Death Animation
            animator.SetTrigger("death");
            //enemy.SetActive(false);
           // GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            //play Damage Animation
            animator.SetTrigger("damage");
        }
    }
}
