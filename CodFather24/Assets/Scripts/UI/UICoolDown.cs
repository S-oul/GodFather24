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

    [SerializeField] AnimationCurve fade;

    [SerializeField] GameObject ecranFin;

    [SerializeField] GameObject collectible;
    [SerializeField] GameObject fleches;
    [SerializeField] GameObject miniMap;
    [SerializeField] GameObject colliderPlayer;

    bool reste60 = false;
    bool reste10 = false;

    private void Start()
    {
        this.gameObject.SetActive(true);
        ecranFin.SetActive(false);
        transparence = neige.color;
        transparence.a = 0f;
        neige.color = transparence;

        collectible.SetActive(true);
        fleches.SetActive(true);
        miniMap.SetActive(true);
        colliderPlayer.SetActive(true);
    }


    void Update()
    {
        timer -= Time.deltaTime;
        var ts = TimeSpan.FromSeconds(timer);
        tmp.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

        if (timer < 30 && !reste60)
        {
            //play sound "il reste 1 minutes"
            StartCoroutine(playSound());

            reste60 = true;
        }

        if (timer < 10)
        {
            if (!reste10)
            {

                reste10 = true;
            }
            float pourcentageTransparence = (10 - timer) / 10;
            transparence.a = fade.Evaluate(pourcentageTransparence);
            neige.color = transparence;
        }

        if (timer <= 0)
        {
            ecranFin.SetActive(true);
            this.gameObject.SetActive(false);

            collectible.SetActive(false);
            fleches.SetActive(false);
            miniMap.SetActive(false);
            colliderPlayer.SetActive(false);
        }
    }

    IEnumerator playSound()
    {
        for (int i = 0; i < 3; i++)
        {
            SoundManager.instance.jouerAudio(SoundManager.instance.reste30sound);
            yield return new WaitForSeconds(2);
        }
    }
}
