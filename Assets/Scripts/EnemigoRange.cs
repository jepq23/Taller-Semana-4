using UnityEngine;

public class EnemigoRange : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Transform jugador;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private GameObject prefabProyectil;

    [Header("Disparo")]
    [SerializeField] private float rangoAtaque = 8f;
    [SerializeField] private float cadenciaDisparo = 1.5f;
    [SerializeField] private float velocidadProyectil = 20f;

    private float temporizadorDisparo;

    private void Awake()
    {
        if (jugador == null)
        {
            GameObject objJugador = GameObject.FindGameObjectWithTag("Player");
            if (objJugador != null) jugador = objJugador.transform;
        }
    }

    private void Update()
    {
        if (jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= rangoAtaque)
        {
            temporizadorDisparo -= Time.deltaTime;
            if (temporizadorDisparo <= 0f)
            {
                Disparar();
                temporizadorDisparo = cadenciaDisparo;
            }
        }
    }

    private void Disparar()
    {
        if (prefabProyectil == null || puntoDisparo == null) return;

        Vector3 direccionDisparo = (jugador.position - puntoDisparo.position).normalized;
        GameObject proyectil = Instantiate(prefabProyectil, puntoDisparo.position, Quaternion.LookRotation(direccionDisparo));

        if (proyectil.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.velocity = direccionDisparo * velocidadProyectil;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }
}