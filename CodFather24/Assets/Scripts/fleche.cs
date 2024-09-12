using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleche : MonoBehaviour
{
    public GameObject fleche_aliment;
    [SerializeField] float MaxDistanceToDisplay = 50;

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

        Vector2 alimentToPlayer = transform.position - player.transform.position;
        var angle = Mathf.Atan2(alimentToPlayer.y, alimentToPlayer.x) * Mathf.Rad2Deg;
        transformFleche.eulerAngles = new Vector3(0, 0, angle - 90 - Camera.main.transform.eulerAngles.z);

        transformFleche.position = new Vector2(Mathf.Clamp(screenPosition.x, 420+20, Camera.main.pixelWidth-20-420), Mathf.Clamp(screenPosition.y, 20, Camera.main.pixelHeight-20));


        transform.eulerAngles += new Vector3(0,0, speedRotation);


        if(Vector3.Distance(transform.position, player.transform.position) < MaxDistanceToDisplay)
        {
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
        else
        {
            fleche_aliment.SetActive(false);
        }

        

    }


}
