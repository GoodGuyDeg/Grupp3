using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LoadLVL1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Ändrar Sceen till Level 1/Timothy
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadLVL2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //Ändrar Sceen till Level 2/Timothy
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void LoadLVL3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3); //Ändrar Sceen till Level 3/Timothy
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void LoadStart()
    {
        SceneManager.LoadScene("StartScreene"); //Ändrar Sceen till Startscreen/Timothy
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void QuitGame()
    {
        Application.Quit(); //Avslutar Spelet/ Timothy
        Debug.Log("Quit");
    }
}
