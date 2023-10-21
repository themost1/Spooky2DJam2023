using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomsPickup : FlamePickup
{
    private float _speedBoostTimeSecs = 3.0f;

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
        playerMovement.AddSpeedBoostTime(_speedBoostTimeSecs);
        player.transform.parent.GetComponent<PlayerUtil>().AddPickupBar();
        base.OnTriggerEnter2D(collision);
    }
}
