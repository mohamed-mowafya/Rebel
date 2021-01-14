using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBdeB : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] listeSpawn;
    [SerializeField] private Coin coinBdeB;

        void Start()
    {
        ChoisirSpawn();
    }
        
    public void ChoisirSpawn()
    {
        int place = Random.Range(0,listeSpawn.Length);
        Instantiate(coinBdeB, listeSpawn[place].transform.position, Quaternion.identity);
    }

}
