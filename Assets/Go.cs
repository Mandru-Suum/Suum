using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go : MonoBehaviour
{
    public string scene;
    public bool start;
    public void Click()
    {
        SceneManager.LoadScene(scene);
        if (start) {
            Wave.Get.working = true;
        }
    }
}
