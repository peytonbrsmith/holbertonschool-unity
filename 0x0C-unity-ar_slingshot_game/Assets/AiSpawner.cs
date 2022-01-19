using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSpawner : MonoBehaviour
{
    public float waitTime;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(enemyPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
