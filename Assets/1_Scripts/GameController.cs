using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : Singletone<GameController>
{
    [SerializeField] private Player player;
    [SerializeField] private EndGameWindow endGameWindow;
    [SerializeField] private Text countEnemyText;
    [SerializeField] private Text enemyCountText;

    private int enemyCount;

    private void Start()
    {
        countEnemyText.text = enemyCount.ToString();
        enemyCountText.text = enemyCount.ToString();
    }

    public void PlayerDeath()
    {
        endGameWindow.ShowWindow();
    }
    public void RestartGame()
    {
        int numberScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(numberScene);
    }

    public void CountEnemy()
    {
        enemyCount += 1;
        countEnemyText.text = enemyCount.ToString();
        enemyCountText.text = enemyCount.ToString();
    }
}
