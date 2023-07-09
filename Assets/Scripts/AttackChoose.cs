using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackChoose : MonoBehaviour
{
    //Este codigo es el encargado de controlar la mecanica del ataque de elegir la respuesta correcta
    //Este script va a los botones de las opciones

    public bool correctAnswer; //Variables para analizar si es correcta o no, y si ya la respondio o no
    public bool answered = false;
    public DuolingoResponse duolingo; //Referencias a objetos
    public SpriteRenderer SP;

    public bool playerContact = false;

    void Start()
    {
        SP = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(playerContact && !answered) SP.color = new Color32(255, 100, 0, 255); //Si el jugador esta en contacto con el boton sin apretarlo va a cambiar el color del boton
        else if(!answered) SP.color = new Color32(255, 173, 0, 255);

        if(correctAnswer && Input.GetKeyDown("space") && playerContact) //Si el jugador esta en contacto y el boton es correcto
            {
                duolingo.isCorrect = true; //Va a avisarle al script de Duolingo que la respuesta es correcta
                duolingo.call = true;
                Debug.Log("CORRECTO");

                answered = true; //Y va a cambiar el color
                SP.color = new Color32(23, 255, 0, 255);
            }
        else if(!correctAnswer && Input.GetKeyDown("space") && playerContact) //Si no va a avisarle a duoligno que es falsa
            {
                duolingo.isCorrect = false;
                duolingo.call = true;
                Debug.Log("INCORRECTO");
            }
    }

    private void OnTriggerEnter2D(Collider2D other) //En contacto con el jugador
    {
        if(other.gameObject.CompareTag("Player") )
        {
            playerContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) //Al terminar el contacto con el jugador
    {
        playerContact = false;
    }
}
