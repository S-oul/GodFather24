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

    [SerializeField] bool tourne = false;

    public IEnumerator shakeCam()
    {
        float temps = duree;

        if (tourne)
        {
            virtualCamera.m_Lens.Dutch = 1f;
        }
        while (temps > 0)
        {
        transform.localPosition = new Vector2(Random.Range(-1,1)*power, Random.Range(-1, 1) * power);
        temps -= Time.deltaTime;

            yield return null;
        }
        transform.localPosition = Vector3.zero;

        if (tourne)
        {
            virtualCamera.m_Lens.Dutch = 0f;
        }

        yield return null;
    }
}
