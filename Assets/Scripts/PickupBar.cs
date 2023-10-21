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
        timeLeft -= Time.deltaTime;
        _active.transform.localScale = new Vector3(
            _active.transform.localScale.x,
            timeLeft / maxTime,
            1
        );
        if (timeLeft < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
