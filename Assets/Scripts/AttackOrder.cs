using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOrder : MonoBehaviour
{
    //Este codigo controla el como se comportan los bloques
    //Debe ir en cada bloque y en la posicion final de cada bloque

    public bool isWord; //Define si es un bloque o la posicion a donde debe estar
    public OrderManager orderManager; //Referencia al controlador general
    public int id; //ID unica que comparten un bloque y una posicion
    private AttackOrder wordScript; //Referencias
    private Rigidbody2D wordRB2D;
    public SpriteRenderer SP;
    private BoxCollider2D BC2D;

    void Start()
    {
        BC2D = GetComponent<BoxCollider2D>();
        SP = GetComponent<SpriteRenderer>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) //Al entrar en una colision
    {
        if(!isWord && other.gameObject.GetComponent<AttackOrder>() != null ) //Si el objeto que entro en colision tambien tiene el script y este objeto es una posicion y no un bloque
        {
            wordScript = other.gameObject.GetComponent<AttackOrder>(); //Se guardara este mismo script pero el del bloque
            if(id == wordScript.id) //Si la id coincide
            {
                orderManager.addAnswer(id, true); //Se enviara al OrderManager que la respuesta es correcta
            }

            else orderManager.addAnswer(id, false); //Se enviara que es falsa

            other.gameObject.transform.position = gameObject.transform.position; //Se freezara el bloque en la posicion final
            wordRB2D = other.gameObject.GetComponent<Rigidbody2D>(); 
            wordRB2D.constraints = RigidbodyConstraints2D.FreezePosition;

            SP.enabled = false; //Se desabilitara el boxcollider de este objeto y su renderizador de sprites
            BC2D.enabled = false;
        }
    }
}
