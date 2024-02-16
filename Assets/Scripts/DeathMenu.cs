using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
   
    public void Restart()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1;
    }

    public void Menu()

    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
