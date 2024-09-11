using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class UICoolDown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] float timer = 180f;

   
    void Update()
    {
        timer -= Time.deltaTime;
        var ts = TimeSpan.FromSeconds(timer);
        tmp.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
    }
}
