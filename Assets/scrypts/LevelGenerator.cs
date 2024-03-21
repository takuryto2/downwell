using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]private Transform origin;
    public List<GameObject> targetList;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int randomPrefab = Random.Range(0, targetList.Count);
            Instantiate(targetList[randomPrefab], new Vector2(0, origin.position.y - 21.5f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}