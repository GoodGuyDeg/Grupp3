using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
  public void LoadLVL1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Ändrar Sceen till Level 1/Timothy
    }

    public void LoadLVL2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //Ändrar Sceen till Level 2/Timothy
    }
    public void LoadLVL3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3); //Ändrar Sceen till Level 3/Timothy
    }
    public void LoadStart()
    {
        SceneManager.LoadScene("StartScreene"); //Ändrar Sceen till Startscreen/
    }
    public void QuitGame()
    {
        Application.Quit(); //Avslutar Spelet/ Timothy
        Debug.Log("Quit");
    }
}
