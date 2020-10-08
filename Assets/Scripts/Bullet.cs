using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 50;
    public float speed = 40;
    private Transform target;
    public GameObject exposionEffectPrefab;
    public float distanceArriveTarget = 1.2f;
    public void SetTarget(Transform target){
        this.target = target;
    }
    void Update()
    {   
        if (target== null){
            Die();
            return;
        }
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
        Vector3 dir= target.position - transform.position;
        if (dir.magnitude < distanceArriveTarget){
            target.GetComponent<enemy>().takeDamage(damage);
            Die();
        }

    }
    void Die(){
            GameObject effect =  GameObject.Instantiate(exposionEffectPrefab, transform.position, transform.rotation);
            Destroy(effect, 1);
            Destroy(this.gameObject);
    }
 
    
}
