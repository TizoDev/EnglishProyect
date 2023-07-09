using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    //Este script controla el ataque sobre posicionamiento de bloques
    //Debe ir en el boton de respuesta

    public bool playerContact = false; 
    public bool[] correct; //Guarda los valores de las respuestas
    public DuolingoResponse duolingo;
    public SpriteRenderer SP;

    void Start()
    {
        SP = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if(playerContact) SP.color = new Color32(255, 100, 0, 255); //Para cambiar el color en contacto con el jugador
        else SP.color = new Color32(255, 173, 0, 255);

        if(Input.GetKeyDown("space") && playerContact) //Si el jugador oprime el boton
        {
            if(correct[0] == true && correct[1] == true && correct[2] == true && correct[3] == true) //Si todas las respuestas son correctas
            {
                duolingo.isCorrect = true;  //Se le enviara a duolingo que el resultado es correcto
                duolingo.call = true;
                Debug.Log("CORRECTO");
            }

            else
            {
                duolingo.isCorrect = false; //Se enviara que es falso
                duolingo.call = true;
                Debug.Log("INCORRECTO");
            }
        }
    }

    public void addAnswer(int id, bool isCorrect) //Funcion para cambiar la respuesta desde otro script
    {
        correct[id] = isCorrect;
    }

    private void OnTriggerEnter2D(Collider2D other) //Para detectar si el jugador entro en contacto o no con el boton
    {
        if(other.gameObject.CompareTag("Player") )
        {
            playerContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerContact = false;
    }
}
