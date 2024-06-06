using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using YG;

public class Enemy : MonoBehaviour, IDamageble
{
    Transform targetDestination;
    GameObject targetGameobject;
    Character targetCharacter;
    [SerializeField] float speed = 2;

    public int maxHealth = 100;
    int currentHealth;

    [SerializeField] int damage = 1;
    [SerializeField] int experienceReward = 100;

    [SerializeField] List<GameObject> dropItemPrefab;
    [SerializeField][Range(0f, 1f)] float chance = 1f;

    public Animator animator;

    Rigidbody2D rgdbd2d;

    private SpriteRenderer spriteRenderer;

    public List<AudioClip> EnemyDieSoungList;
    private AudioClip EnemyDieSoung;
    MusicManager musicManager;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        musicManager = FindObjectOfType<MusicManager>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameobject = target;
        targetDestination = target.transform;
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        speed = 0;
        Invoke("UnFreeze", 1);

        if (currentHealth <= 0)
        {
            if (Random.value < chance)
            {
                GameObject toDrop = dropItemPrefab[Random.Range(0, dropItemPrefab.Count)];
                Transform t = Instantiate(toDrop).transform;
                t.position = transform.position;
            }
            Die();

        }
    }

    private void UnFreeze()
    {
        speed = 2;
    }

    void Die()
    {
        EnemyDieSoung = EnemyDieSoungList[Random.Range(0, 2)];
        musicManager.Play(EnemyDieSoung);


        animator.SetBool("isDead", true);

        targetGameobject.GetComponent<Level>().AddExperience(experienceReward);

        GetComponent<Collider2D>().enabled = false;
        this.enabled= false;
        Invoke("DeleteObject", 2);
    }

     void DeleteObject()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity= direction * speed;

        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0) 
        {
            spriteRenderer.flipX = true;
        }
        
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameobject)
        {
            Attack();
        }
    }
     
    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameobject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(damage);
    }


}
