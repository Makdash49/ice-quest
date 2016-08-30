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
    Vector3 previousPreviousJumpVector = Vector3.forward;


    float timeCurrent;
    float timeAtButtonDown;
    float timeAtButtonUp;
    float timeButtonHeld = 0;
    bool draggable = false;
    bool slowingDown = false;


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
        if (tapcount < 0)
        {
            slowingDown = false;
            tapcount = 0;
        }

        var camera = FindObjectOfType<Camera>();
        var lookDirection = camera.transform.rotation * Vector3.forward;

        if (slowingDown == true)
        {
            tapcount -= .050f;
            rb = GetComponent<Rigidbody>();
            rb.velocity = previousPreviousJumpVector * jumpSpeed * tapcount;
        } 

        if (Input.GetButtonDown("Tap"))
        {
            slowingDown = false;
            timeCurrent = Time.fixedTime;
            timeAtButtonDown = timeCurrent;
            Debug.Log("timeAtButtonDown");
            Debug.Log(timeAtButtonDown);
        }

        if (Input.GetButton("Tap"))
        {
            timeCurrent = Time.fixedTime;

            if (timeCurrent - timeAtButtonDown >= .5f)
            {
                tapcount -= .025f;
                if (tapcount < 0)
                {
                    tapcount = 0;
                }
                Vector3 jumpVector = Vector3.MoveTowards(lookDirection, Vector3.one, 0);
                rb.velocity = previousJumpVector * jumpSpeed * tapcount;
            }
        }

        if (Input.GetButtonUp("Tap"))
        {
            timeCurrent = Time.fixedTime;
            timeAtButtonUp = timeCurrent;
            Debug.Log("timeAtButtonUp");
            Debug.Log(timeAtButtonUp);

            if (timeAtButtonUp - timeAtButtonDown < .5f)
            {
                if (tapcount < 1f)
                {
                    tapcount = 1f;
                }
                Vector3 jumpVector = Vector3.MoveTowards(lookDirection, Vector3.one, 0);
                float angle = Vector3.Angle(previousJumpVector, jumpVector);
                rb = GetComponent<Rigidbody>();
                //rb.velocity = jumpVector * jumpSpeed * tapcount;
                if (angle < 10)
                {
                    tapcount += .4f;
                    rb.velocity = jumpVector * jumpSpeed * tapcount;
                    previousJumpVector = jumpVector;
                }
                if (angle >= 10 && angle <= 80)
                {
                    rb.velocity = jumpVector * jumpSpeed * tapcount;
                    previousJumpVector = jumpVector;
                }
                if (angle > 80)
                {
                    slowingDown = true;
                    previousPreviousJumpVector = previousJumpVector;
                    previousJumpVector = jumpVector;
                }

            }
        }   
    }
}
