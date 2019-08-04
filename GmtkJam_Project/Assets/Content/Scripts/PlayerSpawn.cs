﻿using UnityEngine;

public class PlayerSpawn : Singleton<PlayerSpawn>
{
    public Vector3 GetSpawnLocation() => _closestGridElement.transform.position + Vector3.up * 0.5f;
    public Quaternion GetSpawnRotation() => transform.rotation;
    [SerializeField] private GridElement _closestGridElement;
    [SerializeField] private bool _reset;
    void OnValidate()
    {
        if (_reset)
        {
            float ClosestDistance = 0f;
            foreach (GridElement gridElement in FindObjectsOfType<GridElement>())
            {
                if (_closestGridElement == null)
                {
                    ClosestDistance = (gridElement.transform.position - transform.position).magnitude;
                    _closestGridElement = gridElement;
                }
                else
                {
                    ClosestDistance = (_closestGridElement.transform.position - transform.position).magnitude;
                }

                float TempDistance = (gridElement.transform.position - transform.position).magnitude;
                if (ClosestDistance > TempDistance)
                {
                    print("closest:" + TempDistance);
                    print("Temp:" + TempDistance);
                    _closestGridElement = gridElement;
                }
            }

            _reset = false;
        }
    }
}
