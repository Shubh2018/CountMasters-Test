using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private float speed = 5.0f;

    public GameObject playerPrefab;
    public Transform playerStart;

    private float spawnPositionX;
    private float spawnPositionZ;

    private Spawner spawner;

    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text gameText;

    private void Start()
    {
        slider = GameObject.Find("SlideController").GetComponent<Slider>();

        this.transform.position = playerStart.position;
        Instantiate(playerPrefab, new Vector3(0.0f, 1.0f, 0.0f) + transform.position, Quaternion.identity).transform.parent = this.transform;
    }

    private void Update()
    {
        float movement = slider.value * speed;
        Vector3 direction = new Vector3(movement, 0.0f, speed);
        transform.Translate(direction * Time.deltaTime);

        Debug.Log(this.gameObject.transform.childCount);

        text.text = (gameObject.transform.childCount - 1).ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            gameText.text = "You Win";
        }

        if(other.CompareTag("Spawner"))
        {
            spawner = other.GetComponent<Spawner>();

            if(spawner.Add)
            {
                for (int i = 0; i < spawner.Number; i++)
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

                    Instantiate(playerPrefab, new Vector3(spawnPositionX, 1.0f, spawnPositionZ), Quaternion.identity).transform.parent = this.transform;
                }

                other.GetComponent<MeshRenderer>().enabled = false;
                other.GetComponent<Collider>().enabled = false;
            }

            else if(spawner.Multiply)
            {
                int number = spawner.Number * (gameObject.transform.childCount - 1);

                for (int i = gameObject.transform.childCount - 1; i < number; i++)
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

                    Instantiate(playerPrefab, new Vector3(spawnPositionX, 1.0f, spawnPositionZ), Quaternion.identity).transform.parent = this.transform;
                }
            }

            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<Collider>().enabled = false;
        }
    }
}
