using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class TimerBar : MonoBehaviour
{
    [SerializeField] private GameObject timeBar;
    [SerializeField] public int time;

    private BallMove ballMove;
    private bool isAnimating = false; // Flag to track if the bar is currently animating

    void Start()
    {
        ballMove = GetComponent<BallMove>();
        AnimateBar();
    }

    void Update()
    {
        if (ballMove != null && ballMove.changeHoop)
        {
            // Check if the bar is not currently animating before restarting the animation
            if (!isAnimating)
            {
                AnimateBar();
            }
        }
    }

    void AnimateBar()
    {
        isAnimating = true; // Set the flag to true indicating animation is in progress
        LeanTween.scaleX(timeBar, 1, time).setOnComplete(OnComplete);
    }

    void OnComplete()
    {
        isAnimating = false; // Reset the flag when animation completes
    }
}
