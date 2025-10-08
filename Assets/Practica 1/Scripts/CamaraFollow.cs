using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    //TODO:Referencia al objetivo(bola)
    public Transform objetivo;

    //TODO: Offset o separacion entre la camara y el objetivo
    public Vector3 offset = new Vector3(0f, 3f, -6f);

    //Cualquier variable que esta en privado queda protegido
    //TODO:VAriable para activar o desactivar el seguimiento
    private bool seguir = false;


    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //PISTA:Solo seguir si esta activado y el objetivo esta correctamente referenciado
        if (seguir && objetivo != null)
        {
            //PISTA:Posicionar camara con offset
            transform.position = objetivo.position + offset;
        }
    }

    //PISTA: Metodo para iniciar seguimiento
    public void IniciarSeguimiento()
    {
        seguir = true;
    }
    //PISTA : Metodo para detener seguimiento
    public void DetenerSeguimiento()
    {
        seguir = false;
    }
}
