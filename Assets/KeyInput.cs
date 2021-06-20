using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class KeyInput
{
    KeyCode code;
    public KeyCode Code { get { return code; } }

    public KeyInput(KeyCode set)
    {
        code = set;
    }

    public string Text()
    {
        switch (code)
        {
            case KeyCode.LeftArrow:
                return "←";
            case KeyCode.RightArrow:
                return "→";
            case KeyCode.UpArrow:
                return "↑";
            case KeyCode.DownArrow:
                return "↓";
            default:
                return code.ToString();
        }
    }
    public bool Key()
    {
        return Input.GetKey(code);
    }
    public bool OverlapTest(KeyCode key)
    {
        return code == key;
    }    
}
