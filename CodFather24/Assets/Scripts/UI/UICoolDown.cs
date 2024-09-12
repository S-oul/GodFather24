using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICoolDown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] float timer = 180f;

    [SerializeField] Image neige;
    Color transparence;

    [SerializeField] GameObject ecranFin;

    private void Start()
    {
        ecranFin.SetActive(false);
        transparence = neige.color;
        transparence.a = 0f;
    }


    void Update()
    {
        timer -= Time.deltaTime;
        var ts = TimeSpan.FromSeconds(timer);
        tmp.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

        if (timer < 10)
        {
            float pourcentageTransparence = (10 - timer) / 10;
            transparence.a = pourcentageTransparence;
            neige.color = transparence;
        }
        if (timer == 0)
        {
            ecranFin.SetActive(true);
        }
    }
}
