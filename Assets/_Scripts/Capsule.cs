using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Capsule : MonoBehaviour
{

    public float jumpAngleInDegree;
    public float jumpSpeed;

    private CardboardHead head;
    private Rigidbody rb;
    private bool onFloor;
    private float lastJumpRequestTime = 0.0f;
    private LevelState state;

    // Use this for initialization
    void Start()
    {
        Cardboard.SDK.OnTrigger += PullTrigger;
        head = GameObject.FindObjectOfType<CardboardHead>();
        rb = GetComponent<Rigidbody>();
        state = GameObject.FindObjectOfType<LevelState>();
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
        Vector3 jumpVector = Vector3.MoveTowards(head.Gaze.direction, Vector3.one, 0);
        rb.velocity = jumpVector * jumpSpeed;
    }

    public Vector3 LookDirection()
    {
        return Vector3.ProjectOnPlane(head.Gaze.direction, Vector3.one);
    }

    void OnCollisionStay(Collision collision)
    {
        float delta = Time.time - lastJumpRequestTime;
        if (delta < 0.1)
        {
            Jump();
            lastJumpRequestTime = 0.0f;
        }

    }


    // Update is called once per frame
    void Update()
    {
    }
}
