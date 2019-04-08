using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyCollision : MonoBehaviour
{
    /* Collision Handling:
     * Similar to key events, collisions also have states for entering a collision, maintained collisions, and then leaving the collision.
     * Instead of key event booleans, you can call the function OnCollisionEnter2D to write behaviors for when collisions occur.
     */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(collision.gameObject);
        }
    }
}
