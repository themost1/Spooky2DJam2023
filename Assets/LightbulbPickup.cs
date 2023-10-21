using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightbulbPickup : FlamePickup
{
    public float lightDuration = 1f;
    public float boostAmount = 4f;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Lantern light = GameObject.FindObjectOfType<Lantern>();
        light.Boost(lightDuration, boostAmount);
        PlayerUtil.instance.AddPickupBar(lightDuration);
        base.OnTriggerEnter2D(collision);
    }
}
