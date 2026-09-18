using UnityEngine;

public class EnemigoMelee : Enemy
{
    //El constructor debe recibir la vida que tiene y daño que puede causar
    protected float hp;
    protected float dmg;
    public EnemigoMelee(float vida, float causarDaño)
    {
        this.hp = vida;
        this.dmg = causarDaño;
    }

    //Debe tener un método que le permita recibir daño
    public override void GetDamage(float daño)
    {
        float enemigo_daño = hp - daño;
        hp = enemigo_daño;
    }

    //Debe tener un método que retorne el daño que puede causar 
    public override float Attack()
    {
        return dmg;
    }

    //Debe tener un método que retorne si está vivo o muerto 
    public override bool IsDead()
    {
        return hp > 0;
    }
}