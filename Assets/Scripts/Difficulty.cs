using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [SerializeField]
    private float difficultyStep = 0.05f;
    private Score score;
    private AsteroidSpawn asteroidSpawn;

    private void Start()
    {
        score = this.GetComponent<Score>();
        asteroidSpawn = this.GetComponent<AsteroidSpawn>();
    }

    public void DifficultyUpdate()
    {
        if ((score.countScore % 50) == 0)
        {
            if (asteroidSpawn.spawnRate > 0.1)
            {
                asteroidSpawn.spawnRate -= difficultyStep;
                Debug.Log(asteroidSpawn.spawnRate);
            }
        }
    }
}
