using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsPickup : FlamePickup
{
    public float flightDuration = 3.0f;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickedUp)
        {
            return;
        }
        GameObject player = collision.gameObject;
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement == null)
        {
            playerMovement = player.transform.parent.GetComponent<PlayerMovement>();
        }
        if (playerMovement == null)
        {
            return;
        }
        playerMovement.AddFlightTime(flightDuration);
        player.transform.parent.GetComponent<PlayerUtil>().AddPickupBar(flightDuration);
        PlayerUtil.instance.GetComponent<AudioSource>().Play(0);
        pickedUp = true;
        base.OnTriggerEnter2D(collision);
    }
}
