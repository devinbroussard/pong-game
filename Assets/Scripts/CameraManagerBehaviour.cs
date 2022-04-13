using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraManagerBehaviour : MonoBehaviour
{
    /// <summary>
    /// The game's main camera
    /// </summary>
    private Camera _mainCamera;

    /// <summary>
    /// The aspect ratio of the game
    /// </summary>
    [SerializeField]
    private Vector2 _referenceAspectRatio;

    /// <summary>
    /// The start position of the camera
    /// </summary>
    private Vector3 _startPos;

    private float _refRatio;

    private Vector3 _zoomScale = Vector3.one;

    private void Start()
    {
        _mainCamera = GetComponent<Camera>();
        _refRatio = _referenceAspectRatio.x / _referenceAspectRatio.y;
        _startPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (_referenceAspectRatio.x <= 0 || _referenceAspectRatio.y <= 0)
            return;

        double ratio = _refRatio / _mainCamera.aspect;
        ratio = Math.Round(ratio, 4);

        if (ratio > 1)
        {
            _mainCamera.transform.rotation = Quaternion.Euler(90, 90, 0);
        }
       

        Vector3 scaledPosition = Vector3.Scale(_startPos * (float)ratio, _zoomScale);

        transform.position = scaledPosition;
    }
}
