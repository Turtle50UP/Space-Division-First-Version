using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    /* ProjectileManager:
     * This is used to contain some useful information on constants used by the projectile. I separated this from the projectile behavior for cleaner code.
     */

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
