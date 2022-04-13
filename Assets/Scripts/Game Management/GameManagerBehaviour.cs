using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{
    /// <summary>
    /// A reference to the ball used during the game
    /// </summary>
    [SerializeField]
    GameBallBehaviour _gameBall;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Red Score"))
            PlayerPrefs.SetInt("Red Score", 0);
        if (!PlayerPrefs.HasKey("Blue Score"))
            PlayerPrefs.SetInt("Blue Score", 0);

    }

    private void Update()
    {
        if (_gameBall.RedPoint)
        {
            int redScore = PlayerPrefs.GetInt("Red Score");
            PlayerPrefs.SetInt("Red Score", redScore + 1);
        }

        if (_gameBall.BluePoint)
        {
            int blueScore = PlayerPrefs.GetInt("Blue Score");
            PlayerPrefs.SetInt("Blue Score", blueScore + 1);
        }

        if (_gameBall.RedPoint || _gameBall.BluePoint)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
