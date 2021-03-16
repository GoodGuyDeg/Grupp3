using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    
    public void StartGame() //startgame funktion - Robin
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //byter till nästa scen - Robin
    }
}
