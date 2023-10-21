using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(0.01f, 0, 0);
        }
        else if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-0.01f, 0, 0);
        }       
    }
}
