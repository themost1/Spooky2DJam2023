using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public float minFalloff = 2f;
    public float maxFalloff = 4f;
    public float lightDecayPerSec = 0.05f;
    public float startLightStrength = 1f;
    public float minIntensity = 0.2f;
    public float maxIntensity = 1.4f;
    public float maxStrength = 1f;
    public float defaultIntensity = 1f;

    private float lightStrength;
    private float flickerTime = 0f;
    private float flickerAmt = 0.3f;
    private UnityEngine.Rendering.Universal.Light2D _light;

    private float boostTime = 0f;
    private float boastAmt = 0f;

    void Start()
    {
        lightStrength = startLightStrength;
        _light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    void Update()
    {
        // you start losing light once lightStrength becomes negative
        if (flickerTime <= 0)
        {
            flickerTime = 1f;
            flickerAmt *= -1;
        }
        boostTime -= Time.deltaTime;
        flickerTime -= Time.deltaTime;
        lightStrength -= Time.deltaTime * lightDecayPerSec;
        GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity +=
            flickerAmt * Time.deltaTime;
        _light.intensity = Mathf.Max(minIntensity, lightStrength + defaultIntensity);
        _light.intensity = Mathf.Min(maxIntensity, _light.intensity);
        float calcMaxFalloff = maxFalloff;
        if (boostTime > 0)
        {
            calcMaxFalloff += boastAmt;
        }
        _light.pointLightOuterRadius =
            minFalloff + (calcMaxFalloff - minFalloff) / (Mathf.Max(1f, 1 - lightStrength));
        flickerAmt = Mathf.Min(_light.intensity * 0.3f, 0.4f) * (flickerAmt < 0 ? -1 : 1);
    }

    public void AddIntensity(float intensity)
    {
        if (lightStrength < 0)
        {
            lightStrength = 0;
        }
        lightStrength += intensity;
        if (lightStrength > maxStrength)
        {
            lightStrength = maxStrength;
        }
    }

    public void Boost(float duration, float amt)
    {
        if (boostTime < 0)
        {
            boostTime = 0f;
        }
        boostTime += duration;
        boastAmt = amt;
    }
}
