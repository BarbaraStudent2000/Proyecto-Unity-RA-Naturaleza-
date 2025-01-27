using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 2f; // Velocidad de caminata
    public float sprintSpeed = 4f; // Velocidad de sprint
    public float mouseSensitivity = 2f; // Sensibilidad del mouse
    public float jumpHeight = 2f; // Altura del salto
    private bool isMoving = false;
    private bool isSprinting = false;
    private float yRotation; // Rotación en el eje Y

    private Animator anim;
    private Rigidbody rigidBody;

    void Start()
    {
        playerSpeed = 2f; // Velocidad inicial
        anim = GetComponent<Animator>(); // Conectar el Animator (opcional)
        rigidBody = GetComponent<Rigidbody>(); // Conectar el Rigidbody
    }

    void Update()
    {
        // Rotación con el mouse
        yRotation += Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yRotation, transform.localEulerAngles.z);

        // Movimiento horizontal y vertical (WASD)
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D (o izquierda/derecha)
        float verticalInput = Input.GetAxis("Vertical"); // W/S (o adelante/atrás)

        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        moveDirection.Normalize(); // Para que la diagonal no sea más rápida

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        // Aplica movimiento con MovePosition (para evitar interferencia de la física)
        Vector3 newPosition = rigidBody.position + moveDirection * playerSpeed * Time.deltaTime;
        rigidBody.MovePosition(newPosition);

        // Sprint (Shift)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = sprintSpeed;
            isSprinting = true;
        }
        else
        {
            playerSpeed = 2f; // Regresa a la velocidad de caminata
            isSprinting = false;
        }

        // Saltar (espacio)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Mathf.Abs(rigidBody.velocity.y) < 0.01f) // Asegúrate de que esté en el suelo
            {
                rigidBody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }
        }

        // Configura la animación (opcional)
        if (anim != null)
        {
            anim.SetBool("isMoving", isMoving);
            anim.SetBool("isSprinting", isSprinting);
        }
    }
}
