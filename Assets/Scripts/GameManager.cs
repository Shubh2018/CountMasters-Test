using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Player player;

    [SerializeField] private TMP_Text text;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if(player.transform.childCount - 1 <= 0)
        {
            text.text = "You Lose";
        }
    }
}
