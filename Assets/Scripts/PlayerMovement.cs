using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    Rigidbody2D myRigidBody;
    CapsuleCollider2D myBodyCollider2D;
    BoxCollider2D myFeet;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Run();
        Jump();
        FlipSprite();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value is between -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
    }

    private void Jump()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }


}
