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

    public GameState state = GameState.Playing;

    public static GameManager Instance { get; private set; }
    public TMP_Text scoreText, ammoText, resultText;

    //public int score = 0;
    public int targetScore = 3;
    public int startingAmmo = 10;

    private int score, ammo, projectilesInFlight;
    private void Start()
    {
        ammo = startingAmmo;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score + "/" + targetScore;
        ammoText.text = "Ammo: " + ammo;
        resultText.text = state == GameState.Won ? "YOU WIN!" : state == GameState.Lost ? "GAME OVER!" : "";
    }
    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }
    public void AddScore(int points)
    {
        if (state != GameState.Playing) return;
        score += points;
        if(score >= targetScore) { state = GameState.Won; }
        UpdateUI();
    }

    public bool CanShoot()
    {
        return state == GameState.Playing && ammo > 0;
    }

    public void shotFired()
    {
        if (!CanShoot()) return;
        ammo--;
        projectilesInFlight++;
        UpdateUI();
    }

    public void ProjectileFinished()
    {
        projectilesInFlight = Mathf.Max(projectilesInFlight - 1, 0);
        if(state == GameState.Playing && ammo == 0 && projectilesInFlight == 0)
        {
            state = GameState.Lost;
            UpdateUI();
        }
    }
}