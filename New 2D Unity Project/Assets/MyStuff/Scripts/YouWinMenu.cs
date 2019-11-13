using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class YouWinMenu : MonoBehaviour
{
    public static YouWinMenu Instance;
    public GameObject container;
    public Button nextLevelButton;
    public Button dismissButton;
    public TextMeshProUGUI winMessage;

    private float _animationSpeed = .25f;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        nextLevelButton.onClick.AddListener(HandleNextLevelPressed);
        dismissButton.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        nextLevelButton.onClick.RemoveListener(HandleNextLevelPressed);
        dismissButton.onClick.RemoveListener(Hide);
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
        transform.localScale = Vector3.zero;
        transform.DOScale(1, _animationSpeed).SetEase(Ease.OutBack);
        StartCoroutine(ShowNextButton());
    }

    public void Show(string message)
    {
        container.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, _animationSpeed).SetEase(Ease.OutBack);
        StartCoroutine(ShowNextButton());
        winMessage.SetText(message);
    }

    public void Hide()
    {
        container.SetActive(false);
    }

    private IEnumerator ShowNextButton()
    {
        nextLevelButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        nextLevelButton.gameObject.SetActive(true);
        nextLevelButton.transform.DOShakeScale(_animationSpeed, 1, 10, 90, true);
    }
}
