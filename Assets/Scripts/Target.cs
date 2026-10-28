using UnityEngine;
public class Target : MonoBehaviour
{
    //public static int score = 0;
    public int maxHealth = 3;
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void Hit()
    {
        currentHealth--;
        Debug.Log("Health remaining: " + currentHealth);
        if (currentHealth <= 0)
        {
            //score++;
            GameManager.Instance.AddScore(1);
            //Debug.Log("Target destroyed! Score: " + score);
            Debug.Log("Score: " + GameManager.Instance.score);
            Destroy(gameObject);
        }
    }
}