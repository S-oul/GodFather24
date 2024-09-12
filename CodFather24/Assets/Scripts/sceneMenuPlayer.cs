using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class sceneMenuPlayer : MonoBehaviour
{
    [SerializeField] ChangeScene changeScene;

    bool changement = false;

    [SerializeField] Image debut;
    Color transparence;

    bool debutTimer = false;

    float timer = 3f;

    [SerializeField] AnimationCurve fade;

    private void Start()
    {
        transparence = debut.color;
        transparence.a = 0f;
        debut.color = transparence;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("menu"))
        {
            debutTimer = true;
            
        }
        if (collision.transform.CompareTag("quit"))
        {
            StartCoroutine(attenteChangement());
            if (changement) { changeScene.Quit(); } 
        }
    }



    IEnumerator attenteChangement()
    {
        yield return new WaitForSeconds(3);
        changement = true;
    }

    private void Update()
    {
        if (debutTimer)
        {
            timer -= Time.deltaTime;

            float pourcentageTransparence = (3f - timer) / 3f;
            transparence.a = fade.Evaluate(pourcentageTransparence);
            debut.color = transparence;

            if (pourcentageTransparence >= 1)
            {
                changeScene.LoadLevel();
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines();

        transparence.a = 0f;
        debut.color = transparence;
    }
}
