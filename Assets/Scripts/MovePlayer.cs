using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    float speed = 10f;
    float rotationSpeed = 100f;
    public bool ImSafeOrange = false;
    public bool ImSafeRed = false;

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, translation, 0);
        transform.Rotate(0, 0, -rotation);


    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "orange")
        {
            ImSafeOrange = true;
            
        }
        if (other.tag == "red")
        {
            ImSafeRed = true;
        }
        if (other.tag == "Czombie" & ImSafeOrange == false || other.tag == "Bzombie" & ImSafeRed == false)
        {
            Destroy(gameObject);
        } 

    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "orange")
        {
            ImSafeOrange = false;
        }
        if (other.tag == "red")
        {
            ImSafeRed = false;
        }
    }

        

}
