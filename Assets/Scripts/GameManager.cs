using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
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
}
