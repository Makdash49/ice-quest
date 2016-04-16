using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class Capsule : MonoBehaviour
{

    public float jumpAngleInDegree;
    public float jumpSpeed;
    public string saveFile = "/savedGhost.gd";
    public bool isGhost = false;


    [Serializable]
    private class GhostPosition
    {
        public float time;
        public Vector3 position;
        public Quaternion rotation;
        public GhostPosition(float time, Vector3 position, Quaternion rotation ) {
            this.time = time;
            this.position = position;
            this.rotation = rotation;
        }
    }


    List<GhostPosition> AllPositions = new List<GhostPosition>();




    private CardboardHead head;
    private Rigidbody rb;
    private bool onFloor;
    private float lastJumpRequestTime = 0.0f;
    private LevelState state;
    private int currentPosition = 0;

    // Use this for initialization
    void Start()
    {
        Cardboard.SDK.OnTrigger += PullTrigger;
        head = GameObject.FindObjectOfType<CardboardHead>();
        rb = GetComponent<Rigidbody>();
        state = GameObject.FindObjectOfType<LevelState>();
        if (isGhost)
        {
            if (Load())
            {
                Destroy(gameObject);
            }
        }
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
        if (!isGhost)
        {
            GhostPosition gp = new GhostPosition(0, transform.position, transform.rotation);
            AllPositions.Add(gp);
            Save();
        }
        else
        {
            if (AllPositions.Count > currentPosition)
            {
                GhostPosition gp = AllPositions[currentPosition];
                currentPosition++;
            }
        }

    }


    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + saveFile);
        bf.Serialize(file, AllPositions );
        file.Close();
    }

    public bool Load()
    {
        if (File.Exists(Application.persistentDataPath + saveFile))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + saveFile, FileMode.Open);
            AllPositions = (List<GhostPosition>)bf.Deserialize(file);
            file.Close();
            return true;
        }
        return false;
    }

}
