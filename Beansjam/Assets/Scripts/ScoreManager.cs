using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text Player1ScoreText;
    public Text Player2ScoreText;

    private int player1Score;
    private int player2Score;

    private int scoreDifference;
    private GameObject zeiger;

    // Use this for initialization
    void Start ()
    {
        zeiger = GameObject.FindGameObjectWithTag("Zeiger");

        player1Score = 0;
        UpdatePlayer1Score(0);
        player2Score = 0;
        UpdatePlayer2Score(0);

        scoreDifference = 0;
    }

    public void UpdatePlayer1Score(int scoreToAdd)
    {
        player1Score += scoreToAdd;
        Player1ScoreText.text = "Punkte: " + player1Score;

        UpdateScoreDifference();
    }

    public void UpdatePlayer2Score(int scoreToAdd)
    {
        player2Score += scoreToAdd;
        Player2ScoreText.text = "Punkte: " + player2Score;

        UpdateScoreDifference();
    }

    private void UpdateScoreDifference()
    {
        scoreDifference = player2Score - player1Score;

        if (scoreDifference == 0)
        {
            zeiger.transform.position = new Vector3(0, 3);
        }

        if (scoreDifference > 0 && scoreDifference <= 50)
        {
            zeiger.transform.position = new Vector3(1, 3);
        }

        if (scoreDifference > 50)
        {
            zeiger.transform.position = new Vector3(1.9f, 3);
        }

        if (scoreDifference < 0 && scoreDifference >= -50)
        {
            zeiger.transform.position = new Vector3(-1, 3);
        }

        if (scoreDifference < -50)
        {
            zeiger.transform.position = new Vector3(-1.9f, 3);
        }
    }
}