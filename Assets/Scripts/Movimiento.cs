using UnityEngine;

public class Movimiento : MonoBehaviour
{
    protected Rigidbody rb;
    [SerializeField] protected float velocidad;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
}