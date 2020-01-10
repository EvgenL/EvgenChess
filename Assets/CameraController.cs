using System;
using System.Collections;
using System.Collections.Generic;
using src;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraRotate _rotator;
    [SerializeField] private CameraMouseInput _mouseInput;
    
    private Vector3 _basePos;
    private Quaternion _baseRot;

    private void Awake()
    {
        _basePos = transform.position;
        _baseRot = transform.rotation;

        SetRotating();
    }

    public void SetRotating()
    {
        _mouseInput.enabled = false;
        _rotator.enabled = true;
        transform.position = _basePos;
        transform.rotation = _baseRot;
    }

    public void DisableRotation()
    {
        // todo slow stop
        _rotator.enabled = false;
    }

    public void EnablePlayerControl()
    {
        DisableRotation();
        _mouseInput.enabled = true;
    }

    
}