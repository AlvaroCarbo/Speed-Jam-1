using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime, time;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
       // if (LevelManager.Instance.isFinished) return;
       // if (GameManager.Instance.isPaused) return;
        time = Time.time - startTime;
        string timer = formatFloatToTime(time);
        timerText.text = timer;
        //LevelManager.Instance.Time = timer;
        //LevelManager.Instance.TimeFloat = time;
    }
    public string formatFloatToTime(float value)
    {
        string minutes = ((int)value / 60).ToString();
        string seconds = (value % 60).ToString("f1");
        string timer = minutes + ":" + seconds;
        return timer;
    }
    public void FinishedLevel() {
        //LevelManager.Instance.isFinished = true;
        
        timerText.color = Color.yellow;
    }
}
