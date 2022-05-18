using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 6.0f;
    public float maxY = 10.0f;

    // Update is called once per frame
    void Update()
    {
        var y = Vector3.up;
        transform.position += y * speed * Time.deltaTime;

        if (transform.position.y > maxY)
        {
            Destroy(this.gameObject);
        }
    }
}
