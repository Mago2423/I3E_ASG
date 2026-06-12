using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text HealthText;
    public TMP_Text GameOver;
    public Button StartButton;
    public TMP_Text ItemText;
    public TMP_Text CoinsText;
    public TMP_Text StartText;
    public TMP_Text TimerText;
    public GameObject MenuPanel;
    public GameObject MainUI;
    public float elapsedTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreText.text = "Score: 0";
        HealthText.text = "Health: 100";
        ItemText.text = "Items Collected: 0";
        CoinsText.text = "Coins Collected: 0";
        GameOver.text = "Game";
        StartText.text = "Start";
        TimerText.text = "Time: 0";
        StartButton.gameObject.SetActive(true);
        MainUI.SetActive(false);

        if (MenuPanel.activeSelf)
        {
            Time.timeScale = 0f;  // Pause everything
        }
        else
        {
            Time.timeScale = 1f;  // Resume normal speed
        }
        
        Cursor.visible = MenuPanel.activeSelf;
        Cursor.lockState = MenuPanel.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
    }

    void Update()
    {
        if (Time.timeScale > 0)  // Only update if game is running
        {
            elapsedTime += Time.deltaTime;
        }
        TimerText.text = $"Time: {Mathf.FloorToInt(elapsedTime)}s";
    }
    // Update is called once per frame
    public void UpdateScore(int score)
    {
        ScoreText.text = $"Score: {score}";
    }

    public void UpdateHealth(int health)
    {
        HealthText.text = $"Health: {health}";
        if (health <= 0)
            {   
                HealthText.text = $"Health: 0";
                print("Game Over");
                Gameover();
            }
    }

    public void ItemCollected(int collected)
    {
        ItemText.text = $"Items Collected: {collected}/10";
        if (collected >= 10)
        {
            print("You have collected all the items!");
            GameOver.text = "Head to the exit door!";
            TogglePanel();
        }
    }

    public void CoinsCollected(int coinsCollected)
    {
        CoinsText.text = $"Coins Collected: {coinsCollected}/10";
        if (coinsCollected >= 10)
        {
            print("You have collected all the coins!");
            GameOver.text = "You have collected all the coins!";
            TogglePanel();
        }
    }

    public void TogglePanel()
    {
        MenuPanel.SetActive(!MenuPanel.activeSelf);
        print($"MenuPanel is now: {MenuPanel.activeSelf}");

        MainUI.SetActive(!MainUI.activeSelf);
        print($"MainUI is now: {MainUI.activeSelf}");
        
        // Pause/unpause the game
        if (MenuPanel.activeSelf)
        {
            Time.timeScale = 0f;  // Pause everything
        }
        else
        {
            Time.timeScale = 1f;  // Resume normal speed
        }
        
        Cursor.visible = MenuPanel.activeSelf;
        Cursor.lockState = MenuPanel.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void Gameover()
    {
        GameOver.text = "Game Over";
        StartButton.gameObject.SetActive(false);
        TogglePanel();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnStartButtonClick()
    {
        print("Start Button Clicked");
        StartText.text = "Resume";
        TogglePanel();
    }
}
