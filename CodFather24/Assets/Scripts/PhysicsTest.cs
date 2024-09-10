using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    [SerializeField] float _playerSpeed = .15f;
    [SerializeField] float _bombPowerScale = 5;

    Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();   
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            if (hit && hit.transform.CompareTag("Anchor")) {

                Vector2 mouseToPlayer = mouseWorldPos - transform.position;
                float distance = Vector3.Distance(mouseWorldPos, transform.position);

                _rigidbody.velocity = mouseToPlayer.normalized * _playerSpeed * Mathf.Max(0,distance * (1 / (distance + 1)));
                print(mouseWorldPos + " // " + mouseToPlayer);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("bomb"))
        {
            Vector2 dirToPlayer = transform.position - collision.transform.position;
            _rigidbody.velocity = dirToPlayer * _bombPowerScale;
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
