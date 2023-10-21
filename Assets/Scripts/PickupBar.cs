using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBar : MonoBehaviour
{
    private GameObject _active;
    public float timeLeft,
        maxTime;

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Active")
            {
                _active = child.gameObject;
            }
        }
    }

    void Update()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Active")
            {
                _active = child.gameObject;
            }
        }
        timeLeft -= Time.deltaTime;
        _active.transform.localScale = new Vector3(
            timeLeft / maxTime,
            _active.transform.localScale.y,
            1
        );
        if (timeLeft < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
