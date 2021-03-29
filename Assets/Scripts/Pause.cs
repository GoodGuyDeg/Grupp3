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
            Cursor.lockState = CursorLockMode.Confined;//Sätter på musen igen - EN
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;//Stänger av musen igen - EN
    }
}
