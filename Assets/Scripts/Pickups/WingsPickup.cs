using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsPickup : FlamePickup
{
    private float _flightTimeSecs = 3.0f;

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
        playerMovement.AddFlightTime(_flightTimeSecs);
        player.transform.parent.GetComponent<PlayerUtil>().AddPickupBar();
        base.OnTriggerEnter2D(collision);
    }
}
