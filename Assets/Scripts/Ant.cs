using UnityEngine;

public class Ant : Enemy
{
    [SerializeField]Vector2 velocity;
    public Transform[] MovePoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Initialized(20);
    }

    public override void Behavior()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
