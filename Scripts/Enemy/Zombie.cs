using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy, IDamagable
{
    public GameObject bullet;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private float bulletSpeed = 20f;

    public int Health { get; set; }

    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    public override void Update()
    {
        base.Update();
        
        if(player != null)
        {
            if (timeBtwShots <= 0)
            {
                Attack();
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }

        }
 
    }

    //damage when bullet hits
    public override void Damage(int damage)
    {
        base.Damage(damage);
        FindObjectOfType<AudioManager>().Play("EnemyHit");
    }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Attack()
    {
        base.Attack();
        Shoot();
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, shotPoint.position, transform.rotation);
        FindObjectOfType<AudioManager>().Play("EnemyShoot");
        newBullet.GetComponent<Rigidbody2D>().velocity = (transform.right * bulletSpeed);
        Destroy(newBullet, .5f);
        timeBtwShots = startTimeBtwShots;
    }

}
