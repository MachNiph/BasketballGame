using UnityEngine;
using UnityEngine.InputSystem;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D ballRb;
    private GameObject hoop;

   

    [SerializeField] private GameObject hoopPrefab;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask foodLayerMask;

    [SerializeField] private float maxRightDir;
    [SerializeField] private float maxLeftDir;


    public bool changeHoop;
    
   

    void Start()
    {
        
        Application.targetFrameRate = 60;
        ballRb = GetComponent<Rigidbody2D>();
        hoop = Instantiate(hoopPrefab, new Vector2(2.85f, Random.Range(-1, 2.7f)), Quaternion.identity);
        
    
       
    }

    void Update()
    {
        OutsideBounds();
        OnGoal();
    }

    private void FixedUpdate()
    {
        if ((Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) ||
            (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame))
        {
            Jump();

        }

    }

    void Jump()
    {
        ballRb.velocity = Vector3.zero;
        ballRb.AddForce(new Vector2(runSpeed, jumpSpeed), ForceMode2D.Impulse);
    }

    void OutsideBounds()
    {
        if (transform.position.x > maxRightDir )
        {
            transform.position = new Vector2(-(transform.position.x - 0.3f), transform.position.y);
        }
        else if(transform.position.x < maxLeftDir)
        {
            transform.position = new Vector2(-(transform.position.x + 0.3f), transform.position.y);
        }
    }

    void OnGoal()
    {
        Vector2 castOrigin = (Vector2)transform.position - Vector2.up * radius;
        RaycastHit2D ballHit = Physics2D.CircleCast(castOrigin, radius, Vector2.up, 0f, foodLayerMask);

        if (ballHit.collider != null)
        {
            changeHoop = true;
            Debug.Log("Collided with object: " + ballHit.collider.name + " on layer: " + LayerMask.LayerToName(ballHit.collider.gameObject.layer));
            hoop.transform.position = new Vector2(-hoop.transform.position.x, Random.Range(-1, 2.7f));
            hoop.transform.forward = -hoop.transform.forward;
            runSpeed = -runSpeed;
          
          
            
        }

    }

   
}
