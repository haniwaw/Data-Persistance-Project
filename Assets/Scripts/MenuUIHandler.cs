using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text playerNameInput;
    public Text bestScoreText;

    private void Start()
    {
        bestScoreText.text = $"Best Score: {ResultManager.Instance.highScorePlayerName} : {ResultManager.Instance.highScore}";
    }

    public void StartNew()
    {
        ResultManager.Instance.currentPlayerName = playerNameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
