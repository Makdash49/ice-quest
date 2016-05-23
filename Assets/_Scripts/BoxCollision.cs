using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoxCollision : MonoBehaviour {

    public Text gazeText;
    public int Count = 0;

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision!!!!!!");
        //renderer.material.color = new Color(0.5f,1,1);
        GetComponent<Renderer>().material.color = new Color(0.5f, 1, 1);

        Count = Count + 1;
        gazeText.text = Count.ToString();

    }
}
