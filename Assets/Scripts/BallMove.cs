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

   

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        hoop = Instantiate(hoopPrefab, new Vector2(2.85f, Random.Range(-1, 2.7f)), Quaternion.identity);
    }

    void Update()
    {
        if ((Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) ||
            (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame))
        {
            Jump();
            
        }

        OutsideBounds();
        OnGoal();
    }

    void Jump()
    {
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
            Debug.Log("Collided with object: " + ballHit.collider.name + " on layer: " + LayerMask.LayerToName(ballHit.collider.gameObject.layer));
            hoop.transform.position = new Vector2(-hoop.transform.position.x, Random.Range(-1, 2.7f));
            hoop.transform.forward = -hoop.transform.forward;
            runSpeed = -runSpeed;
        }
    }

   
}
