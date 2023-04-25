using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mosca : MonoBehaviour
{
    Vector3 initialPosition;
    public int livesCount = 3;
    public TextMeshProUGUI txtLives;
    public TextMeshProUGUI txtLives2;
    public int scorePoint;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        txtLives.text = livesCount.ToString();
    }

    private void Update()
    {
      
    }


    //Destruir la mosca si colisiona con el ventilador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            LoseALife(); 
        } 
        else if (collision.gameObject.name == "moneda")
        {
            ScorePoint();
            Destroy(collision.gameObject);
        }
    }

    void LoseALife()
    {
        transform.position = initialPosition;
        livesCount--;
        txtLives.text = livesCount.ToString();
        if (livesCount == 0)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    { 
        Destroy(gameObject);
    }

    void ScorePoint()
    {
        scorePoint++;
        txtLives2.text= scorePoint.ToString();

    }
}
