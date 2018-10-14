using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementController : MonoBehaviour
{
    public string HorizontalAxisName;
    public string VerticalAxisName;

    public bool IsPlayerOne;

    public float Speed = 5;

    private ScoreManager ScoreManager;

    private void Start()
    {
        var hintergrund = GameObject.FindGameObjectWithTag("GameController");
        if (hintergrund != null)
        {
            ScoreManager = hintergrund.GetComponent<ScoreManager>();
        }

        if (ScoreManager == null)
        {
            Debug.Log("ScoreManager konnte nicht gefunden werden.");
        }
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
        if (otherObject.gameObject.tag == "Wall")
        {
            return;
        }

        Destroy(otherObject.gameObject);

        var scoreToAdd = 0;

        switch (otherObject.gameObject.tag)
        {
            case "CollectableZuckerwatte":
                scoreToAdd = 1;
                break;
            case "CollectableZuckerwatte3P":
                scoreToAdd = 3;
                break;
            case "CollectableKotze":
                scoreToAdd = -2;
                break;
        }

        if (IsPlayerOne)
        {
            ScoreManager.UpdatePlayer1Score(scoreToAdd);
        }
        else
        {
            ScoreManager.UpdatePlayer2Score(scoreToAdd);
        }
    }
}