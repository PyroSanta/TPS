using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;
    public float deathDelay;

    public PlayerProgress playerProgress;



    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }


    public bool IsAlive()
    {
        return value > 0;
    }


    public void DealDamage(float damage)
    {
        playerProgress.AddExpirience(damage);

        value -= damage;
        if(value <= 0)
        {
            EnemyDeath();
        }
        else
        {
            animator.SetTrigger("hit");
            
        }
    }

    private void EnemyDeath()
    {
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        Invoke("DeathAnimation", deathDelay);
    }

    private void DeathAnimation()
    {
        animator.SetTrigger("death");
    }
}
