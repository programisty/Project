using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int sec = -1;
    private int min = 0;
    private string curTime;
    [SerializeField] public Text TimerText;
    [SerializeField] public Text Time;

    private void Start()
    {
        StartCoroutine(ITimer());
    }

    private IEnumerator ITimer()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = 0;
            }
            else
            {
                sec++;
            }

            TimerText.text = min.ToString("D2") + ":" + sec.ToString("D2");
            curTime = TimerText.text;     
            yield return new WaitForSeconds(1);
        }
    }

    public void StopTimer()
    {
        Time.text = "Time " + curTime;    
        StopAllCoroutines();    
        TimerText.text = " ";      
    }
}