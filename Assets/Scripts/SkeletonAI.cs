using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    public float speed = 0.05f;

    Transform player_pos;
    Animator anim;
    bool IsAtacking = true;
    float meleeRange = 1.3f;
    

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        player_pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = player_pos.position - transform.position;
        direction.y = 0;
        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);

        if (direction.magnitude > meleeRange)
        {
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsIdle", false);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (direction.magnitude <= meleeRange)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsAttacking", true);
            anim.SetBool("IsIdle", false);
        }

    }
}
