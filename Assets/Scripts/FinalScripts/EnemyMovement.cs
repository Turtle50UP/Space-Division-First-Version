using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 velocity = Vector2.down * speed;
        this.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = Vector2.down * speed;
        this.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
