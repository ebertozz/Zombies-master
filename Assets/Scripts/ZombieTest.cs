using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTest : MonoBehaviour
{
    public float autoSpeed = 20.09f;
    public GameObject player;


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

    void CatchPlayer()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 moveTarget = player.transform.position;

            //call the function that tells us where to turn
            CalculateAngle();
            //move the zombie in that direction
            transform.Translate(transform.up * Time.deltaTime * autoSpeed, Space.World);


        }




    }
}
