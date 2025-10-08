using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

<summary>
</summary>

public class Pin : MonoBehaviour
{
    // Umbral de Inclinacion
    private float umbralCaida = 5f;

    public bool EstaCaido()
    {
        float angulo = Vector3.Angle(transform.up, Vector3 3.up);

        return angulo > umbralCaida;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
