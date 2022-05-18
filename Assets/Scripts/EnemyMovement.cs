using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float cost;
    public AudioClip explosion;
    public AudioClip invaderKilled;

    // Update is called once per frame
    void Update()
    {
        var y = Vector3.down;

        transform.position += y * speed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            GameManager.score -= cost;
            GameManager.AS.PlayOneShot(invaderKilled, 1f);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.AS.PlayOneShot(explosion, 1f);
            Time.timeScale = 0;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            GameManager.AS.PlayOneShot(invaderKilled, 1f);
            Destroy(collision.gameObject);
            GameManager.score += cost;
            Destroy(this.gameObject);
        }
    }
}
