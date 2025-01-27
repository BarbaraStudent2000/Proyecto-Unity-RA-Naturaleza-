using UnityEngine;
public class GazeRaycaster : MonoBehaviour
{
    public float maxDistance = 10f; // Distancia máxima del rayo
    private GazeInteractable currentGazeObject;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward); // Lanza el rayo desde la cámara hacia adelante
    RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Verifica si el objeto tiene el componente GazeInteractable
            GazeInteractable gazeObject = hit.collider.GetComponent<GazeInteractable>();
            if (gazeObject != null)
            {
                if (gazeObject != currentGazeObject)
                {
                    if (currentGazeObject != null)
                    {
                        currentGazeObject.StopGaze();
                    }
                    currentGazeObject = gazeObject;
                    currentGazeObject.StartGaze();
                }
            }
            else
            {
                ClearCurrentGazeObject();
            }
        }
        else
        {
            ClearCurrentGazeObject();
        }
    }
    private void ClearCurrentGazeObject()
    {
        if (currentGazeObject != null)
        {
            currentGazeObject.StopGaze();
            currentGazeObject = null;
        }
    }
}
