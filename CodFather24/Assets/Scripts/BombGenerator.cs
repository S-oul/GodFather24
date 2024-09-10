using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    public GameObject Bomb;
    public Vector2 Size;
    public int BombNumber = 15;
    [Range(0.1f,15)]
    public float SpaceBetween = 1;
    public bool Generate;
    List<Transform>  bombs = new List<Transform>();

    void Start()
    {
        for (int i = 0; i < BombNumber; i++) {
            GameObject go = Instantiate(Bomb,transform.position,transform.rotation,transform);
            go.name = "Bomb " + i;
            go.transform.position = new Vector3(Random.Range(-Size.x, Size.x), Random.Range(-Size.y, Size.y));

            foreach (Transform t in bombs) 
            {
                if(Vector3.Distance(t.position,go.transform.position) < 1.5f)
                {
                    go.transform.position += (go.transform.position - t.position).normalized *SpaceBetween;
                }
            }


            bombs.Add(go.transform);
            
        }
    }
    private void Update()
    {
        if (Generate)
        {
            Start();
            Generate = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero,Size*2);
    }
}
