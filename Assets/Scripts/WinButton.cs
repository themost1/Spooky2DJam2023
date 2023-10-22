using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButton : MonoBehaviour
{
    public string winScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(winScreen);
    }
}
