using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleche : MonoBehaviour
{
    [SerializeField] GameObject fleche_aliment;

    RectTransform transformFleche;

    float speedRotation = 0.1f;

    [SerializeField] Transform player;

    private void Start()
    {
        transformFleche = fleche_aliment.GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(player);
    }

    private void Update()
    {

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition.z = 0;

        Vector2 AnchorToPlayer = this.transform.position - player.transform.position;
        var angle = Mathf.Atan2(AnchorToPlayer.y, AnchorToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transformFleche.position = new Vector2( Mathf.Clamp(screenPosition.x, 0, Camera.main.pixelWidth), Mathf.Clamp(screenPosition.y, 0, Camera.main.pixelHeight));


        transform.eulerAngles += new Vector3(0,0, speedRotation);


        Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            fleche_aliment.SetActive(false);
        }
        else
        {
            fleche_aliment.SetActive(true);
        }

    }


}
