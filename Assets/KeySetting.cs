using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class KeySetting : MonoBehaviour
{
    Vector3 hide, show;
    Adjust active;
    public Player player;
    public Adjust[] buttons;
    FileStream file;

    // Start is called before the first frame update
    void Start()
    {
        hide = new Vector3(-1500f, 0f, 0f);
        show = new Vector3(0f, 0f, 0f);
        try {
            file = new FileStream("key.cfg", FileMode.Open);
        } catch (IOException) {
            file = null;
        }
        if (file != null) {            
            int order = 0;
            byte[] read = new byte[1];
            while (file.Read(read, 0, 1) > 0) {
                if((char)read[0] == '{') {
                    buttons[order].SetKey(new KeyInput(file));
                    ++order;
                }
            }
        }
        for (int i = 0; i < buttons.Length; ++i) {
            buttons[i].Replace(player, i);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (active) {            
            for (KeyCode i = 0; i < KeyCode.Mouse0; ++i) {
                if (i != KeyCode.LeftControl && i != KeyCode.LeftAlt && i != KeyCode.LeftShift && Input.GetKeyDown(i)) {
                    bool unique = true;
                    foreach (Adjust it in buttons) {
                        if (it != active) {
                            if (it.OverlapTest(i)) {
                                it.Exchange(active);
                                unique = false;
                                break;
                            }
                        }
                    }
                    if (unique) { 
                        active.SetKey(new KeyInput(i, true));
                        break;
                    }
                }
            }
        }
    }
    public void Show()
    {
        transform.localPosition = show;
        player.working = false;
    }

    public void Cancel() {
        if (active) {
            active.Deactivate();
        }
        active = null;
        foreach (Adjust it in buttons) {
            it.Cancel();
        }
        transform.localPosition = hide;
        player.working = true;
    }
    public void Confirm()
    {
        if (active) {
            active.Deactivate();
        }
        active = null;
        for (int i = 0; i < buttons.Length; ++i) {
            buttons[i].Replace(player, i);
        }
        try {
            if (file == null) {
                file = new FileStream("key.cfg", FileMode.Create);
            } else {
                file.Seek(0, SeekOrigin.Begin);
            }
            bool comma = false;
            file.WriteByte((byte)'[');
            foreach (Adjust it in buttons) {
                if (comma) {
                    file.WriteByte((byte)',');
                }
                it.Save(file);
                comma = true;
            }
            file.WriteByte((byte)']');
        } catch (IOException) {
            file = null;
        }
        player.working = true;
        transform.localPosition = hide;
    }
    public bool Select(Adjust button)
    {
        if (button == active) {
            active = null;
            return false;            
        } else if (active) {
            active.Deactivate();
        }
        active = button;
        return true;
    }
    public void Reset()
    {
        if (active) {
            active.Deactivate();
        }
        active = null;
        foreach (Adjust it in buttons) {
            it.Reset();
        }
    }
    public void OnApplicationQuit()
    {
        if(file != null) {
            file.Close();
        }
    }
}
