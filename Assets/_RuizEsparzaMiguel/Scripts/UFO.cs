using UnityEngine;

public class UFO : MonoBehaviour
{
    [Header("Movement")]
    public float amplitude = 0.5f;
    public float frequency = 1f;

    private Vector3 startPos;

    [Header("Material")]
    public Material material;     
    public string propertyName = "_Transition";
    public float transitionSpeed = 1f;
    public float waitTime = 2f;

    private bool goingUp = true;
    private float value = 0f;
    private float waitCounter = 0f;
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Movimiento
        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
        
        if (waitCounter > 0)
        {
            waitCounter -= Time.deltaTime;
            return;
        }

        // Movimiento suave entre 0 y 1
        value += (goingUp ? 1 : -1) * transitionSpeed * Time.deltaTime;
        value = Mathf.Clamp01(value);
        material.SetFloat(propertyName, value);

        // Cuando llegamos a un extremo, invertimos la dirección y esperamos
        if (value == 1f || value == 0f)
        {
            goingUp = !goingUp;
            waitCounter = waitTime;
        }
    }
}
