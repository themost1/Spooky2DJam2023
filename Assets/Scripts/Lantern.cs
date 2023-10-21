using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    private float flickerTime = 0f;
    private float flickerAmt = 0.3f;
    private float lightDecayPerSec = 0.05f;
    private UnityEngine.Rendering.Universal.Light2D _light;

    void Start()
    {
        _light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    void Update()
    {
        if (flickerTime <= 0)
        {
            flickerTime = 1f;
            flickerAmt *= -1;
        }
        flickerTime -= Time.deltaTime;
        GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity += flickerAmt * Time.deltaTime;
        _light.intensity = Mathf.Max(0, _light.intensity - lightDecayPerSec * Time.deltaTime);
        flickerAmt = Mathf.Min(_light.intensity * 0.3f, 0.4f) * (flickerAmt < 0 ? -1 : 1);
    }

    public void AddIntensity(float intensity)
    {
        _light.intensity += intensity;
    }
}
