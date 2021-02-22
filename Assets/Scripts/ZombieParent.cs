using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//an abstract class is one that is not used by itself, but by its children
public abstract class ZombieParent : MonoBehaviour
{
    public string ZType; // var so subclasses of zombie can set name
    public float autoSpeed; // var so subclasses can set speed
    public GameObject player; // identify the player object


    public virtual void SetParams(string type, float speed)
    { //this takes parameters from child scripts

        ZType = type;
        autoSpeed = speed;

    }
    // Update checks to see if player is alive, if so, turns zombie toward and goes
    void Update()
    {
        if (player != null) // if the player hasn't been killed
        {
            //call the function that tells us where to turn
            CalculateAngle();
            //move the zombie in that direction
            transform.Translate(transform.up * Time.deltaTime * autoSpeed, Space.World);


        }
    }

    void CalculateAngle()
    {

        Vector3 ZForward = this.transform.up; // vector forward of zombie
        Vector3 ToPlayer = player.transform.position - this.transform.position;  // vector from zombie to player

        Debug.DrawRay(this.transform.position, ZForward * 10, Color.red, 2);
        Debug.DrawRay(this.transform.position, ToPlayer, Color.yellow, 2);

        // we need the angle between the two vectors to know where to turn - given by dot product
        // then we need to know if we should turn clockwise or counter clockwise given by the cross product
        // Signed angle does that math on the vectors and returns the angle we need

        float myAngle = Vector3.SignedAngle(ZForward, ToPlayer, transform.forward);
        this.transform.Rotate(0, 0, myAngle);
        //Debug.Log("The angle we need to turn to find player is: " + myAngle);

    }

  
}