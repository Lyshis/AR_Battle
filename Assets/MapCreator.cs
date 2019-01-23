using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles;
    private List<int> _map = new List<int>()
    {
        0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0
    };

    void Start()
    {
        int size = (int) Math.Sqrt(_map.Count);
        for (int i = 0; i < _map.Count; ++i)
        {
            Instantiate(_obstacles[_map[i]], new Vector3((i % size) * 2, 0, i / size * 2), Quaternion.identity);
        }
    }
}