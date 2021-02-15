using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonStart : MonoBehaviour
{

    private Button button;

    public static event Action<int> OnLoadLevel = delegate { };

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button != null)
            button.onClick.AddListener(() => StartGame());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartGame();
    }

    private void StartGame()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        OnLoadLevel(index);
    }
}



