using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;


    private bool pressed = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Candy")
        {

            if (pressed)
            {
                drop(grabCheck);

            }

            if (Input.GetKey(KeyCode.Space) && !pressed)
            {
                grab(grabCheck);

            }


        }
    }

    void grab(RaycastHit2D grabCheck)
    {
        grabCheck.collider.gameObject.transform.parent = boxHolder;
        grabCheck.collider.gameObject.transform.position = boxHolder.position;
        grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        pressed = true;
    }

    void drop(RaycastHit2D grabCheck)
    {
        grabCheck.collider.gameObject.transform.parent = null;
        grabCheck.collider.gameObject.transform.position = new Vector3(boxHolder.position.x, boxHolder.position.y - 20, boxHolder.position.z);
        grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        pressed = false;
    }
}
