using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Capsule : MonoBehaviour
{

    public float jumpAngleInDegree;
    public float jumpSpeed;
    public AudioClip impact;
    AudioSource audio;

    //private CardboardHead head;
    private Rigidbody rb;
    private bool onFloor;
    private float lastJumpRequestTime = 0.0f;
    private LevelState state;
    public int count = 0;
    public float tapcount = 1.0f;

    Vector3 previousJumpVector = Vector3.forward;


    // Use this for initialization
    void Start()
    {
        //Cardboard.SDK.OnTrigger += PullTrigger;
        //head = GameObject.FindObjectOfType<CardboardHead>();
        rb = GetComponent<Rigidbody>();
        state = GameObject.FindObjectOfType<LevelState>();
        //var camera = GetComponent<Camera>();
        audio = GetComponent<AudioSource>();
}

    void OnCollisionEnter(Collision col)
    {
        jumpSpeed = 1.0f;
        tapcount = 1.0f;
        audio.PlayOneShot(impact, 0.7F);
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
        var camera = FindObjectOfType<Camera>();
        var lookDirection = camera.transform.rotation * Vector3.forward;
        if (Input.GetButtonDown("Tap"))
        {
            Vector3 jumpVector = Vector3.MoveTowards(lookDirection, Vector3.one, 0);
            float angle = Vector3.Angle(previousJumpVector, jumpVector);
            rb = GetComponent<Rigidbody>();
            rb.velocity = jumpVector * jumpSpeed * tapcount;
            if (angle < 10)
            {
                tapcount += .4f;
            }
            if (angle > 80)
            {
                tapcount = 1;
            }
            rb.velocity = jumpVector * jumpSpeed * tapcount;
            previousJumpVector = jumpVector;
        }
    }
}
