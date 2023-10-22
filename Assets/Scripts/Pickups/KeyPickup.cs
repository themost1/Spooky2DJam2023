using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : FlamePickup
{
    protected override void OnTriggerEnter2D(Collider2D collision)
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
        playerUtil.AddKey();
        playerUtil.GetComponent<AudioSource>().Play(0);
        base.OnTriggerEnter2D(collision);
    }
}
