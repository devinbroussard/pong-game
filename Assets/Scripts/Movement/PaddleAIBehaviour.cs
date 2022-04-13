using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAIBehaviour : MonoBehaviour
{
    /// <summary>
    /// The ball used in the game
    /// </summary>
    [SerializeField]
    GameObject _gameBall;

    /// <summary>
    /// The _gameBall's rigid body component
    /// </summary>
    Rigidbody _gameBallRigidBody;

    /// <summary>
    /// This object's rigid body component
    /// </summary>
    Rigidbody _rigidBody;

    /// <summary>
    /// The distance from the ball this ai must be to start defending
    /// </summary>
    [SerializeField]
    float _defendRange;

    [SerializeField]
    /// <summary>
    /// The speed the paddle with move at
    /// </summary>
    float _paddleSpeed;

    /// <summary>
    /// Called when this script is added to the scene
    /// </summary>
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _gameBallRigidBody = _gameBall.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float distance = (_gameBall.transform.position - transform.position).magnitude;

        if (distance < _defendRange)
        {
            Vector3 direction = _gameBall.transform.position - transform.position;
            if (direction.z > -.1f && direction.z < 0.1f)
            {
                _rigidBody.velocity = new Vector3(0, 0, 0);
                return;
            }

            if (_gameBall.transform.position.z > transform.position.z)
                _rigidBody.velocity = new Vector3(0, 0, 1) * _paddleSpeed * Time.fixedDeltaTime;
            else if (_gameBall.transform.position.z < transform.position.z)
                _rigidBody.velocity = new Vector3(0, 0, -1) * _paddleSpeed * Time.fixedDeltaTime;
        }
        else _rigidBody.velocity = new Vector3(0, 0, 0);
    }
}
