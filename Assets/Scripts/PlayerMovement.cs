using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Este codigo hace que el jugador no sea invalido
    //PD: hace que se mueva el jugador

    private Rigidbody2D rb2D; //Referencia al RigidBody

    private float horizontal; //Variables para la direccion y velocidad
    private float vertical;
    public float speed;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed; //Si se oprime el boton correcto el jugador se movera
        vertical = Input.GetAxisRaw("Vertical") * speed;

    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(horizontal, vertical);
    }
}