using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange;
    public int attackDamage;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public int damageBonus;

    public List <AudioClip> playerAttackSoundList;
    private AudioClip playerAttackSound;
    MusicManager musicManager;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void Awake()
    {
        attackRange = GetComponent<Character>().attackRange;
        attackDamage = GetComponent<Character>().attackDamage;
        musicManager = FindObjectOfType<MusicManager>();

    }

    private void Start()
    {
        damageBonus = GetComponent<Character>().damageBonus;
        attackDamage += damageBonus;
    }

    void Attack()
    {
        attackRange = GetComponent<Character>().attackRange;//non effective
        attackDamage = GetComponent<Character>().attackDamage + damageBonus;//non effective

        animator.SetTrigger("AttackTrigger");

        playerAttackSound = playerAttackSoundList[Random.Range(0,2)];
        musicManager.Play(playerAttackSound);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<IDamageble>().TakeDamage(attackDamage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) 
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
