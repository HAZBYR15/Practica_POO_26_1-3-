using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ControlBola : MonoBehaviour
{
    //Fuerza con la que se lanza la bola
    public float fuerzaDeLanzamiento = 1000f;
    //Velocidad y limites de apuntado
    public float velocidaddeApuntado = 5f;
    public float limiteIzquierdo = -3f;
    public float limiteDerecho = 2f;

    //Referencias internas
    private Rigidbody rb;
    private bool haSidoLanzada = false;

    //REferencia ala camara y score
    public CamaraFollow cameraFollow;
    public ScoreManager scoreManager;

    void Start()
    
        {
            rb = GetComponent<Rigidbody>();
        }
    private void Update()
    {
        if (!haSidoLanzada) {
            Apuntar();
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                LanzarBola(),
                    }
        }
    }
    void apuntar()
    {
        float inputHorizontal = Input.GetAxis("Horizontal")
            transform.Translate(Vector3.right * inputHorizontal * velocidaddeApuntado * Time.deltaTime);
        Vector3 posicionActual = transform.position;
        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);
        transform.position = posicionActual;
    }
    void Lanzar()
    {
        haSidoLanzada = true;
        rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);
        if (cameraFollow != null) cameraFollow.IniciarSeguimiento();
        

        void OnCollisionEnter(Collision collision)
        {
            
            if (collision.gameObject.CompareTag("Pin"))
            {

                if (cameraFollow != null) cameraFollow.DetenerSeguimiento();

               
                 if (scoreManager != null) Invoke("Calcular puntaje", 2f);
            }
        }
        void CalcularPuntaje()
        {
            //PISTA:Llamar al scoreManager para actualizar puntos
            scoreManager.CalcularPuntaje();
        }
    }

