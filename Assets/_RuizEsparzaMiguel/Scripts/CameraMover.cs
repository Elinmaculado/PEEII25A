using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Header("Lerp Mode")]
    public float lerpSpeed = 3f;
    public Transform startPosition;
    private Transform target;

    [Header("Free Look Mode")]
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 10.0f;
    private float rotationX = 0f;
    private float rotationY = 0f;


    [Header("Mode")]
    public bool freeLook = false; // Si es false, usa Lerp; si es true, usa free camera.

    void Start()
    {
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation;
    }

    void Update()
    {
        if (freeLook)
        {
            HandleFreeLook();
        }
        else
        {
            HandleLerp();
        }
    }

    // --- Lógica para Lerp ---
    void HandleLerp()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * lerpSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * lerpSpeed);
        }
    }

    // --- Lógica para Cámara libre ---
    void HandleFreeLook()
    {
        float horizontalAxis = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        float verticalAxis = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        float lookX = Input.GetAxis("Mouse X") * rotationSpeed;
        float lookY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Movimiento
        transform.Translate(horizontalAxis, 0, verticalAxis);

        // Acumular rotaciones sin límites
        rotationY += lookX;
        rotationX -= lookY;

        // Aplicar como Quaternion para evitar problemas de ejes
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
    }

    // --- Cambiar el target ---
    public void MoveToTarget(Transform newTarget)
    {
        target = newTarget;
        freeLook = false; // al moverse a un punto, desactiva el modo libre
    }

    // --- Activar modo libre ---
    public void SetFreeLook()
    {
        if (!freeLook)
            freeLook = true;
        else
            freeLook = false;
    }
}