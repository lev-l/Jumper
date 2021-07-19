using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelsLoader : MonoBehaviour
{
    public string LoadLevel;
    public Vector2 LoadPosition;
    public LoadingPosition PositionContainer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PositionContainer.LoadPosition = LoadPosition;
        SceneManager.LoadScene(LoadLevel);
    }
}
