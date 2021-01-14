using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCoin : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Coin Text");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
