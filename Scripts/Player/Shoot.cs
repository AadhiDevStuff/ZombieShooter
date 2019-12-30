using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shoot : MonoBehaviour
{

    //shooting
    public GameObject bullet;
    public Transform shotPoint;
    [SerializeField]
    private float shotTime = .1f;
    public float bulletSpeed = 20f;

    //reloading
    public int totalBullets = 50;
    public int loadedBullets = 10;
    private bool reloaded = true;
    private int loadAmount;

    //UI
    public GameObject OutofAmmoText;
    public GameObject ReloadText;
    public Text LoadedbulletCountText;
    public Text TotalBulletCountText;

    private void Update()
    {
        LoadedbulletCountText.text = loadedBullets.ToString();
        TotalBulletCountText.text = totalBullets.ToString();
    }
    private void FixedUpdate()
    {
        //checking if gun has Bullet
        if (reloaded == true)
        {
            ShootBullet();
        }

        if(totalBullets <= 0 && loadedBullets <= 0)
        {
            OutofAmmoText.SetActive(true);
            ReloadText.SetActive(false);
            return;
        }

        Reload();
    }

    void Fire()
    {
        FindObjectOfType<AudioManager>().Play("PlayerShoot");
        GameObject newBullet = Instantiate(bullet, shotPoint.position, transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = (transform.right * bulletSpeed);
        loadedBullets--;
        Destroy(newBullet, .5f);
        if (loadedBullets <= 0)
        {
            reloaded = false;
            ReloadText.SetActive(true);
        }

    }

    //Shooting
    void ShootBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (Time.time >= shotTime)
            {
                Fire();
            }
        }
    }

    //Reloading Ammo
    void Reload()
    {
        loadAmount = 10 - loadedBullets;
        if (Input.GetKeyDown(KeyCode.R) && loadedBullets < 10 && totalBullets >= 1)
        {
            if(totalBullets >= 1 )
            {
                totalBullets -= loadAmount;
                loadedBullets += loadAmount;

                if(totalBullets < loadAmount)
                {
                    loadedBullets += totalBullets;
                    totalBullets -= totalBullets;
                }
            }

            reloaded = true;
            ReloadText.SetActive(false);
            LoadedbulletCountText.text = loadedBullets.ToString();

        }

    }

    
}
