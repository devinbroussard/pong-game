using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class GameBallBehaviour : MonoBehaviour
{
    /// <summary>
    /// The ball's rigid body component
    /// </summary>
    Rigidbody _rigidbody;

    /// <summary>
    /// The force that will be applied to the ball after each hit
    /// </summary>
    [SerializeField]
    float _ballForce = 250;

    /// <summary>
    /// The mininum angle that the ball can move towards after a hit
    /// </summary>
    [SerializeField]
    float _wallBounceMultiplier = 1.5f;

    /// <summary>
    /// The speed that the ball will be reset to after colliding with a paddle
    /// </summary>
    [SerializeField]
    float _defaultBounceSpeed = 100f;

    bool _bluePoint = false;
    bool _redPoint = false;

    public bool BluePoint { get => _bluePoint; }
    public bool RedPoint { get => _redPoint; }

    /// <summary>
    /// Awake is called when an instace of the script is created
    /// </summary>
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _rigidbody.AddForce(new Vector3(70, _ballForce, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Velocity: {_rigidbody.velocity.x}, {_rigidbody.velocity.z}");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            _rigidbody.velocity = _rigidbody.velocity * _wallBounceMultiplier;

        else if (collision.gameObject.CompareTag("Paddle"))
            _rigidbody.velocity = (_rigidbody.velocity.normalized * _defaultBounceSpeed);

        else if (collision.gameObject.CompareTag("Blue Goal"))
            _redPoint = true;

        else if (collision.gameObject.CompareTag("Red Goal"))
            _bluePoint = true;
    }

}
