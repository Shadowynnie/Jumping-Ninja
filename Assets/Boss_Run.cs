using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    //public float speed = 2.5f;
    public float attackRange = 3f;
    public float shootInterval = 5f; // Time interval for shooting Rasengan

    private float nextShootTime = 0f; // Time when the boss can shoot again

    Transform player;
    Rigidbody2D rb;
    static Boss boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        nextShootTime = Time.time + shootInterval;

        Debug.Log("Boss movement speed: " + Boss.movementSpeed);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, Boss.movementSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            // Boss attacks the player - play attack animation of the boss
        }
        else
        {
            if (Time.time >= nextShootTime)
            {
                boss.StartShootingCoroutine(); // Call the method to start the shooting coroutine
                nextShootTime = Time.time + shootInterval + 3 * boss.bossAttack.shootDelay; // Reset the shoot timer with added time for shooting sequence
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
