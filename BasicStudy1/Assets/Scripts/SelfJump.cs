using UnityEngine;

public class SelfJump : MonoBehaviour
{
    public Rigidbody rb;

    public float jumpForce = 5.0f;

    public bool isjumping;

    private void Start()
    {
        isjumping = false;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (isjumping == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isjumping = true;
        }
        else if (isjumping == true)
        {
            isjumping = false;
        }
    }
}
