using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    void Start()
    {
        
        PlayGameAfter();
    }

    public void PlayGameAfter()
    {
        Invoke("Play", 2f);

    }

    void Play()
    {
        SceneManager.LoadScene("GamePlay"); 
          
    }
}
