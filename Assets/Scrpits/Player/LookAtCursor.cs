using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    [SerializeField]private Camera mainCamera;
    [SerializeField] private float _slerpParam = 5;

    [SerializeField] private GameObject turret;

    private readonly string groundTagName = "Ground";

    private readonly int maxDistance = 1000;
    void Update()
    {
        UpdateLookaAt();
    }

    private void UpdateLookaAt()
    {
        
        Vector3 cursorScreenPosition = Input.mousePosition;

        var ray = mainCamera.ScreenPointToRay(cursorScreenPosition);
        if (Physics.Raycast(ray, out var hit, maxDistance, LayerMask.GetMask(groundTagName)))
        {
            Vector3 directionToCursor = hit.point - turret.transform.position;
            directionToCursor.y = 0f; 

            Quaternion desiredRotation = Quaternion.LookRotation(directionToCursor, Vector3.up);
            turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, desiredRotation, _slerpParam * Time.deltaTime);
        }
    }
}