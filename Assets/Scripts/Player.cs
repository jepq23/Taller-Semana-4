using UnityEngine;

public class Player : MonoBehaviour
{
    private int vida;
    private int daño;

    public Jugador(int vida, int daño)
    {
        this.vida = vida;
        this.daño = daño;
    }

    public void RecibirDaño(int cantidadDaño)
    {
        vida -= cantidadDaño;
    }

    public int GetDaño()
    {
        return daño;
    }
}
