using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Transform Transform;
    public bool death = false;

    private void Start()
    {
        Transform = transform.GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = new Vector2(0, -Speed);
    }
}
