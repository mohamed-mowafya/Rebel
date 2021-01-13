using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    void Update()
    {
        CoinUpdate();
    }

    private void CoinUpdate()
    {
        GetComponent<Text>().text =  FindObjectOfType<Player>().CoinNumber().ToString();
    }
}
