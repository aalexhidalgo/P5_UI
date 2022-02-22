using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] TargetPrefabs;
    public List<Vector3> TargetPositions;

    private float MinX = -3.75f;
    private float MinY = -3.75f;
    private float DistanceBetweenSquares = 2.5f;

    private float SpawnRate = 2f;
    private Vector3 RandomPos;
    public bool GameOver;

    //Variable que accede a TextMeshPro
    public TextMeshProUGUI ScoreText;
    private int Score = 0;

    //Panel de GAME OVER
    public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        //Accedemos a nuestra UI de puntuación
        ScoreText.text = $"Score: {Score}";
        GameOverPanel.SetActive(false);
        StartCoroutine(SpawnRandomTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 RandomSpawnPosition()
    {
        int SaltosX = Random.Range(0, 4);
        int SaltosY = Random.Range(0, 4);

        float SpawnPosx = MinX + SaltosX * DistanceBetweenSquares;
        float SpawnPosY = MinY + SaltosY * DistanceBetweenSquares;
        return new Vector3 (SpawnPosx, SpawnPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        while(!GameOver)
        {
            yield return new WaitForSeconds(SpawnRate);
            int RandomIndex = Random.Range(0, TargetPrefabs.Length);
            RandomPos = RandomSpawnPosition();
            while (TargetPositions.Contains(RandomPos))
            {
                RandomPos = RandomSpawnPosition();
            }
            Instantiate(TargetPrefabs[RandomIndex], RandomSpawnPosition(), TargetPrefabs[RandomIndex].transform.rotation);
            TargetPositions.Add(RandomPos);
        }
    }

    public void UpdateScore(int PointsToAdd)
    {
        Score += PointsToAdd;
        ScoreText.text = $"Score: {Score}";
    }

    public void IsGameOver()
    {
        GameOver = true;
        GameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
