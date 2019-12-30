using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //movement
    [SerializeField]
    private float moveSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    
    public int health = 30;
    public Slider healthBar;
    private Shoot bullets;
    public Text HealthText;
    public GameObject GameoverText;
    public bool playerDead = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bullets = GetComponent<Shoot>();
       
    
    }

    private void Update()
    {
        healthBar.value = health;
    }

    void FixedUpdate()
    {
        Movement();
        Rotation();
        StayinBounds();
    }

    void Movement()
    {
        //Input

        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = move.normalized * moveSpeed;

        //moving
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    //Player Rotation
    void Rotation()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }

    public void Damage(int damage)
    {
        health -= damage;
        healthBar.value -= damage;
        FindObjectOfType<AudioManager>().Play("PlayerHit");
         if(health == 0)
         {
            GameoverText.SetActive(true);
            playerDead = true;
            Destroy(gameObject);
         }
    }

    void StayinBounds()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -114f, 79f), Mathf.Clamp(transform.position.y, -46.5f, 54.7f));
    }


}
