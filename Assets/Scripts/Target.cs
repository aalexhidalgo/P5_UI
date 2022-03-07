using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float LifeTime = 2f;
    [SerializeField] private int Points;

    public ParticleSystem ExplosionParticle;

    private GameManager GameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        //Autodestrucción al pasar 2 segundos
        GameManagerScript = FindObjectOfType<GameManager>();
        LifeTime = GameManagerScript.SpawnRate;
        Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!GameManagerScript.GameOver)
        {
            GameManagerScript.UpdateScore(Points);
            Instantiate(ExplosionParticle, transform.position, ExplosionParticle.transform.rotation);

            Destroy(gameObject);
            if (gameObject.CompareTag("Bad"))
            {
                GameManagerScript.IsGameOver();
            }
        }
    }

    private void OnDestroy()
    {
        GameManagerScript.TargetPositions.Remove(transform.position);
    }
}
