using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public GameObject restartbutton; //referens till restartknappen - Robin
    
    void Start() //första framen på scenen - Robin
    {
        restartbutton.SetActive(false); //stänger av restartknappen - Robin
    }
    public void restartscene() //restartscene funktion - Robin
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reloadar scenen om man klickar på UI - Robin
        Cursor.lockState = CursorLockMode.Locked;
    }
}
