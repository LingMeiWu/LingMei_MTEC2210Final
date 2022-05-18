using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    public LayerMask groundLayer;
    public float speed;
    public GameObject bulletPrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float xMovement = xMove * speed * Time.deltaTime;

        transform.Translate(xMovement, 0, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<Rigidbody2D>().gravityScale = 2;
    }
}
