using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Capsule : MonoBehaviour
{

    public float jumpAngleInDegree;
    public float jumpSpeed;

    //private CardboardHead head;
    private Rigidbody rb;
    private bool onFloor;
    private float lastJumpRequestTime = 0.0f;
    private LevelState state;
    public int count = 0;
    public float tapcount = 1.0f;

    // Use this for initialization
    void Start()
    {
        //Cardboard.SDK.OnTrigger += PullTrigger;
        //head = GameObject.FindObjectOfType<CardboardHead>();
        rb = GetComponent<Rigidbody>();
        state = GameObject.FindObjectOfType<LevelState>();
        //var camera = GetComponent<Camera>();
    }

    private void PullTrigger()
    {
        Jump();
    }

    private void RequestJump()
    {
        lastJumpRequestTime = Time.time;
        rb.WakeUp();
    }

    private void Jump()
    {
        //Vector3 jumpVector = Vector3.MoveTowards(head.Gaze.direction, Vector3.one, 0);
        //rb.velocity = jumpVector * jumpSpeed;
    }

    //public Vector3 LookDirection()
    //{
        //return Vector3.ProjectOnPlane(head.Gaze.direction, Vector3.one);
    //}

    void OnCollisionStay(Collision collision)
    {
        float delta = Time.time - lastJumpRequestTime;
        if (delta < 0.1)
        {
            Jump();
            lastJumpRequestTime = 0.0f;
        }

    }

    public Vector3 GazeDirection()
    {
        var camera = FindObjectOfType<Camera>();
        return camera.transform.rotation * Vector3.forward;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Tap"))
        {
            rb = GetComponent<Rigidbody>();
            state = GameObject.FindObjectOfType<LevelState>();
            var camera = FindObjectOfType<Camera>();
            var lookDirection = camera.transform.rotation * Vector3.forward;
            Vector3 jumpVector = Vector3.MoveTowards(lookDirection, Vector3.one, 0);
            rb.velocity = jumpVector * jumpSpeed * tapcount;
            tapcount += .10f;
        }
    }
}
