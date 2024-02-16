using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.SceneManagement;
using UnityEditor;

public class TimerBar : MonoBehaviour
{
   [SerializeField] private GameObject timeBar;
   private Transform timeBarTransform;
    [SerializeField] public float time; 
    [SerializeField] private BallMove ballMove;
    [SerializeField] private GameObject deathMenu;

    private bool isAnimating = false;
   

    void Start()
    {
       timeBarTransform = GetComponent<Transform>();   
        AnimateBar();
    }

    void Update()
    {

       bool canreset = ballMove.changeHoop;

        if (ballMove != null && canreset)
        {

 

            Debug.Log("joker");
            
            LeanTween.reset();
            ResetTimeBar();

            LeanTween.scaleX(timeBar, 1f, time).setOnComplete(OnComplete);
            canreset = false;

     
        }
    }

    void ResetTimeBar()
    {
        Debug.Log("milena");
        
        LeanTween.scaleX(timeBar, 0f, 0.1f);
        timeBarTransform.localScale = new Vector3(0,transform.localScale.y,transform.localScale.z);
        Debug.Log(timeBarTransform.localScale);
        
    }

    void AnimateBar()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            if(timeBar != null) 
            LeanTween.scaleX(timeBar, 1f, time)
                .setOnComplete(OnComplete);
        }
    }

    void OnComplete()
    {
      
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
