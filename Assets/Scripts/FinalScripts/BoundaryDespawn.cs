using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDespawn : MonoBehaviour
{
    /* This just ensures that objects don't move past the end of the screen. It does this by
     * checking to see if the layer the objects colliding with it are lasers (8) or enemies (10)
     */

    public GameManager gm;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            GameObject.Destroy(collision.gameObject);
        }
        else if(collision.gameObject.layer == 10)
        {
            EnemyManager em = collision.gameObject.GetComponent<EnemyManager>();
            gm.sp.RemoveFromList(em.id);
            gm.health--;
        }
    }
}
