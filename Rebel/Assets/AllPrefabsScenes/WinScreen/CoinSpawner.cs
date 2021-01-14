using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField]GameObject coin;
    // Start is called before the first frame update
    
   
    IEnumerator Start()
    {
        int min = Random.Range(1, 3);
        int max = Random.Range(4, 6);
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(min, max));
            SpawnCoin();
        }

    }

    private void SpawnCoin()
    {
        Instantiate(coin, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }


}