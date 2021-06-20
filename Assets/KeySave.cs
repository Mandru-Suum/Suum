using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySave
{
    static KeySave instance;
    public static KeySave Get {
        get {
            if (instance == null) {
                instance = new KeySave();
            }
            return instance;
        }
    }
    KeyCode[] key;
    public void Setting(int num, Adjust[]buttons)
    {
        if (key == null) {
            key = new KeyCode[num];
        } else {
            for (int i = 0; i < num; ++i) {
                buttons[i].SetKey(new KeyInput(key[i]));
            }
        }
    }
    public void Change(int pos, KeyCode set)
    {
        key[pos] = set;
    }
}
