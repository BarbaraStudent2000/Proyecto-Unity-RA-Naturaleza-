using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float sensitivity = 2f; // Sensibilidad del mouse

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        // Movimiento con el teclado
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime; // A/D o flechas
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime; // W/S o flechas
        transform.Translate(moveX, 0, moveZ);

        // Rotación con el mouse
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f); // Limita la rotación vertical

        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }
}
