using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float LifeTime = 2f;

    private GameManager GameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        //Autodestrucción al pasar 2 segundos
        Destroy(gameObject, LifeTime);
        GameManagerScript = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Bad"))
        {
            GameManagerScript.GameOver = true;
        }
    }

    private void OnDestroy()
    {
        GameManagerScript.TargetPositions.Remove(transform.position);
    }
}
