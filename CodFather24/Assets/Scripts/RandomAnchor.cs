using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnchor : MonoBehaviour
{

    public float frequency = .7f;
    public float power = .7f;


    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        frequency += Random.Range(-0.05f, 0.05f);
        power += Random.Range(-0.05f, 0.05f);

    }
    private void Update()
    {
        transform.eulerAngles += new Vector3(0, 0,Mathf.Sin(Time.time * frequency)* power);
    }
}
