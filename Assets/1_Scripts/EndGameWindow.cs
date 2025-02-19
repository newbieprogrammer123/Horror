using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameWindow : MonoBehaviour
{
    [SerializeField] private GameObject substrate;
    [SerializeField] private Text endGameText;
    [SerializeField] private Button restartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(() => GameController.Instance.RestartGame());
    }

    public void ShowWindow()
    {
        endGameText.text = "You lose!";
        substrate.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}
