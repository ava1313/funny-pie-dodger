using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Tracks the player's score, handles UI updates and manages the game state.
/// </summary>
public class GameManager : MonoBehaviour
{
    // Singleton instance so other scripts can easily access the GameManager
    public static GameManager Instance;

    // Reference to the UI text displaying the score
    public Text scoreText;

    // Reference to the UI text displayed when the game ends
    public Text gameOverText;

    // Reference to the UI text prompting the player to restart
    public Text restartText;

    // Current score, measured as seconds survived
    private float score;

    // Whether the game is over
    private bool gameOver;

    /// <summary>
    /// Property to let other scripts check if the game has ended.
    /// </summary>
    public bool IsGameOver => gameOver;

    void Awake()
    {
        // Implement the singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        score = 0f;
        gameOver = false;

        // Hide game over and restart texts at the start
        if (gameOverText != null) gameOverText.gameObject.SetActive(false);
        if (restartText != null) restartText.gameObject.SetActive(false);
    }

    void Update()
    {
        // If the game is over, listen for the restart key
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            return;
        }

        // Increment the score based on elapsed time
        score += Time.deltaTime;
        UpdateUI();
    }

    /// <summary>
    /// Refreshes the score text on the screen.
    /// </summary>
    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(score);
        }
    }

    /// <summary>
    /// Called when the player collides with a pie. Ends the game and shows UI messages.
    /// </summary>
    public void GameOver()
    {
        if (gameOver) return;
        gameOver = true;

        // Show a humorous message
        if (gameOverText != null)
        {
            gameOverText.text = "Oops! You got pied! 🍰";
            gameOverText.gameObject.SetActive(true);
        }
        if (restartText != null)
        {
            restartText.text = "Press R to try again.";
            restartText.gameObject.SetActive(true);
        }
    }
}
