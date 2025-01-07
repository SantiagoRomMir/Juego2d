using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int speedX;
    private Rigidbody2D phisics;
    private SpriteRenderer sprite;
    public int damage;

    private int money;
    public int JumpForce;
    public int life;
    private int currentLife;
    private int saltos;
    public Vector3 lastPosition;
    public Canvas HUD;
    private bool invulnerable;
    private ControlHud controlHud;
    private Animator anim;
    private bool canControl = true;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = life;
        phisics = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        controlHud = HUD.GetComponent<ControlHud>();
        controlHud.SetLife(currentLife, life);
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
        {
            float inputX = Input.GetAxis("Horizontal");

            phisics.velocity = new Vector2(inputX * speedX, phisics.velocity.y);
            anim.SetFloat("ValvelX", phisics.velocity.magnitude);
            anim.SetFloat("velY", phisics.velocity.y);
        }
        if (phisics.velocity.x < -0f)
        {
            sprite.flipX = true;
        }
        else if (phisics.velocity.x > 0f)
        {
            sprite.flipX = false;
        }
        TouchingFloor();
        if (TouchingFloor())
        {
            anim.SetBool("tocandoSuelo", true);
        }
        else
        {
            anim.SetBool("tocandoSuelo", false);
        }
        if (Input.GetKeyDown(KeyCode.Z) && TouchingFloor())
        {
            Attack();
        }

        Jump();
    }
    private bool TouchingFloor()
    {
        RaycastHit2D touch = Physics2D.Raycast(transform.position + new Vector3(0, -2.1f, 0), Vector2.down, 0.4f);
        if (touch.collider != null && !touch.collider.gameObject.CompareTag("Player"))
        {
            saltos = 0;
            if (!touch.collider.gameObject.CompareTag("Trap"))
            {
                lastPosition = gameObject.transform.position;
            }
        }
        return touch.collider != null;
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && saltos == 0)
        {
            phisics.velocity = new Vector2(phisics.velocity.x, 0);
            phisics.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            saltos++;
        }
    }
    public void GetDamage()
    {
        if (!invulnerable)
        {
            currentLife--;
            controlHud.SetLife(currentLife, life);
            invulnerable = true;
            Invoke("MakeVulnerable", 1f);
        }

    }
    private void MakeVulnerable()
    {
        invulnerable = false;
    }
    public void AddMoney(int Money)
    {
        money += Money;
        controlHud.SetMoney(money);
    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(StopCharacter());
    }
    private IEnumerator StopCharacter()
    {
        canControl = false;
        phisics.velocity = new Vector2(0, phisics.velocity.y);
        yield return new WaitForSeconds(0.75f);
        canControl = true;
    }
    public void Hit()
    {
        RaycastHit2D touch;
        if (sprite.flipX == false)
        {
            touch = Physics2D.Raycast(transform.position + new Vector3(0.95f, 0, 0), Vector2.right, 3.2f);
        }
        else
        {
            touch = Physics2D.Raycast(transform.position + new Vector3(-0.95f, 0, 0), Vector2.right, -3.2f);
        }
        if (touch.transform != null && touch.transform.gameObject.CompareTag("Enemy"))
        {
            touch.transform.gameObject.GetComponent<ControlEnemy>().getDamage(damage);
        }
    }
}

