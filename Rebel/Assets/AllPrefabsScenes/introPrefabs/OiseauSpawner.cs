using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OiseauSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] oiseau oiseauPrefab;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(1, 15));
            SpawnOiseau();
        }
        
    }

    private void SpawnOiseau()
    {
        Instantiate(oiseauPrefab, transform.position, transform.rotation);
    }

// Update is called once per frame
void Update()
    {
        
    }

    
}
