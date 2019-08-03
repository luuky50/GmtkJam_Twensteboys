﻿using UnityEngine;

public class GridElement : MonoBehaviour
{
#if UNITY_EDITOR

    [SerializeField] private bool _Top, _Right, _Bottom, _Left;
    [SerializeField] private GameObject WallPrefab;

    [SerializeField, HideInInspector] GameObject[] walls = new GameObject[4];


    public GameObject ground => transform.Find("Ground").gameObject;


    public void Clear()
    {
        SetTop(false);
        SetRight(false);
        SetBottom(false);
        SetLeft(false);
        DestroyImmediate(ground);
    }

    float GetBoundX => ground.transform.lossyScale.x / 2;
    float GetBoundZ => ground.transform.lossyScale.z / 2;
    float GetBoundY => ground.transform.lossyScale.y / 2;

    float GetWallBoundY => WallPrefab.transform.lossyScale.y / 2;
    float GetWallBoundZ => WallPrefab.transform.lossyScale.z / 2;

    public void SetTop(bool active)
    {
        _Top = active;
        if (_Top)
        {

            float boundZ = GetBoundZ;
            float boundY = GetBoundY;
            float wallBoundY = GetWallBoundY;
            float WallBoundZ = GetWallBoundZ;

            if (walls[0] == null)
            {
                walls[0] = Instantiate(WallPrefab, ground.transform.position + (Vector3.forward * (boundZ - WallBoundZ)) + (Vector3.up * (boundY + wallBoundY)), Quaternion.identity, gameObject.transform);
            }
        }
        else
        {
            if (walls[0] != null)
            {
                DestroyImmediate(walls[0]);
            }
        }
    }

    public void SetRight(bool active)
    {


        _Right = active;
        if (_Right)
        {

            float boundX = GetBoundX;
            float boundY = GetBoundY;

            float wallBoundY = GetWallBoundY;
            float WallBoundZ = GetWallBoundZ;

            if (walls[1] == null)
            {
                walls[1] = Instantiate(WallPrefab, transform.position + (Vector3.right * (boundX - WallBoundZ)) + (Vector3.up * (boundY + wallBoundY)), Quaternion.Euler(0, 90, 0), gameObject.transform);
            }
        }
        else
        {
            if (walls[1] != null)
            {
                DestroyImmediate(walls[1]);
            }
        }
    }

    public void SetBottom(bool active)
    {
        _Bottom = active;
        if (_Bottom)
        {

            float boundZ = GetBoundZ;
            float boundY = GetBoundY;

            float wallBoundY = GetWallBoundY;
            float WallBoundZ = GetWallBoundZ;

            if (walls[2] == null)
            {
                walls[2] = Instantiate(WallPrefab, transform.position + (Vector3.back * (boundZ - WallBoundZ)) + (Vector3.up * (boundY + wallBoundY)), Quaternion.identity, gameObject.transform);
            }
        }
        else
        {
            if (walls[2] != null)
            {
                DestroyImmediate(walls[2]);
            }
        }
    }

    public void SetLeft(bool Active)
    {
        _Left = Active;

        if (_Left)
        {
            float boundZ = GetBoundZ;
            float boundY = GetBoundY;

            float wallBoundY = GetWallBoundY;
            float WallBoundZ = GetWallBoundZ;
            if (walls[3] == null)
            {
                walls[3] = Instantiate(WallPrefab, transform.position + (Vector3.left * (boundZ - WallBoundZ)) + (Vector3.up * (boundY + wallBoundY)), Quaternion.Euler(0, 90, 0), gameObject.transform);
            }
        }
        else
        {

            if (walls[3] != null)
            {
                DestroyImmediate(walls[3]);
            }
        }
    }

    private void OnValidate()
    {
        UnityEditor.EditorApplication.delayCall += () =>
        {
            SetTop(_Top);
            SetRight(_Right);
            SetBottom((_Bottom));
            SetLeft(_Left);
        };

#endif
    }

}