using UnityEngine;
using UnityEngine.UI;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet {  get; set; }
    [field: SerializeField] public Transform ShootPoint {  get; set; }
    [field: SerializeField] public float ReloadTime {  get; set; }
    [field: SerializeField] public float WaitTime {  get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hp.maxValue = 100;
        base.Initialized(100);
        ReloadTime = 1.0f;
        WaitTime = 0.0f;

    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        Hp.value = Health;
        Shoot();
    }

    public void Shoot()
    {
       
        //if (Input.GetKeyDown("Fire1") && WaitTime >= ReloadTime)
        if (Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime) 
        {
            var buller = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = buller.GetComponent<Banana>();
            if(banana != null) 
                banana.InitWeapon(20,this);

            WaitTime = 0.0f;
            
        }
    }
    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHitWith(enemy);
            Debug.Log($"{this.name} collides with {enemy.name}!");
        }
    }

}
