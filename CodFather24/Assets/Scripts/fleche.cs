using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleche : MonoBehaviour
{
    [SerializeField] GameObject fleche_aliment;

    RectTransform transformFleche;

    private void Start()
    {
        transformFleche = fleche_aliment.GetComponent<RectTransform>();
    }

    private void Update()
    {

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition.z = 0;

        

        transformFleche.position = new Vector2( Mathf.Clamp(screenPosition.x, 0, Camera.main.pixelWidth), Mathf.Clamp(screenPosition.y, 0, Camera.main.pixelHeight));
    }

}
