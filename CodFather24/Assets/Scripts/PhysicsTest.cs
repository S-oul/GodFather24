using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    [SerializeField] float Scale = .15f;
    [SerializeField] float bombPowerScale = 5;

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



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("bomb"))
        {
            Vector2 dirToPlayer = transform.position - collision.transform.position;
            _rigidbody.velocity = dirToPlayer * bombPowerScale;
        }
    }











    private void OnDrawGizmos()
    {
        Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position, Color.red);
        Debug.DrawLine(transform.position, transform.position + (Vector3)_rigidbody.velocity, Color.yellow);

    }
}
