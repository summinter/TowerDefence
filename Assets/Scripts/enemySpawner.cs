using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public wave[] waves;
    public Transform START;
    public static float CountEnemyAlive = 0;
    public float waveRate = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    IEnumerator SpawnEnemy()
    {
        foreach (wave wave in waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefab, START.position, Quaternion.identity);
                CountEnemyAlive++;
                if (i!=wave.count - 1){
                    yield return new WaitForSeconds(wave.rate);
                }
            }
            while(CountEnemyAlive > 0){
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);

        }
    }
}
