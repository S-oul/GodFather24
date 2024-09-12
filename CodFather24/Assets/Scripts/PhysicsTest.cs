using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    [SerializeField] float _playerSpeed = .15f;
    [SerializeField] float _bombPowerScale = 5;
    [SerializeField] float _forceFieldPower = 5;
    [SerializeField] float MaxDist = 10;
    [SerializeField] float _rotationSPeed = 15;
     float previusAngle = 0;


    Rigidbody2D _rigidbody;

    List<GameObject> _followAliments = new List<GameObject>();

    GameObject _selectedAnchor;

    CameraShake _shake;

    [SerializeField] int maxElements = 2;
    int nbrAliments = 0;

    [SerializeField] TextMeshProUGUI nbrElements;
    [SerializeField] TextMeshProUGUI maxNbrElements;
    [SerializeField] TextMeshProUGUI slash; 

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _followAliments.Add(this.gameObject);
        _shake = GetComponentInChildren<CameraShake>();

        if (nbrElements != null)
        {
            maxNbrElements.text = maxElements.ToString();
            nbrElements.text = nbrAliments.ToString();
        }
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
            if (hit && hit.transform.CompareTag("Anchor")) {

                _selectedAnchor = hit.collider.gameObject;
                if (Input.GetMouseButtonDown(0))
                {
                    _selectedAnchor.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    _selectedAnchor.GetComponent<SpriteRenderer>().color = Color.blue;
                }
            }
        }
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)) 
        {
            if (_selectedAnchor != null)
            {
                _selectedAnchor.GetComponent<SpriteRenderer>().color = Color.white;
                _selectedAnchor = null;
            }
        }

        if (_selectedAnchor != null)
        {
            Vector2 AnchorToPlayer = _selectedAnchor.transform.position - transform.position;

            float distance = Vector3.Distance(_selectedAnchor.transform.position, transform.position);
            if (Input.GetMouseButton(0))
            {
                //play sound attire
                //SoundManager.instance.jouerAudio(SoundManager.instance.aimantAttire);

                print("Attire");
                _rigidbody.velocity += AnchorToPlayer.normalized * _playerSpeed * Mathf.Max(0, -Mathf.Pow(distance / (MaxDist / 2) - 1, 4) + 1);
            }
            else if(Input.GetMouseButton(1))
            {
                //play sound ettire
                //SoundManager.instance.jouerAudio(SoundManager.instance.aimantEttire);

                print("Ettire");
                _rigidbody.velocity -= AnchorToPlayer.normalized * _playerSpeed * Mathf.Max(0, -Mathf.Pow(distance / (MaxDist / 2) - 1, 4) + 1);
            }
        }

        Vector2 forwarplace = _rigidbody.velocity.normalized + (Vector2)transform.position;
        var angle = Mathf.Atan2(forwarplace.y, forwarplace.x) * Mathf.Rad2Deg;
        var newAngle = Mathf.Lerp(previusAngle, angle, _rotationSPeed * Time.deltaTime);
        transform.rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
        previusAngle = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("bomb"))
        {
            //destroy bomb 
            //play sound explosion
            SoundManager.instance.jouerAudio(SoundManager.instance.bombeExplosion);
            
            Vector2 dirToPlayer = transform.position - collision.transform.position;
            _rigidbody.velocity = dirToPlayer * _bombPowerScale;
            StartCoroutine(_shake.shakeCam());

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
            if (nbrAliments <= maxElements-1)
            {
                //play sound collecte
                //SoundManager.instance.jouerAudio(SoundManager.instance.collecteItem);

                nbrAliments++;
                nbrElements.text = nbrAliments.ToString();
                collision.transform.GetComponent<follower>().target = _followAliments[_followAliments.Count - 1].transform;
                collision.transform.GetComponent<BoxCollider2D>().enabled = false;
                _followAliments.Add(collision.gameObject);

                StartCoroutine(flash());

            }
        }
        
    }


    IEnumerator flash()
    {
        for (int i = 0; i < 3; i++)
        {
            nbrElements.color = Color.red;
            maxNbrElements.color = Color.red;
            slash.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            nbrElements.color = Color.white;
            maxNbrElements.color = Color.white;
            slash.color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("ForceFeild"))
        {
            _rigidbody.velocity += (Vector2.zero - new Vector2(transform.position.x, transform.position.y)) * _forceFieldPower;
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
