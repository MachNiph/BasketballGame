using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    void Start()
    {
        
      
    }

    public void PlayGameAfter()
    {
        Invoke("Play", 1f);

    }

    void Play()
    {
        SceneManager.LoadScene("GamePlay");
    
          
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
