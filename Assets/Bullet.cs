using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Wave.Get.working) {
            if(transform.localPosition.y > 5f || transform.localPosition.y < -5f || transform.localPosition.x < -10f || transform.localPosition.x > 10f) {
                Shooter.Collect(gameObject.tag == "PlayerAttack", this);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.tag == "PlayerAttack") {
            if (other.gameObject.tag == "Enemy") {
                Shooter.Collect(true, this);
            }
        } else if (other.gameObject.tag == "Player") {
            Shooter.Collect(false, this);
        }
    }

    public void Default()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 500f));
    }

    public void Toward(Vector2 toward)
    {
        GetComponent<Rigidbody2D>().AddForce(toward);
        toward.Normalize();
        float rotation = 0f;
    	if (toward.y > 0f) {
            rotation = -0.5f + Mathf.Acos(toward.x) / Mathf.PI;
    	} else if (toward.y < 0f){
            rotation = 1.5f - Mathf.Acos(toward.x) / Mathf.PI;
    	} else if (toward.x > 0f)
            rotation = 1.5f;
    	else
            rotation = 0.5f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }
}
