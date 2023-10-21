using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUtil : MonoBehaviour
{
    private int _keys = 0;
    public int Keys
    {
        get => _keys;
    }

    public static PlayerUtil instance;

    public GameObject pickupBar;

    private void Awake()
    {
        instance = this;
    }

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
        foreach (KeyImage key in GameObject.FindObjectsOfType<KeyImage>())
        {
            key.UpdateKeyCount(_keys);
        }
        foreach (Gate gate in GameObject.FindObjectsOfType<Gate>())
        {
            gate.UpdateKeyCount(_keys);
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
