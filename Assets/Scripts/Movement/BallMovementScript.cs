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


}
