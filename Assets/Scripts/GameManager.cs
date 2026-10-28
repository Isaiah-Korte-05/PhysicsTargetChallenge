using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        Won,
        Lost
    }

    public GameState currentState = GameState.Playing;

    public static GameManager Instance;
    public TMP_Text scoreText;
    public TMP_Text ammoText;

    public int score = 0;
    public int targetScore = 3;

    public int ammo = 15;
    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        ammoText.text = "Ammo: " + ammo;
    }
    void Awake()
    {
        Instance = this;
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
        //Debug.Log("Score: " + score);
        if (score >= targetScore)
        {
            currentState = GameState.Won;
            Debug.Log("You Win!");
        }
    }

    public bool CanShoot()
    {
        return currentState == GameState.Playing && ammo > 0;
    }

    public void UseAmmo()
    {
        ammo--;
        UpdateUI();
        if (ammo == 0 && score < targetScore)
        {
            currentState = GameState.Lost;
            Debug.Log("Game Over!");
        }
    }
}