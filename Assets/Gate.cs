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
        UpdateKeyCount(PlayerUtil.instance.Keys);
    }

    public void UpdateKeyCount(int keys)
    {
        if (keys >= keysRequired)
        {
            Open();
        }
        else
        {
            Close();
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
