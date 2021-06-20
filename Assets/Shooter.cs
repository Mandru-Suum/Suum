using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    static Queue<Bullet>player, enemy;
    public Bullet bullet;
    float reload;
    public float cooltime;
    // Start is called before the first frame update
    void Start()
    {
        player = new Queue<Bullet>();
        enemy = new Queue<Bullet>();
        reload = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        reload += Time.deltaTime;
    }
    
    public void Fire(Vector2 toward)
    {
        if (reload >= 0f) {            
            Bullet shoot = null;
            if (enemy.Count > 0) {
                Debug.Log("out");
                shoot = enemy.Dequeue();
                shoot.gameObject.SetActive(true);
            } else {
                shoot = Instantiate(bullet);
            }
            shoot.transform.position = transform.position;
            shoot.Toward(toward);
            reload = -cooltime;
        }
    }
    public void FireUp()
    {
        if (reload >= 0f) {
            Bullet shoot = null;
            if (player.Count > 0) {
                shoot = player.Dequeue();
                shoot.gameObject.SetActive(true);
            } else {
                shoot = Instantiate(bullet);
            }
            reload = -0.3f;
            shoot.transform.position = transform.position;
            shoot.Default();
        }
    }
    static public void Collect(bool owner, Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        if (owner) {
            player.Enqueue(bullet);
        } else {
            enemy.Enqueue(bullet);
        }
    }
}