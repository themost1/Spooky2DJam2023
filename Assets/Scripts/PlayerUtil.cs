using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
