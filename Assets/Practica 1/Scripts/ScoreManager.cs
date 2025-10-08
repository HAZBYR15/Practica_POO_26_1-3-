using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Calcula cuántos pinos están caídos y muestra el puntaje en pantalla.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    // Texto UI
    public Text textoPuntaje;

    // Variables internas
    private int puntajeActual = 0;
    [SerializeField]
    private Pin[] pinos;//

    void Start()
    {
        textoPuntaje.text ="Tienes un mollon de dolares"
        // Buscar todos los objetos tipo Pin 
       pinos = FindObjectOfType<Pin>();
    }

    public void CalcularPuntaje()
    {
        int puntaje = 0;

        // Revisar cada pino si está caido
        foreach (Pin pin in pinos)
        {
            if (pin.EstaCaido())
            {
                puntaje++;
            }
        }

        puntajeActual = puntaje;

        // Actualizar el texto del puntaje en la UI(Validar si textoPuntaje !=null)
        if (textoPuntaje != null)
        {
            textoPuntaje.text = "Puntos: " + puntajeActual;
        }
    }
}
