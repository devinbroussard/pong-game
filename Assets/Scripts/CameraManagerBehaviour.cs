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

    private void Awake()
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

        float ratio = _refRatio / _mainCamera.aspect;
        ratio = (float)Math.Round(ratio, 4);


        Vector3 scaledPosition = Vector3.Scale(_startPos * ratio, _zoomScale);

        


        if (_mainCamera.aspect > 1)
        {
            transform.position = _startPos * ratio;
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }

        if (_mainCamera.aspect < 1)
        {
            transform.rotation = Quaternion.Euler(90, 90, 0);
            transform.position = new Vector3(0, 19.6665f, 0);
        }
    }
}
