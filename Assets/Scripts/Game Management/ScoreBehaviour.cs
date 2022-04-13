using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Can be added to a text element to change the text to a score
/// </summary>
public class ScoreBehaviour : MonoBehaviour
{ 
    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private string _scoreName;

    private void Update()
    {
        //Changes the text of the UI element
        int score = PlayerPrefs.GetInt(_scoreName);
        _scoreText.text = $"{_scoreName}: {score}";
    }
}
