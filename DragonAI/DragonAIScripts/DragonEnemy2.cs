using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEnemy2 : MonoBehaviour
{


    public int HP = 500;

    public Animator animator;

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            //play death Animation
            animator.SetTrigger("die");
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            //play get hit animation
            animator.SetTrigger("damage");
        }
    }
}