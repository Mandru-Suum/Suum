using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class KeyInput
{
    bool control, alter, shift;
    KeyCode code;
    enum PROPERTY
    {
        NONE, KEY, CONTROL, ALTER, SHIFT
    }

    public KeyInput(KeyCode set, bool combine)
    {
        if (combine) {
            control = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
            alter = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
            shift = Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift);
        } else {
            control = alter = shift = false;
        }
        code = set;
    }
    public KeyInput(FileStream file)
    {
        byte[] read = new byte[1];
        char[] content = new char[8];
        bool process = true, quotes = false, value = false;
        PROPERTY pro = PROPERTY.NONE;
        int length = 0, num = 0;
        while (process && file.Read(read, 0, 1) > 0) {
            switch ((char)read[0]) {
                case '}':
                    process = false;
                    break;
                case '"':
                    if (quotes) {
                        if (Compare(content, "key")) {
                            pro = PROPERTY.KEY;
                        } else if (Compare(content, "ctrl")) {
                            pro = PROPERTY.CONTROL;
                        } else if (Compare(content, "alt")) {
                            pro = PROPERTY.ALTER;
                        } else if (Compare(content, "shift")) {
                            pro = PROPERTY.SHIFT;
                        }
                    } else {
                        Empty(content);
                        length = 0;
                    }
                    quotes = !quotes;
                    break;
                case ':':                    
                    if(pro != PROPERTY.NONE) {
                        value = true;
                    }
                    break;
                case ',':
                    if (pro == PROPERTY.KEY) {
                        code = (KeyCode)num;
                    }
                    pro = PROPERTY.NONE;
                    value = false;
                    break;
                case ' ':
                    break;
                case '\r':
                    break;
                case '\n':
                    break;
                default:
                    if (quotes) {
                        content[length] = (char)read[0];
                        ++length;
                    } else if(value) {
                        switch (pro) {
                            case PROPERTY.KEY:
                                num *= 10;
                                num += (int)read[0] - '0';
                                break;
                            case PROPERTY.CONTROL:
                                control = read[0] != '0';
                                break;
                            case PROPERTY.ALTER:
                                alter = read[0] != '0';
                                break;
                            case PROPERTY.SHIFT:
                                shift = read[0] != '0';
                                break;
                        }
                    }
                    break;
            }
        }
    }
    public KeyInput(int set, bool ctrl, bool alt, bool shf)
    {
        control = ctrl;
        alter = alt;
        shift = shf;
        code = (KeyCode)set;
    }

    public void Save(FileStream file)
    {
        byte[] write = new byte[16];
        file.WriteByte((byte)'{');
        SetString(file, write, "\"key\":");
        int num = (int)code;
        SetString(file, write, num.ToString());
        SetString(file, write, ",\"ctrl\":");
        if (control) {
            file.WriteByte((byte)'1');
        } else {
            file.WriteByte((byte)'0');
        }
        SetString(file, write, ",\"alt\":");
        if (alter) {
            file.WriteByte((byte)'1');
        } else {
            file.WriteByte((byte)'0');
        }        
        SetString(file, write, ",\"shift\":");
        if (shift) {
            file.WriteByte((byte)'1');
        } else {
            file.WriteByte((byte)'0');
        }
        file.WriteByte((byte)'}');
    }

    public string Text()
    {
        string result = "";
        if (control) {
            result = "ctrl+";
        }
        if (alter) {
            result += "alt+";
        }
        if (shift) {
            result += "alt+";
        }
        switch (code)
        {
            case KeyCode.LeftArrow:
                result += "←";
                break;
            case KeyCode.RightArrow:
                result += "→";
                break;
            case KeyCode.UpArrow:
                result += "↑";
                break;
            case KeyCode.DownArrow:
                result += "↓";
                break;
            default:
                result += code;
                break;
        }
        return result;
    }
    public bool Key()
    {
        return control == (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            && alter == (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
            && shift == (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            && Input.GetKeyDown(code);
    }
    public bool OverlapTest(KeyCode key)
    {
        return control == (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            && alter == (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
            && shift == (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            && code == key;
    }
    
    bool Compare(char[]a, string b)
    {
        for(int i = 0; a[i] != 0; ++i) { 
            if(a[i] != b[i]) {
                return false;
            }
        }
        return true;
    }
    void Empty(char[] ary)
    {
        for(int i = 0; i < ary.Length; ++i) {
            ary[i] = '\0';
        }
    }
    void SetString(FileStream file, byte[]write, string str)
    {
        for (int i = 0; i < str.Length; ++i) {
            write[i] = (byte)str[i];
        }
        file.Write(write, 0, str.Length);
    }
}
