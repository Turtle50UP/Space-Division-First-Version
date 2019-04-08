using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLaser : MonoBehaviour
{
    /* Destroy/Instantiate:
     * See PlayerShoot.cs for demonstration of Instantiate
     * Given a prefab (a GameObject "template"), Instantiate creates a new object as a copy of that prefab.
     * Given an object (a GameObject) that exists in the game, Destroy destroys that gameobject from the game.
     * 
     * GetComponent:
     * In order to reference other scripts/other components on a GameObject (let's call it gameObject), gameObject.GetComponent<component type>() needs to be called in order to grab that component.
     * The thing that goes in between <> is technically the type of the object that you are looking for, but for simplicity
     * just think of it as the name of the script that you are looking for on that particluar object.
     */

    private float velocity = 15f;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = velocity * Vector2.up;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            GameObject.Destroy(collision.gameObject);
            GameObject.Destroy(this.gameObject);
        }
    }
}
