using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D ballRb;
    [SerializeField] private Transform hookPos;

    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask foodLayerMask;
    public static bool moveHook = false;
    public static int score = 0;


    [SerializeField] private float maxRightDir;
    [SerializeField] private float maxLeftDir;
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) ||
           (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame))
        {
            Jump();
        }

        JumpDirection();
        OnGoal();
      
        
    }

    void Jump()
    {
        ballRb.AddForce(new Vector2(runSpeed, jumpSpeed), ForceMode2D.Impulse);
    }

    
    void JumpDirection()
    {
       if(transform.position.x > maxRightDir || transform.position.x < maxLeftDir)
        {
            transform.position = new Vector2(-(transform.position.x - 0.5f), transform.position.y);
        }
    }

    void OnGoal()
    {
        Vector2 castOrigin = (Vector2)transform.position - Vector2.up * radius ;
        RaycastHit2D ballHit = Physics2D.CircleCast(castOrigin,radius,Vector2.up, 0f,foodLayerMask);

        if(ballHit.collider !=null )
        {
            Debug.Log("Collided with object: " + ballHit.collider.name + " on layer: " + LayerMask.LayerToName(ballHit.collider.gameObject.layer));
            hookPos.position = new Vector2(-hookPos.position.x,Random.Range(-1,3));
            hookPos.forward = -hookPos.forward;
            runSpeed = -runSpeed;

        }

    }

  

   
}
