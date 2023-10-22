using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomsPickup : FlamePickup
{
    public float speedBoostDuration = 3.0f;

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
        playerMovement.AddSpeedBoostTime(speedBoostDuration);
        player.transform.parent.GetComponent<PlayerUtil>().AddPickupBar(speedBoostDuration);
        PlayerUtil.instance.GetComponent<AudioSource>().Play(0);
        pickedUp = true;
        base.OnTriggerEnter2D(collision);
    }
}
