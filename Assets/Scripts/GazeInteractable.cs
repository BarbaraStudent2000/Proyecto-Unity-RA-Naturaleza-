using UnityEngine;
public class GazeInteractable : MonoBehaviour
{
    public float gazeTime = 2f; // Tiempo que el usuario debe mirar el objeto
    public AudioSource audioSource; // Fuente de audio que se reproducirá
    private float gazeTimer = 0f; // Contador para el tiempo que el usuario ha mirado el objeto
    private bool isGazing = false; // Controla si el usuario está mirando el objeto
                                // Método que se llama cuando el usuario empieza a mirar el objeto
    public void StartGaze()
    {
        isGazing = true;
        gazeTimer = 0f; // Reinicia el contador
    }
    // Método que se llama cuando el usuario deja de mirar el objeto
    public void StopGaze()
    {
        isGazing = false;
        gazeTimer = 0f; // Reinicia el contador
    }
    private void Update()
    {
        if (isGazing)
        {
            gazeTimer += Time.deltaTime; // Incrementa el tiempo que el usuario ha mirado el objeto
        // Si el usuario ha mirado el objeto el tiempo suficiente
 if (gazeTimer >= gazeTime)
            {
                ActivateInteraction();
                gazeTimer = 0f; // Reinicia el contador
            }
        }
    }
    // Activa la interacción (por ejemplo, reproduce un sonido)
    private void ActivateInteraction()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}