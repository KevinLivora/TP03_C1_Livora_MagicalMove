using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;
    [SerializeField] private KeyCode rotationRight = KeyCode.E;
    [SerializeField] private KeyCode rotationLeft = KeyCode.Q;
    [SerializeField] public float moveSpeed = 1f;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimientos

        if (Input.GetKey(moveUp))
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(moveRight))
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(moveDown))
        {
            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(moveLeft))
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0);
        }

        // Rotación

        if (Input.GetKeyDown(rotationRight))
        {
            transform.Rotate(0f, 0f, -10f);
        }
        if (Input.GetKeyDown(rotationLeft))
        {
            transform.Rotate(0f, 0f, 10f);
        }

        // Cambio de Color

        float r = Random.value;
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        if (Input.GetKeyUp(KeyCode.R))
        {
            spriteRenderer.color = new Color(r, g, b); 
        }
    }
}
