using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player Player;
    public Transform Finish;
    public Slider Slider;
    private float _startZ;
    void Start()
    {
        _startZ = Player.transform.position.z;
    }

   
    void Update()
    {
        float currentZ = Player.transform.position.z;
        float finishZ = Finish.transform.position.z;
        float t = Mathf.InverseLerp(_startZ, finishZ, currentZ);
        Slider.value = t;
    }
}
