using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
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
        Destroy(this.gameObject);
    }
}
