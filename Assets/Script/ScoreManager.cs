using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel; 
    [SerializeField]public AudioClip gameOverSound; 
    public AudioSource audioSource; 

    private int score = 0; 
    private bool isGameOver = false;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
        gameOverPanel.SetActive(false); 
    }

    
    public void AddScore(int points)
    {
        if (isGameOver) return;

        score += points;
        UpdateScoreUI();

        
        if (score <= -20)
        {
            GameOver();
        }
    }

    
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    
    private void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);

        Time.timeScale = 0;
        audioSource.PlayOneShot(gameOverSound);
    }

    
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    
    public void QuitGame()
    {
        Application.Quit(); 
    }
}

