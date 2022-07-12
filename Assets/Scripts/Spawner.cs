using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField] private bool multiply;
    [SerializeField] private bool add;

    [SerializeField] private int number;
    [SerializeField] private TMP_Text text;

    public int Number
    {
        get { return number; }
    }

    public bool Add
    {
        get { return add; }
    }

    public bool Multiply
    {
        get { return multiply; }
    }

    private void Start()
    {
        if (multiply)
            text.text = "X" + number.ToString();
        else if (add)
            text.text = "+" + number.ToString();
    }
}
