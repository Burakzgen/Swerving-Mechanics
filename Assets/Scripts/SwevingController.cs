using UnityEngine;

public class SwevingController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float forwardMoveSpeed = 5f;
    [SerializeField] private float lerpSpeed = 5f;
    [SerializeField] private float playerXValue = 2f;
    [SerializeField] private Vector2 clampValues = new Vector2(-2, 2);

    private float _newXPos;
    private float _startXPos;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startXPos = transform.position.x;
    }
    private void Update()
    {
        // Player Movement Controller
        if (Input.GetButtonDown("Horizontal"))
        {
            _newXPos = Mathf.Clamp
                (
                transform.position.x + Input.GetAxisRaw("Horizontal") * playerXValue, //value
                _startXPos + clampValues.x, //min
                _startXPos + clampValues.y //max
                );
        }
    }
    private void FixedUpdate()
    {
        // Player Movement
        _rigidbody.MovePosition
            (
                new Vector3
                (
                   Mathf.Lerp(transform.position.x, _newXPos, lerpSpeed * Time.fixedDeltaTime), // X
                   _rigidbody.velocity.y, // Y
                   transform.position.z + forwardMoveSpeed * Time.fixedDeltaTime //Z
                )
            );
    }
}


