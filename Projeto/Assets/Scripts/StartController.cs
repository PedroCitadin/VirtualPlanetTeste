using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartController : MonoBehaviour
{

    public Text txtTime;
    private float timeCount = 3;
    
   

   
    void Update()
    {
        updateUITimer();
    }

    ///contador de inicio da fase
    void updateUITimer()
    {
        timeCount -= Time.deltaTime;


        txtTime.text = timeCount.ToString("F0");
    }
}
