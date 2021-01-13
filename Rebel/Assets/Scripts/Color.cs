using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wilberforce;

public class Color : MonoBehaviour
{
    public int option = 0;

    private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Color Controller");
        if (obj.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void changeOption(int option)
    {
        this.option = option;
    }
    void Update()
    {
        if (FindObjectOfType<Colorblind>())
        {
            FindObjectOfType<Colorblind>().Type = option;
        }
    }
}
