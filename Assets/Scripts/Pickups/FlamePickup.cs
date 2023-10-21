using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePickup : MonoBehaviour
{
    public float lightAddition = 0.5f;
    
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        PlayerUtil playerUtil = player.GetComponent<PlayerUtil>();
        if (playerUtil == null)
        {
            playerUtil = player.transform.parent.GetComponent<PlayerUtil>();
        }
        if (playerUtil == null)
        {
            return;
        }
        GameObject lantern = playerUtil.GetLanternObject();
        if (lantern == null || lantern.GetComponent<Lantern>() == null)
        {
            return;
        }
        lantern.GetComponent<Lantern>().AddIntensity(lightAddition);
        Destroy(this.gameObject);
    }
}
