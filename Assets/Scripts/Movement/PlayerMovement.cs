using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// This owner's rigid body component
    /// </summary>
    private Rigidbody _rigidBody;

    [SerializeField]
    /// <summary>
    /// The scene's main camera
    /// </summary>
    private Camera _camera;

    [SerializeField]
    /// <summary>
    /// The speed the paddle will move at
    /// </summary>
    private float _paddleSpeed;

    /// <summary>
    /// Called when this actor is created
    /// </summary>
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Called once every frame
    /// </summary>
    private void FixedUpdate()
    {
        //Creates a new ray from the camera to the mouse's position
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo; //Stores the hit info of the raycast

        //Raycasts ray, outs hit info; returns true if a hit occured
        if (Physics.Raycast(ray, out hitInfo))
        {
            //Calculates the direction of the raycast from the paddle
            Vector3 direction = (hitInfo.point - transform.position).normalized;

            //Changes the z direction either 1 or -1 depending on the direction
            if (direction.z > 0)
                direction = new Vector3(0, 0, 1);
            else if (direction.z < 0)
                direction = new Vector3(0, 0, -1);
            else direction = new Vector3(0, 0, 0);
            
            //Sets the paddle's velocity to move toward that direction
            _rigidBody.velocity = direction * _paddleSpeed * Time.fixedDeltaTime;
        }
    }
}
