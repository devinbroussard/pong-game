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

    /// <summary>
    /// Makes the paddle go towards the ball
    /// </summary>
    private void FixedUpdate()
    {
        //Calculates the distance between the paddle and ball
        float distance = (_gameBall.transform.position - transform.position).magnitude;

        //If the ball is in the paddle's defence range, then move towards its Z position
        if (distance < _defendRange)
        {
            //Calculates the direction to the ball from the paddle
            Vector3 direction = _gameBall.transform.position - transform.position;
            if (direction.z > -.1f && direction.z < 0.1f)
            {
                _rigidBody.velocity = new Vector3(0, 0, 0);
                return;
            }

            //Moves the paddle either left or right depending on the direction vector's Z value
            if (_gameBall.transform.position.z > transform.position.z)
                _rigidBody.velocity = new Vector3(0, 0, 1) * _paddleSpeed * Time.fixedDeltaTime;
            else if (_gameBall.transform.position.z < transform.position.z)
                _rigidBody.velocity = new Vector3(0, 0, -1) * _paddleSpeed * Time.fixedDeltaTime;
        }
        else _rigidBody.velocity = new Vector3(0, 0, 0);
    }
}
