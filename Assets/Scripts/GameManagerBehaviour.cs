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

    private void Update()
    {
        if (_gameBall.RedPoint || _gameBall.BluePoint)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
