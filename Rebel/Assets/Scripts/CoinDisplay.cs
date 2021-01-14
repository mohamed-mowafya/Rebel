using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    private void Awake()
    {
        
    }

    void Update()
    {
        CoinUpdate();
    }

    private void CoinUpdate()
    {
        if (FindObjectOfType<Player>())
        {
            if (FindObjectOfType<Player>().CoinNumber() < 0)
            {
                return;
            }
            GetComponent<Text>().text =  FindObjectOfType<Player>().CoinNumber().ToString();
        }
    }
}
