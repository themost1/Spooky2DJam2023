using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsPickup : FlamePickup
{
    public float flightDuration = 3.0f;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
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
        base.OnTriggerEnter2D(collision);
    }
}
