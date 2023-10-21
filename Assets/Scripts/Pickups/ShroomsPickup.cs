using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomsPickup : MonoBehaviour
{
    private float _speedBoostTimeSecs = 3.0f;

    private void OnTriggerEnter2D(Collider2D collision)
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
        Destroy(this.gameObject);
    }
}
