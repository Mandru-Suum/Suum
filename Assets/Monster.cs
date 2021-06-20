using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Enemy
{
    public Shooter gun;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        gun.cooltime = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Wave.Get.working) {            
            if(transform.localPosition.y < -5f) {
                Destroy(gameObject);
            } else {
                Vector2 attack = Player.Get.transform.position - gun.transform.position;
                if (attack.y < -1f) { 
                    gun.Fire(attack.normalized*800f);
                }
                Vector2 toward = new Vector2(0f, 0f);
                if (Player.Get.transform.localPosition.x > transform.localPosition.x) {
                    toward.x = 300f*Time.deltaTime;
                } else {
                    toward.x = -300f*Time.deltaTime;
                }
                body.AddForce(toward);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttack" || other.gameObject.tag == "Player") {
            Destroy(gameObject);
            Score.Get.Scoring(100);
        }
    }
}
