using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
    /* Important Types:
     * Basic:
     * int: signed integers {0, 42, -42}
     * float: signed decimals {0f, 0.42f, -0.42f}
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

    Rigidbody2D player;
    public float velocity;

    /* Start:
     * Everything here is run once, whenever the object with this script first appears.
     */

    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
    }
    
    /* Update:
     * Everything here is run once per frame of the game (starts after Start).
     */
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.velocity = velocity * Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            player.velocity = new Vector2(0, -velocity);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.velocity = velocity * Vector2.left;
            Debug.Log("Left");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            player.velocity = velocity * Vector2.right;
        }
        else
        {
            player.velocity = Vector2.zero;
        }
    }
}
