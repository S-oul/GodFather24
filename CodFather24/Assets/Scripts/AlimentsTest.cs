using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentsTest : MonoBehaviour
{
    [SerializeField] List<GameObject> points = new List<GameObject>();
    [SerializeField] List<GameObject> aliments = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject point in points)
        {
            int randomIndex = Random.Range(0, aliments.Count);
            aliments[randomIndex].transform.position = point.transform.position;
            aliments.RemoveAt(randomIndex);
            point.SetActive(false);
            
        }
    }
}
