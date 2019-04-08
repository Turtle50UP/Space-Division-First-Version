using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public int divisor;
    Rigidbody2D projRB;
    float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        projRB = this.GetComponent<Rigidbody2D>();
        projRB.velocity = new Vector2(0, speed);
    }
}
