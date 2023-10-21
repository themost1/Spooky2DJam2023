using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUtil : MonoBehaviour
{
    private int _keys = 0;
    public GameObject pickupBar;

    public GameObject GetLanternObject()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Lantern")
            {
                return child.gameObject;
            }
        }
        return null;
    }

    public void AddKey()
    {
        _keys++;
        GameObject keyCount = GameObject.Find("KeyTextCanvas");
        foreach (Transform child in keyCount.transform)
        {
            if (child.name == "KeyText")
            {
                child.GetComponent<TMP_Text>().text = _keys.ToString() + "/3";
            }
        }
    }

    public void AddPickupBar()
    {
        GameObject pb = Instantiate(pickupBar);
        pb.transform.position = new Vector3(
            transform.position.x,
            transform.position.y + 0.3f,
            transform.position.z
        );
        pb.GetComponent<PickupBar>().maxTime = 3;
        pb.GetComponent<PickupBar>().timeLeft = 3;
        pb.transform.parent = transform;
    }
}