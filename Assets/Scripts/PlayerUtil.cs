using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUtil : MonoBehaviour
{
    private int _keys = 0;

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
}
