using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    static int score;
    static Score instance;
    public static Score Get { get { return instance; } }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        text = GetComponent<Text>();
        text.text = score.ToString();
    }

    public void Scoring(int up)
    {
        score += up;
        text.text = score.ToString();
    }
    public void Reset()
    {
        score = 0;
        text.text = score.ToString();
    }
}
