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

        while (temps > 0)
        {
            if (tourne)
            {
                Camera.main.transform.eulerAngles += new Vector3(0, 0, 1);
                //virtualCamera.m_Lens.Dutch = 1f;
            }
        transform.localPosition = new Vector2(Random.Range(-1,1)*power, Random.Range(-1, 1) * power);
        temps -= Time.deltaTime;

            yield return null;
        }
        transform.localPosition = Vector3.zero;

        if (tourne)
        {
            Camera.main.transform.eulerAngles += new Vector3(0, 0, 0);
            //virtualCamera.m_Lens.Dutch = 0f;
        }

        yield return null;
    }
}
