using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtil : MonoBehaviour
{
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
}
