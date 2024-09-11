using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float duree = 3f;
    [SerializeField] float power = 5f;

    [SerializeField] CinemachineVirtualCamera virtualCamera;

    public IEnumerator shakeCam()
    {
        float temps = duree;
        while (temps > 0)
        {
        transform.localPosition = new Vector2(Random.Range(-1,1)*power, Random.Range(-1, 1) * power);
        temps -= Time.deltaTime;
            print("ok2");

            yield return null;
        }
        print("ok");
        transform.localPosition = Vector3.zero;

        yield return null;
    }
}
