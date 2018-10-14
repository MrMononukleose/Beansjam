using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ErklärTimer : MonoBehaviour
{
    public Text TimerText;

    private int timer;
    
	void Start ()
	{
	    timer = 5;
        UpdateTimer();
	}

    private void UpdateTimer()
    {
        if (timer == -1)
        {
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
            return;
        }

        TimerText.text = "Es geht los in " + timer;
        timer--;

        Invoke("UpdateTimer", Random.Range(1, 1));
    }
}
