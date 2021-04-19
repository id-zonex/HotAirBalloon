using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform _begin;
    [SerializeField] private Transform _middle;
    [SerializeField] private Transform _end;

    public Transform Begin => _begin;
    public Transform Middle => _middle;
    public Transform End => _end;
}
