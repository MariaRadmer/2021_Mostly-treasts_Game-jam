using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// SOURCE: https://www.tutorialspoint.com/unity/unity_basic_movement_scripting.htm for the movement for the axis
// SOURCE: https://pressstart.vip/tutorials/2018/06/28/41/keep-object-in-bounds.html for how to andle the camara position
// SOURCE: https://www.youtube.com/watch?v=dlYoy4galr4 for how to turn the player

public class player : MonoBehaviour
{

    public Camera MainCamera;
    private Vector2 screenBounds;

    private Rigidbody2D playerRb;
    public float movementSpeed = 25.0f;

    bool isFacingRight = true;
    private Vector2 facingRight;





    // Start is called before the first frame update
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        playerRb = GetComponent<Rigidbody2D>();
        facingRight = new Vector2(transform.localScale.x, transform.localScale.y);

    }

    // Update is called once per frame
    void Update()
    {


        float horInput = Input.GetAxisRaw("Horizontal");

        float x = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;

        if (horInput < 0 && isFacingRight)
        {
            isFacingRight = false;
            changeDirection();
        }

        if (horInput > 0 && !isFacingRight)
        {
            isFacingRight = true;
            changeDirection();
        }


        if (insideBounds(x, y))
        {
            gameObject.transform.position = new Vector2(transform.position.x + x, transform.position.y + y);

        }
    }


    void changeDirection()
    {

        if (isFacingRight)
        {
            transform.localScale = facingRight;
        }
        if (!isFacingRight)
        {
            transform.localScale = (new Vector2(-transform.localScale.x, transform.localScale.y));
        }

    }


    bool insideBounds(float x, float y)
    {
        return ((-7) < (x + transform.position.x) && (x + transform.position.x) < 35 && (-5) < (y + transform.position.y) && (y + transform.position.y) < 25);
    }

    float SmoothStep(float x)
    {

        return (x * x * (3 - 2 * x));
    }

}
