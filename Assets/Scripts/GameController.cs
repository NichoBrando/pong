using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int player1Score = 0;
    private int player2Score = 0;

    [SerializeField]
    private Text score;

    public void updateScore(bool wasMadeByPlayer1)
    {
        if(wasMadeByPlayer1) player1Score++;
        else player2Score++;

        score.text = $"{player1Score} - {player2Score}";
    }
}
