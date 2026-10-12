using UnityEngine;

public class pj : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 7f;

    public bool isGrounded = false;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(0, 0, speed));
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, 0, -speed));
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-speed, 0, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(speed, 0, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dito"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.AddItem();
        }
    }

}
