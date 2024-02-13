using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;
    [SerializeField] ParticleSystem fallParticle;

    [Range(0, 3.2f)]
    [SerializeField] float occurAfterVelocity;

    [Range(0,0.2f)]
    [SerializeField] float dustFormPeriod;

    [SerializeField] Rigidbody2D playerRb;

    float counter;
    private bool isGrounded;

   
    void Update()
    {
        counter += Time.deltaTime;

        if(isGrounded && Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity)
        {
            if(counter > dustFormPeriod)
            {
                movementParticle.Play();
                counter = 0;
            }
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            fallParticle.Play();
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
            movementParticle.Play();
        }
           
    }
}
