using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    private float flickerTime = 0f;
    private float flickerAmt = 0.3f;

    void Update()
    {
        if (flickerTime <= 0)
        {
            flickerTime = 1f;
            flickerAmt *= -1;
        }
        flickerTime -= Time.deltaTime;
        GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity += flickerAmt * Time.deltaTime;
    }
}
