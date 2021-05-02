using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    public Vector3 hide;
    public Text text;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3f) {
            transform.localPosition = hide;
        }
    }

    public void Show(string write, Vector3 show)
    {
        text.text = write;
        Debug.Log(write);
        transform.localPosition = show;
        timer = 0f;
    }
}
