using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDespawn : MonoBehaviour
{
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
