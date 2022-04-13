using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.SceneManagement;

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

    /// <summary>
    /// Whether or not blue earned a point
    /// </summary>
    public bool BluePoint { get => _bluePoint; }
    /// <summary>
    /// Whether or not red earned a point
    /// </summary>
    public bool RedPoint { get => _redPoint; }

    /// <summary>
    /// Awake is called when an instace of the script is created
    /// </summary>
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Called when this actor is added to a scene
    /// </summary>
    private void Start()
    {
        //Sends the ball towards a random direction at the start of a match
        float random = Random.Range(-70, 70);  
        _rigidbody.AddForce(new Vector3(_ballForce, 0, random));
    }

    /// <summary>
    /// Different collision calls for different game objects
    /// </summary>
    /// <param name="collision"></param>
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
