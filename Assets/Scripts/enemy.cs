using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{   
    public float speed = 10;
    private Transform[] positions;
    private int index = 0;
    public int hp = 150;
    public GameObject exposionEffect;

    
    void Start()
    {
        positions = waypoint.positions;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        if (index > positions.Length - 1) return;
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(positions[index].position, transform.position) < 0.4f){
            index++;
        }
        if (index > positions.Length-1){
            ReachDestination();
        }

    }

    void ReachDestination(){
        GameObject.Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        enemySpawner.CountEnemyAlive--;
    }

    public void takeDamage(int damage){
        if (hp<=0) return;
        hp -= damage;
        if (hp<=0){
            Die();
        }

    }

    void Die(){
        GameObject effect = GameObject.Instantiate(exposionEffect, transform.position, transform.rotation);
        Destroy(effect, 1.5f);
        Destroy(this.gameObject);

    }
}
