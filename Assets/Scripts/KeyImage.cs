using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyImage : MonoBehaviour
{
    public int index;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        UpdateKeyCount(0);
    }

    public void UpdateKeyCount(int totalKeys)
    {
        if (totalKeys >= index)
        {
            _image.color = Color.white;
        }
        else
        {
            _image.color = Color.clear;
        }
    }
}
