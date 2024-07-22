using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject birdPrefab;
    
    void Start()
    {
        StartCoroutine(IESpawnBird());    
    }

   

    IEnumerator IESpawnBird() 
    {
        while (true)
        {
            //yield return new WaitForSeconds(Random.Range(90, 300));
            yield return new WaitForSeconds(Random.Range(1, 5));
            int r = Random.Range(0, 2);
            GameObject b = Instantiate(birdPrefab, spawnPoints[r].position, Quaternion.identity);
            Bird br = b.GetComponent<Bird>();
            if (r == 0)
            {
                b.transform.Rotate(0, 90, 0);
                br.target = spawnPoints[1];
            }
            else
            {
                b.transform.Rotate(0, -90, 0);
                br.target = spawnPoints[0];
            }

            
        }
    }
}
