using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour
{ 
    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private string _scoreName;

    private void Update()
    {
        int score = PlayerPrefs.GetInt(_scoreName);
        _scoreText.text = $"{_scoreName}: {score}";
    }
}
