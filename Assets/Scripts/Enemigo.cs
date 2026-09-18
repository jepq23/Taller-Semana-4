using UnityEngine;

public class Enemigo : Movimiento
{
    public float hp;
    public float dmg;

    public Enemy(float hp, float dmg)
    {
        this.hp = hp;
        this.dmg = dmg;
    }

    public virtual float Attack()
    {
        return dmg;
    }

    public virtual void GetDamage(Player p)
    {
        //se le resta el daño que causa el jugador (cambiar nombres de variables si es necesario)
        hp -= p.dmg;
        //se verifica si el enemigo está muerto o no
        IsDead();
    }

    public virtual bool IsDead()
    {
        if (hp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {
        rb.linearVelocity = Vector3.forward * velocidad;
    }
}
