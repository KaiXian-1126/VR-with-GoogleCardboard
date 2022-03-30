using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cam;
    public float forwardToggleAngle = 30.0f, backwardToggleAngle = 270.0f;
    public float speed = 100.0f;
    public bool moveForward = false, moveBackward = false;
    public CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.eulerAngles.x >= forwardToggleAngle && cam.transform.eulerAngles.x <= 125)
            moveForward = true;
        else
            moveForward = false;

        if (cam.transform.eulerAngles.x >= backwardToggleAngle && cam.transform.eulerAngles.x <= 330)
            moveBackward = true;
        else
            moveBackward = false;
        if (moveForward)
        {
            Vector3 forward = cam.transform.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed * Time.deltaTime);
        }
        if (moveBackward)
        {
            Vector3 backward = cam.transform.TransformDirection(Vector3.back);
            cc.SimpleMove(backward * speed * Time.deltaTime);
        }
    }
}
