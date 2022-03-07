using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button MyButton;
    public int Difficulty;

    private GameManager GameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        //Accedemos a los botones y a su dificultad
        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(SetDifficulty);

        GameManagerScript = FindObjectOfType<GameManager>();
    }

    //Dificultad, cada vez que le damos iniciamos el juego con una dificultad diferente
    public void SetDifficulty()
    {
        GameManagerScript.StartGame(Difficulty);
    }
}
