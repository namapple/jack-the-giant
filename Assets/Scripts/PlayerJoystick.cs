using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    public float speed = 8f;
    public float maxVelocity = 4f;

    public GameplayController gameplayController;

    [SerializeField]
    private Rigidbody2D myBody;
    private Animator anim;

    private bool moveLeft, moveRight;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameplayController.ReturnToMenu();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveLeft)
        {
            MoveLeft();
        }
        if (moveRight)
        {
            MoveRight();
        }
    }

    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }    

    public void StopMoving()
    {
        moveLeft = moveRight = false;
        anim.SetBool("Walk", false);
    }

    void MoveLeft()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        if (vel < maxVelocity) forceX = -speed;

        //turn face when move backward
        //when character move backwark, change scale
        Vector3 temp = transform.localScale;
        temp.x = -1.3f;
        transform.localScale = temp;

        anim.SetBool("Walk", true);

        myBody.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        if (vel < maxVelocity)
            forceX = speed;

        Vector3 temp = transform.localScale;
        temp.x = 1.3f;
        transform.localScale = temp;

        anim.SetBool("Walk", true);

        myBody.AddForce(new Vector2(forceX, 0));
    }
}
