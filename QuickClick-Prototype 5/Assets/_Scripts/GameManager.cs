using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;
    private float spawnTime = 1.0f; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {

        while(true)
        {
            yield return new WaitForSeconds(spawnTime);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);

        }

    }
}
