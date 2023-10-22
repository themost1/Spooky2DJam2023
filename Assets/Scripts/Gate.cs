using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int index = 1;
    public GameObject open;
    public GameObject closed;

    private static int unlockedGates = 0;

    private bool _isPermanentlyClosed;

    private void Start()
    {
        if (unlockedGates >= index)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerUtil util = PlayerUtil.instance;
        if (util)
        {
            if (util.SpendKey())
            {
                UnlockGatesOfNum(++unlockedGates);
            }
        }
    }

    void UnlockGatesOfNum(int numUnlocked)
    {
        foreach (Gate gate in GameObject.FindObjectsOfType<Gate>())
        {
            if (gate.index <= numUnlocked)
            {
                gate.Open();
            }
        }
    }

    void Open()
    {
        if (_isPermanentlyClosed)
        {
            return;
        }
        closed.SetActive(false);
        open.SetActive(true);
    }

    public void Close(bool permanentlyClose = false)
    {
        closed.SetActive(true);
        open.SetActive(false);
        if (permanentlyClose)
        {
            _isPermanentlyClosed = permanentlyClose;
        }
    }
}
