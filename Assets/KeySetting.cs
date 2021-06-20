using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class KeySetting : MonoBehaviour
{
    Vector3 hide, show;
    Adjust active;
    public Adjust[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        KeySave.Get.Setting(buttons.Length, buttons);
        hide = new Vector3(-1500f, 0f, 0f);
        show = new Vector3(0f, 0f, 0f);
        for (int i = 0; i < buttons.Length; ++i) {
            buttons[i].Replace(i);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (active) {            
            for (KeyCode i = 0; i < KeyCode.Mouse0; ++i) {
                if (Input.GetKeyDown(i)) {
                    Debug.Log(i);
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
                        active.SetKey(new KeyInput(i));
                        break;
                    }
                }
            }
        }
    }
    public void Show()
    {
        transform.localPosition = show;
        if (Wave.Get)
            Wave.Get.working = false;
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
        if (Wave.Get)
            Wave.Get.working = true;
    }
    public void Confirm()
    {
        if (active) {
            active.Deactivate();
        }
        active = null;
        for (int i = 0; i < buttons.Length; ++i) {
            buttons[i].Replace(i);
        }
        if (Wave.Get)
            Wave.Get.working = true;
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
}
