using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpeechBubble bubble;
    Command[] command;
    public bool working;
    // Start is called before the first frame update
    void Awake()
    {
        command = new Command[8];
        command[0] = new One();
        command[1] = new Two();
        command[2] = new Three();
        command[3] = new Four();
        command[4] = new Five();
        command[5] = new Six();
        command[6] = new Seven();
        command[7] = new Eight();
    }

    // Update is called once per frame
    void Update()
    {
        if (working) {
            foreach (Command it in command) {
                it.Act(this);
            }
        }
    }

    public void ChangeKey(KeyInput set, int pos)
    {
        command[pos].Set(set);
    }
}
