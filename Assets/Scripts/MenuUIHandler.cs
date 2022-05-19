using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _startText;
    [SerializeField] private TMP_InputField _nameText;

    private void Start()
    {
        //yield return new WaitForSeconds(3.0f);

        if (!String.IsNullOrEmpty(DataManager.Instance.RecordPlayerName))
        {
            _startText.text = "Best Score: " + DataManager.Instance.RecordPlayerName + " = " + DataManager.Instance.Score;
        }
        else
        {
            _startText.text = "Best Score: ";
        }
    }

    public void StartGame()
    {
        if (String.IsNullOrEmpty(_nameText.text))
        {
            Debug.Log("Nome vazio");
        }
        else
        {
            DataManager.Instance.PlayerName = _nameText.text;

            SceneManager.LoadSceneAsync(1);
        }
    }

    public void QuitApplication()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
