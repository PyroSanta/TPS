using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart = 60;
    public Text timerText;
    public float endTime = 0;
    public GameObject GameWining;
    public GameObject gameplayUI;


    // Start is called before the first frame update
    void Start()
    {
       timerText.text =  timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timeStart).ToString();
        if(timeStart <= 0)
        {
            gameplayUI.SetActive(false);
            GameWining.SetActive(true);


            GetComponent<PlayerController>().enabled = false;
            GetComponent<FireballCaster>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
        }

        
    }
}
