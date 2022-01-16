using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour
{
    public float speed = 8f;
    public float maxVelocity = 4f;

    [SerializeField]
    private Rigidbody2D myBody;
    private Animator anim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerKeyBoard();
    }

    void PlayerKeyBoard()
    {
        float forceX = 0f;
        // Assign current speed
        // Get the current velocity, velocity could be negative -> use Abs func
        float vel = Mathf.Abs(myBody.velocity.x);

        // Move character with A/D or right/left arrow keys
        float h = Input.GetAxisRaw("Horizontal"); // -1 0 1

        if (h > 0)
        {
            if (vel < maxVelocity)
                forceX = speed;
            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else if(h < 0)
        {
            if (vel < maxVelocity)
                forceX = -speed;

            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;

            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false); // h = 0, no using move keys -> stand still
        }

        myBody.AddForce(new Vector2(forceX, 0));
    }
}
