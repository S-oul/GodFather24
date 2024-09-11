using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    [SerializeField] float _playerSpeed = .15f;
    [SerializeField] float _bombPowerScale = 5;

    Rigidbody2D _rigidbody;

    List<GameObject> _followAliments = new List<GameObject>();

    GameObject _selectedAnchor;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _followAliments.Add(this.gameObject);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            if (hit && hit.transform.CompareTag("Anchor")) {

                _selectedAnchor = hit.collider.gameObject;
                _selectedAnchor.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            _selectedAnchor.GetComponent<SpriteRenderer>().color = Color.white;
            _selectedAnchor = null;
        }

        if (_selectedAnchor != null)
        {
            Vector2 mouseToPlayer = _selectedAnchor.transform.position - transform.position;
            float distance = Vector3.Distance(_selectedAnchor.transform.position, transform.position);

            _rigidbody.velocity += mouseToPlayer.normalized * _playerSpeed * Mathf.Max(0, distance * (1 / (distance + 1)));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("bomb"))
        {
            Vector2 dirToPlayer = transform.position - collision.transform.position;
            _rigidbody.velocity = dirToPlayer * _bombPowerScale;
        }

        if (collision.transform.CompareTag("wall"))
        {
            _rigidbody.velocity = collision.contacts[0].normal * _bombPowerScale;
        }

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("aliments"))
        {
            collision.transform.GetComponent<follower>().target = _followAliments[_followAliments.Count -1].transform;
            collision.transform.GetComponent<BoxCollider2D>().enabled = false;
            _followAliments.Add(collision.gameObject);
        }
    }

    #region Debug
    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position, Color.red);
            Debug.DrawLine(transform.position, transform.position + (Vector3)_rigidbody.velocity, Color.yellow);
        }
    }
#endregion  
}
