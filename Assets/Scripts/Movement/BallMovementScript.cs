using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementScript : MonoBehaviour
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
    float _minBounceAngle = 240;

    Vector3 _velocity;

    /// <summary>
    /// Awake is called when an instance of the script is created
    /// </summary>
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Called when the game object is added to the scene
    /// </summary>
    private void Start()
    {
        _rigidbody.AddForce(new Vector3(_ballForce, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Paddle"))
    //    {
    //        Vector3 contactPoint = collision.GetContact(0).point;

    //        float relativeContactPoint = (transform.position.y + (transform.localScale.z / 2)) - contactPoint.z;

    //        float normalizedRelativeContactPoint = relativeContactPoint / (gameObject.transform.localScale.z / 2);
    //        float bounceAngle = normalizedRelativeContactPoint * _minBounceAngle;

    //        Vector3 velocity = new Vector3(-Mathf.Sin(bounceAngle), 0, Mathf.Cos(bounceAngle));
    //        _rigidbody.velocity = -velocity * _ballForce * Time.fixedDeltaTime;
    //        _velocity = _rigidbody.velocity;
    //    }

    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        Vector3 direction = new Vector3(_velocity.x, 0, -_velocity.z).normalized;

    //        _rigidbody.velocity = direction * _ballForce * Time.fixedDeltaTime;
    //        _velocity = _rigidbody.velocity;
    //    }
    //}

}
