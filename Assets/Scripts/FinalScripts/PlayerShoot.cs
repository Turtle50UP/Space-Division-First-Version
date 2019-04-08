using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    /* PlayerShoot:
     * This allows the player to shoot a laser corresponding to a particular divisor. The player selects the divisor with Q ard E, and then shoots with Space
     * 
     * This best demonstrates Instantiation.
     * 
     * Sound:
     * To play sound, create an AudioSource in the game connected to the sound you want to play, reference the audio source as a variable, then call the method Play on it.
     */

    public GameObject laser;
    public Vector2 offset;
    int divisor = 2;
    public GameManager gm;
    float shotTime;
    public float reloadTime;
    bool reloading;
    public AudioSource laserSound;
    // Start is called before the first frame update
    void Start()
    {
        gm.UpdateDivText(divisor);
        shotTime = Time.time - reloadTime;
        reloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - shotTime >= reloadTime)
        {
            if (reloading)
            {
                reloading = false;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject firedLaser = GameObject.Instantiate(laser);
                firedLaser.GetComponent<ProjectileManager>().divisor = divisor;
                firedLaser.transform.position = (Vector2)this.transform.position + offset;
                shotTime = Time.time;
                laserSound.Play();
                reloading = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (divisor > 2)
            {
                divisor--;
                gm.UpdateDivText(divisor);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (divisor < 10)
            {
                divisor++;
                gm.UpdateDivText(divisor);
            }
        }
    }
}
