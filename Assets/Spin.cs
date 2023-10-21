using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float rotationSeconds;

    // Update is called once per frame
    void Update()
    {
        Quaternion rotAmt = Quaternion.AngleAxis(Time.deltaTime * 360 / rotationSeconds, Vector3.forward);
        transform.rotation = rotAmt * transform.rotation;
    }
}
