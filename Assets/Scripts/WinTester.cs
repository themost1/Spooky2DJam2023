using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTester : MonoBehaviour
{
    public float offset;

    private GhostMovement ghost;

    void Start()
    {
        ghost = GameObject.FindObjectOfType<GhostMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ghost.Block(transform.position.x - offset);
        foreach (Gate gate in GameObject.FindObjectsOfType<Gate>())
        {
            gate.Close(true); // permanently close all gates
        }
    }
}
