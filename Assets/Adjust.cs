using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Adjust : MonoBehaviour
{
    Image self;
    public KeySetting owner;
    public Text text;
    public KeyCode first;
    public KeyInput origin, renew;

    // Start is called before the first frame update
    void Awake()
    {
        self = GetComponent<Image>();
        Reset();
    }

    void Start() {}
        // Update is called once per frame
    void Update()
    {

    }

    public void SetKey(KeyInput input)
    {
        text.text = input.Text();
        renew = input;
    }

    public void onClick()
    {
        if (owner.Select(this)) {
            self.color = new Color(1f, 1f, 0f, 1f);
        } else {
            self.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public bool OverlapTest(KeyCode key)
    {
        return renew.OverlapTest(key);
    }

    public void Replace(int order)
    {
        if (Player.Get)
            Player.Get.ChangeKey(renew, order);
        KeySave.Get.Change(order, renew.Code);
        origin = renew;
    }

    public void Cancel()
    {
        text.text = origin.Text();
        renew = origin;
    }
    public void Deactivate()
    {
        self.color = new Color(1f, 1f, 1f, 1f);
    }
    public void Reset()
    {
        renew = new KeyInput(first);
        text.text = renew.Text();
    }
    public void Exchange(Adjust other)
    {
        KeyInput temp = renew;
        SetKey(other.renew);
        other.SetKey(temp);
    }
}