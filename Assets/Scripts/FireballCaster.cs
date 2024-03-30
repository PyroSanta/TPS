using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public Fireball fireballPrefab;
    public Transform FireballSourceTransform;
    public Animator animator;
    public float damage = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var fireball = Instantiate(fireballPrefab, FireballSourceTransform.position, FireballSourceTransform.rotation);
            fireball.damage = damage;
            animator.SetTrigger("attack");
        }
    }
}
