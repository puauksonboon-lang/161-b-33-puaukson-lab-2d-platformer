using UnityEngine;
using UnityEngine.UI;
public abstract class Character : MonoBehaviour
{
    public Slider Hp;

    private int health;
    public int Health 
    {  get { return health; } set { health = (value < 0) ? 0 : value; } }

    protected Animator anim;
    protected Rigidbody2D rb;

    public void Initialized(int startHealth)
    {
        Health = startHealth;
        Debug.Log($"{this.name} is Initialized Health : {this.Health}");

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took damage {damage}. Current Health: {Health}");
        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;

        }
        else { return false; }
    
    }
   
}
