using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int keysRequired = 1;
    public GameObject open;
    public GameObject closed;

    private void Start()
    {
        Close();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerUtil util = PlayerUtil.instance;
        if (util)
        {
            if (util.SpendKey())
            {
                Open();
            }
        }
    }

    void Open()
    {
        closed.SetActive(false);
        open.SetActive(true);
    }

    void Close()
    {
        closed.SetActive(true);
        open.SetActive(false);
    }
}
