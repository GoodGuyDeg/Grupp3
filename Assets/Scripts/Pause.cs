using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject PauseMenu;
     
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
