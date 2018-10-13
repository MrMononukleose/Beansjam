using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementController : MonoBehaviour
{
    public string HorizontalAxisName;
    public string VerticalAxisName;

    public float Speed = 10;

    public Text ScoreText;
    public int Score;

    private void Start()
    {
        Score = 0;
        UpdateScore();
    }

    private void FixedUpdate()
    {
        var horizontalInput = Input.GetAxisRaw(HorizontalAxisName);
        var verticalInput = Input.GetAxisRaw(VerticalAxisName);

        var directionVector = new Vector2(horizontalInput, verticalInput);

        GetComponent<Rigidbody2D>().velocity = directionVector.normalized * Speed;
    }

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject.tag == "Collectable")
        {
            Destroy(otherObject.gameObject);
            AddScore(10);
        }

        Console.WriteLine("Test");
    }

    private void AddScore(int newScoreValue)
    {
        Score += newScoreValue;
        UpdateScore();
    }

    private void UpdateScore()
    {
        ScoreText.text = "Punkte: " + Score;
    }
}