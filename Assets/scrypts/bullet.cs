using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float Speed;
    public bool death = false;

    private void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    private void Update()
    {
        transform.position += Vector3.down * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Is Destructible"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
