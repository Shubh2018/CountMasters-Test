using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private float spawnPositionX;
    private float spawnPositionZ;

    [SerializeField] private TMP_Text text;

    private void Start()
    {
        for(int i = 0; i < Random.Range(20, 100); i++)
        {
            if (Random.Range(0, 100) < 25)
            {
                spawnPositionX = Random.Range(transform.position.x, transform.position.x + 5);
                spawnPositionZ = Random.Range(transform.position.z, transform.position.z + 5);
            }
            else if (Random.Range(0, 100) < 50 && Random.Range(0, 100) > 25)
            {
                spawnPositionX = Random.Range(transform.position.x, transform.position.x - 5);
                spawnPositionZ = Random.Range(transform.position.z, transform.position.z - 5);
            }
            else if (Random.Range(0, 100) < 75 && Random.Range(0, 100) > 50)
            {
                spawnPositionX = Random.Range(transform.position.x, transform.position.x - 5);
                spawnPositionZ = Random.Range(transform.position.z, transform.position.z + 5);
            }
            else
            {
                spawnPositionX = Random.Range(transform.position.x, transform.position.x + 5);
                spawnPositionZ = Random.Range(transform.position.z, transform.position.z - 5);
            }

            Instantiate(enemyPrefab, new Vector3(spawnPositionX, 1.0f, spawnPositionZ), Quaternion.identity).transform.parent = this.transform;
        }
    }

    private void Update()
    {
        text.text = (this.gameObject.transform.childCount - 1).ToString();
    }
}
