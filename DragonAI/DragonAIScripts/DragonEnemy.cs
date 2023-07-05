using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonEnemy : MonoBehaviour
{
  

    private int HP = 500;
    public Slider HealthBar;

    public Animator animator;

    private void Update()
    {
        HealthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <=0)
        {
            //play death Animation
            animator.SetTrigger("die");
            //GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            //play get hit animation
            animator.SetTrigger("damage");
        }
    }
}
