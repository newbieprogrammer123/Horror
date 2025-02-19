using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float speedWalk, speedRun, timeAttack;

    private Player player;

    private float speedMove;
    private Animation animation;
    private bool isMove;

    private GameObject canvasObject;

    private float currentTimeAttack;

    public Player SetPlayer
    {
        set
        {
            player = value;
        }
    }

    private void Start()
    {
        animation = GetComponent<Animation>();
        canvasObject = GetComponentInChildren<Canvas>().gameObject;

        ShowAnimation(TypeAnimation.Idle);

        Invoke(nameof(MoveToPlayer), 2f);
        Invoke(nameof(RunToPlayer), 8f);
    }

    private void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                player.transform.position, speedMove * Time.deltaTime);
        }

        if(currentTimeAttack > 0)
        {
            isMove = true;
            currentTimeAttack -= Time.deltaTime;
        }

        transform.LookAt(player.transform.position);
        canvasObject.transform.LookAt(player.transform.position);
    }

    private void MoveToPlayer()
    {
        ShowAnimation(TypeAnimation.Walk);
        isMove = true;

        speedMove = speedWalk;
    }

    private void RunToPlayer()
    {
        ShowAnimation(TypeAnimation.Run);
        isMove = true;

        speedMove = speedRun;
    }

    private void ShowAnimation(TypeAnimation type)
    {
        animation.Play(type.ToString());
    }

    protected override void Death()
    {
        ShowAnimation(TypeAnimation.Death);
        isMove = false;

        EnemiesController.Instance.EnemyDeath();

        Invoke(nameof(Destroy), 1f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            GetDamage(10);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartAttack();
        }
    }

    private void StartAttack()
    {
        if (currentTimeAttack <= 0)
        {
            isMove = false;
            currentTimeAttack = timeAttack;

            ShowAnimation(TypeAnimation.Attack1);

            player.GetDamage(35);
        }
    }
}

public enum TypeAnimation
{
    Idle, 
    Walk,
    Run,
    Attack1,
    Death
}
