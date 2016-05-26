using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BoxCollision : MonoBehaviour {

    public Text gazeText;
    public Capsule cap;
    public bool found = false;
    public AudioClip impact;
    AudioSource audio;


    void Start()
    {
        cap = FindObjectOfType<Capsule>();
        audio = GetComponent<AudioSource>();


    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision!!!!!!");
        //renderer.material.color = new Color(0.5f,1,1);
        GetComponent<Renderer>().material.color = new Color(0.5f, 1, 1);

        if (found == false)
        {
            found = true;
            cap.count = cap.count + 1;
            gazeText.text = cap.count.ToString() + " of 10";
            audio.PlayOneShot(impact, 0.7F);
        }

    }
}
