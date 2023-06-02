using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health { get; set; }
    public float Speed { get; set; }

    public Animator Animator { get; set; }

    //if enemy can attack
    //bool IsAttacking = false;
    //public double Damage { get; set; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Init(GameObject gameObject)
    {

    }


}
