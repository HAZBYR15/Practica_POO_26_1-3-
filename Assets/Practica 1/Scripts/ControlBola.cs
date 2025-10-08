using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBola : MonoBehaviour
{
    public Rigidbody rb;
    public float fuerzaDeLanzamiento = 1000f;
    public float velocidadMovimiento = 10f;

    [Header("Cámara")]
    public Transform camara;
    public float suavizadoCamara = 5f;
    public Vector3 offsetCamara = new Vector3(0f, 5f, -10f);

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        if (camara == null && Camera.main != null)
        {
            camara = Camera.main.transform;
        }
    }

    void Update()
    {
        // Movimiento con WASD
        float moverH = Input.GetAxis("Horizontal"); // A (-1) / D (+1)
        float moverV = Input.GetAxis("Vertical");   // S (-1) / W (+1)

        Vector3 movimiento = new Vector3(moverH, 0f, moverV) * velocidadMovimiento;
        rb.AddForce(movimiento);

        // Lanzamiento hacia adelante con espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);
        }

        // Seguimiento de cámara
        if (camara != null)
        {
            Vector3 posicionDeseada = transform.position + offsetCamara;
            camara.position = Vector3.Lerp(camara.position, posicionDeseada, suavizadoCamara * Time.deltaTime);
            camara.LookAt(transform);
        }
    }
}
