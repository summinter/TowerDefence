using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public Transform head;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if (col.tag=="Enemy"){
            enemies.Add(col.gameObject);
        }  
    }


    void OnTriggerExit(Collider col)
    {
        if (col.tag=="Enemy"){
            enemies.Remove(col.gameObject);
        }
    }
    public GameObject bulletPrefab;

    public Transform firePosition;
    void Start()
    {
        timer = attackTime;

    }
    public float attackTime = 1;
    private float timer = 0;

    void Update()
    {
        if (enemies.Count>0 && enemies[0]!= null){
            Vector3 targetPosition = enemies[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }
        timer += Time.deltaTime;
        if (enemies.Count > 0 && timer >= attackTime){
            timer = 0;
            Attack();
        }



    }

    void Attack(){
            if (enemies[0]==null){
                UpdateEnemies();
            }
            if (enemies.Count>0){
                GameObject bullet =  GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
                bullet.GetComponent<Bullet>().SetTarget(enemies[0].transform);
            }else{
                timer = attackTime;
            }



    }

    void UpdateEnemies(){
        List<int> empytIndex = new List<int>();
        for (int index = 0; index < enemies.Count; index++){
            if (enemies[index]==null){
                empytIndex.Add(index);
            }
        }
        for (int i = 0; i < empytIndex.Count;i++){
            enemies.RemoveAt(empytIndex[i]+i);
        }
    }
}
