using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int value;
    public GameManager gm;
    public int id;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
    }

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
