using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float Scale = .15f;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();   
        _rigidbody.velocity = new Vector2(Random.Range(0,15), Random.Range(0,15));
        Debug.Log(_rigidbody.velocity);
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 MouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 DirToPlayer = MouseWorldPos - transform.position;

            _rigidbody.velocity = DirToPlayer * Scale;
            print(MouseWorldPos + " // " + DirToPlayer);
        }
    }
    private void OnDrawGizmos()
    {
        Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);   
    }
}
