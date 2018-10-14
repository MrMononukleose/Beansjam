using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public GameObject SchaafWinner;
    public GameObject DingWinner;

    public Text Player1Score;
    public Text Player2Score;

    public Text WinnerText;

	void Start ()
	{
	    Player1Score.text = ResultProvider.Player1Result.ToString();
	    Player2Score.text = ResultProvider.Player2Result.ToString();

        var spawnPoint = new Vector3(0, -3.2f);
	    if (ResultProvider.Player1Result > ResultProvider.Player2Result)
	    {
	        WinnerText.text = "Spieler 1 gewinnt !!!";
	        Instantiate(SchaafWinner, spawnPoint, Quaternion.identity);
        }
	    else
	    {
	        WinnerText.text = "Spieler 2 gewinnt !!!";
	        Instantiate(DingWinner, spawnPoint, Quaternion.identity);
        }
	}
}
