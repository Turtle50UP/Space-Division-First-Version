using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
    /* Important Types:
     * Basic:
     * int: signed integers {0, 42, -42}
     * float: signed decimals {0f, 0.42f, -0.42f}
     *      Mathematics in Unity are optimized for floats (Mathf)
     * bool: boolean (truth values) {true, false}
     * string: string of characters {"hello", " world"}
     * 
     * Other Types:
     * Vector2: 2D float vector {(42, -42)}
     *      -Can be operated directly on (multiplied, added, subtracted)
     * Vector3: 3D float vector
     * GameObject: any object within the scene
     * Input: input processing
     *      KeyCode: enum for key codes
     * Rigidbody2D: A rigid body (think physics on a solid object)
     *      -Rigidbody is for 3D physics, make sure to not confuse the two
     * 
     * Other Useful Qualities/Tips:
     * Debug: Specifically Debug.Log(), Unity's "print" (allows you to print strings to the Console)
     * this: This current script
     *      -Useful components
     *          this.transform: The current object's location, scale and rotation
     * gameObject.GetComponent<T>(): Gets the component T from the named gameObject (can be this etc.)
     */

    Rigidbody2D rigidbody2d; //rigidbody
    public float velocity; //SPEED, DUH

    /* The Unity Loop:
     * Start: Whenever an object first exists in Unity, it executes it's Start function.
     * Update: For each frame of the game, Update executes for each object with Update functions.
     */

    /* Start:
     * Everything here is run once, whenever the object with this script first appears.
     */

    void Start()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
    }
    
    /* Update:
     * Everything here is run once per frame of the game (starts after Start).
     */
    void Update()
    {
        /* Key Events:
         * Each keypress has a moment when the key is going from off to on (KeyDown), staying on (Key), and going from on to off (KeyUp).
         * These can be handled as booleans to get desired effects when a key is pressed.
         * 
         * Vectors:
         * Unity vectors are "overloaded", as in that you can do operations with them without having to do things like calling functions to add/multiply stuff with them.
         * Plus, there are multiple ways to create vectors of particular quantities, as demonstrated a little bit here.
         */
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody2d.velocity = velocity * Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigidbody2d.velocity = new Vector2(0, -velocity);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody2d.velocity = velocity * Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody2d.velocity = velocity * Vector2.right;
            //Obj rel up "this.transform.up/right/left/down"
        }
        else
        {
            rigidbody2d.velocity = Vector2.zero;
        }
    }
}
