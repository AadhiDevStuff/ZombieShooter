using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    protected float speed = 3f;
    protected float distanceBetweenPlayer = 4f;

    [SerializeField]
    protected int health;
    public GameObject AmmoBox;


    public virtual void Init()
    {

    }

    public virtual void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(AmmoBox, transform.position, Quaternion.identity);
        }
    }


    public virtual void Update()
    {
        if(player != null)
        {
            //distance between player and enemy
            if (Vector3.Distance(transform.position, player.position) > distanceBetweenPlayer)
            {
                MoveTowards(player.position);
            }
            RotateTowards(player.position);

        }
       
    }


    public virtual void Attack()
    {
        //specific to enemy
    }


    //movement
    private void MoveTowards(Vector2 player)
    {
        transform.position = Vector2.MoveTowards(transform.position, player, speed * Time.deltaTime);
    }



    //rotation
    private void RotateTowards(Vector2 player)
    {
        Vector2 direction = player - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle));
    }

  
}
