using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChangerBehaviour : MonoBehaviour
{
    Light _lightComponent;
    bool isRed = false;

    private void Start()
    {
        _lightComponent.color = Color.blue;
        _lightComponent = GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Divider"))
        {
            if (isRed) _lightComponent.color = Color.blue;
            else _lightComponent.color = Color.red;
        }
    }
}
