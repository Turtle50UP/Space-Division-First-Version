using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* PlayerMovement:
 * Allows the player to move within the game space. However, unlike BasicPlayerMovement, we now add in diagonal movement.
 * 
 */

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed;

    /* Start:
     * Everything here is run once, whenever the object with this script first appears.
     */

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    /* Update:
     * Everything here is run once per frame of the game (starts after Start).
     */
    void Update()
    {
        /* In order to get diagonal movement, we first find the direction we want to move.
         * We do this by accumulating a velocity direction vector with components in the X and Y axes.
         */
        Vector2 appVec = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            appVec += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            appVec += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            appVec += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            appVec += Vector2.right;
        }
        /* We then take the unit vector of the direction and multiply it with the speed.
         */
        rb.velocity = appVec.normalized * speed;
    }
}
