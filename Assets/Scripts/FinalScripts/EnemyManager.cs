using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    /* This provides the enemy with a value to be divided, as well as checking if it can divide upon collision with a laser.
     */

    public int value;
    public GameManager gm;
    public int id;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            int projDiv = collision.gameObject.GetComponent<ProjectileManager>().divisor;
            GameObject.Destroy(collision.gameObject);
            if (value % projDiv == 0)
            {
                gm.score += projDiv;
                gm.UpdateScore();
                gm.sp.RemoveFromList(id);
            }
        }
    }
}
