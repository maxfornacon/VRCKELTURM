using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    public TMP_Text timerValue;
    public bool run = true;
    
    // Start is called before the first frame update
    void Start()
    {
        //timerValue = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
           currentTime += 1 * Time.deltaTime;
           timerValue.text = currentTime.ToString("0");   
        }
    }
}
