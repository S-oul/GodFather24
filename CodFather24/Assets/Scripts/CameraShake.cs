using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float duree = 5f;
    [SerializeField] float power = 3f;

    public IEnumerator shakeCam()
    {
        while (duree > 0)
        {
        transform.position = new Vector2(Random.Range(-1,1)*power, Random.Range(-1, 1) * power);
        duree -= Time.deltaTime;
        yield return null;
        }
        transform.position = new Vector2(0, 0);
    }
}
