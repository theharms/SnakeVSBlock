using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public int Value;
    public Text ValueText;
    void Start()
    {
        ValueText.text = Value.ToString();
    }

}
