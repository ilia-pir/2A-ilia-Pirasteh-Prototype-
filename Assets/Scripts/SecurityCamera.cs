using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;

    private void Start()
    {
        _camera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (!player)
        {
            return;
        }

        _camera.Priority = 11;
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (!player)
        {
            return;
        }

        _camera.Priority = 0;
    }
}
