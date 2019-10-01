using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YouWinMenu : MonoBehaviour
{
    public static YouWinMenu Instance;
    public GameObject container;
    public Button nextLevelButton;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        nextLevelButton.onClick.AddListener(HandleNextLevelPressed);
    }

    private void OnDisable()
    {
        nextLevelButton.onClick.RemoveListener(HandleNextLevelPressed);
    }

    void HandleNextLevelPressed()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (Application.CanStreamedLevelBeLoaded(nextSceneIndex))
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("NO MORE LEVELS");
        }
    }

    public void Show()
    {
        container.SetActive(true);
    }

    public void Hide()
    {
        container.SetActive(false);
    }
}
