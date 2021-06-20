using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Command[] command;
    public Shooter shoot;
    public Rigidbody2D body;
    public Image[] life;
    static Player instance;
    public static Player Get { get { return instance; } }
    int hp;

    void Awake()
    {
        command = new Command[5];
        command[0] = new Left();
        command[1] = new Up();
        command[2] = new Right();
        command[3] = new Down();
        command[4] = new Attack();
        instance = this;
        body = GetComponent<Rigidbody2D>();
        shoot.cooltime = 0.5f;
        hp = life.Length;
    }
    void Start()
    {
        Score.Get.Reset();
    }

    // Update is called once per frame
    void Update()
    {        
        if (Wave.Get.working) {
            foreach (Command it in command) {
                it.Press(this);
            }
        }
    }

    public void ChangeKey(KeyInput set, int pos)
    {
        command[pos].Set(set);
    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject.tag == "EnemyAttack" || other.gameObject.tag == "Enemy") {
            --hp;
            if(hp <= 0) {
                Wave.Get.Reset();
                SceneManager.LoadScene("Lose");
                instance = null;
            } else {
                life[hp].color = new Color(0f, 0f, 0f, 0f);
            }
        }
    }

    public static void Empty()
    {
        instance = null;
    }
}
