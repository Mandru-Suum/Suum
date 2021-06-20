using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wave : MonoBehaviour
{
    static Wave instance;
    public Enemy[] enemy;
    public static Wave Get { get { return instance; } }
    public bool working;
    float timer;
    int wave;

    void Awake()
    {
        if(instance == null) {
            wave = 0;
            instance = this;
            working = false;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (working) {
            timer += Time.deltaTime;
            switch (wave) {
                case 0:
                    if(timer > 3f) {
                        timer = 0f;
                        ++wave;
                        Enemy create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(0f, 6f, 0f);
                    }
                    break;
                case 1:
                    if(timer > 1f) {
                        timer = 0f;
                        Enemy create = Instantiate(enemy[0]);
                        create.transform.parent = Player.Get.transform.parent;
                        create.transform.localPosition = new Vector3(2f, 6f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(-2f, 8f, 0f);
                        ++wave;
                    }
                    break;
                case 2:
                    if(timer > 1.8f) {
                        timer = 0f;
                        Enemy create = Instantiate(enemy[0]);
                        create.transform.parent = Player.Get.transform.parent;
                        create.transform.localPosition = new Vector3(-2f, 6f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(2f, 8f, 0f);
                        ++wave;
                    }
                    break;
                case 3:
                    if (timer > 1.6f) {
                        Enemy create = Instantiate(enemy[0]);
                        create.transform.parent = Player.Get.transform.parent;
                        create.transform.localPosition = new Vector3(-1f, 6f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(-3f, 8f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(4f, 7f, 0f);
                        ++wave;
                        timer = 0f;
                    }
                    break;
                case 4:
                    if (timer > 1.9f) {
                        Enemy create = Instantiate(enemy[0]);
                        create.transform.parent = Player.Get.transform.parent;
                        create.transform.localPosition = new Vector3(-1f, 8f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(-3f, 7f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(4f, 6f, 0f);
                        ++wave;
                        timer = 0f;
                    }
                    break;
                case 5:
                    if (timer > 1.5f) {
                        Enemy create = Instantiate(enemy[0]);
                        create.transform.parent = Player.Get.transform.parent;
                        create.transform.localPosition = new Vector3(0f, 8f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(4f, 7f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(2f, 9f, 0f);
                        ++wave;
                        timer = 0f;
                    }
                    break;
                case 6:
                    if (timer > 1.1f) {
                        Enemy create = Instantiate(enemy[0]);
                        create.transform.parent = Player.Get.transform.parent;
                        create.transform.localPosition = new Vector3(-2f, 8f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(-3f, 9f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(1f, 8f, 0f);
                        ++wave;
                        timer = 0f;
                    }
                    break;
                case 7:
                    if (timer > 0.6f) {
                        Enemy create = Instantiate(enemy[0]);
                        create.transform.parent = Player.Get.transform.parent;
                        create.transform.localPosition = new Vector3(0f, 10f, 0f);
                        ++wave;
                        timer = 0f;
                    }
                    break;
                case 8:
                    if (timer > 0.4f) {
                        Enemy create = Instantiate(enemy[0]);
                        create.transform.parent = Player.Get.transform.parent;
                        create.transform.localPosition = new Vector3(4f, 9f, 0f);
                        ++wave;
                        timer = 0f;
                    }
                    break;
                case 9:
                    if (timer > 1.3f) {
                        Enemy create = Instantiate(enemy[0]);
                        create.transform.parent = Player.Get.transform.parent;
                        create.transform.localPosition = new Vector3(-3f, 9f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(5f, 7f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(2f, 8f, 0f);
                        ++wave;
                        timer = 0f;
                    }
                    break;
                case 10:
                    if (timer > 0.9f) {
                        Enemy create = Instantiate(enemy[0]);
                        create.transform.parent = Player.Get.transform.parent;
                        create.transform.localPosition = new Vector3(-1f, 9f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(-6f, 7f, 0f);
                        create = Instantiate(enemy[0]);
                        create.transform.localPosition = new Vector3(1f, 8f, 0f);
                        ++wave;
                        timer = 0f;
                    }
                    break;
                case 11:
                    if (timer > 3f) {
                        Player.Empty();
                        Reset();
                        SceneManager.LoadScene("Victory");
                    }
                    break;
            }
        }
    }
    public void Reset()
    {
        working = false;
        wave = 0;
        timer = 0f;
    }
}
