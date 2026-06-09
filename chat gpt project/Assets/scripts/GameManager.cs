using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;

    private float survivalTime = 0f;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        survivalTime += Time.deltaTime;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public int GetScore()
    {
        return score;
    }

    public float GetSurvivalTime()
    {
        return survivalTime;
    }

    public float GetDifficultyMultiplier()
    {
        // Increases by 10% every 30 seconds
        return 1f + (GetSurvivalTime() / 30f) * 0.1f;
    }
}