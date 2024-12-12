
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    public float speedEenemy;
    private float posInitial;
    private int stop=1;
    public float posEnd;
    private float direction;
    private bool movetoEnd = true;
    private SpriteRenderer sprite;
    private Rigidbody2D phisics;
    private Animator anim;
    public int life;
    public GameObject[] drop;
    private int numeroDrop;
    // Start is called before the first frame update
    void Start()
    {
        posInitial=transform.position.x;
        sprite=gameObject.GetComponent<SpriteRenderer>();
        direction=-1;
        phisics=gameObject.GetComponent<Rigidbody2D>();
        anim=gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
        Movement(); 
        StartAttacking();
        flipEnemy();
    }
    private void StartAttacking(){
        RaycastHit2D touch;
        if(sprite.flipX){
            touch = Physics2D.Raycast(transform.position+new Vector3(1.5f,0,0),Vector2.down,0.2f);
        }else{
            touch = Physics2D.Raycast(transform.position+new Vector3(-1.5f,0,0),Vector2.down,0.2f);
        }
        if(touch.collider != null){
            if(touch.collider.gameObject.CompareTag("Player")){
                StartCoroutine(Attack());        
            }
        }
    }
    private void Movement(){
        
        phisics.velocity = new Vector2(direction*speedEenemy*stop,phisics.velocity.y);
        
        if(posEnd<posInitial){
            if(transform.position.x<posEnd && movetoEnd==true){
                direction*=-1;
                movetoEnd=false;
            }
            if(transform.position.x>posInitial && movetoEnd==false){
                direction*=-1;
                movetoEnd=true;
            }
        }else{
            if(transform.position.x>posEnd && movetoEnd==true){
                direction*=-1;
                movetoEnd=false;
            }
            if(transform.position.x<posInitial && movetoEnd==false) 
            {
                direction*=-1;
                movetoEnd=true;
            }
        }
    }
    private IEnumerator Attack(){
        
        anim.SetTrigger("Attack"); 
        stop=0;
        yield return new WaitWhile(Attacking);
        yield return new WaitForSeconds(0.5f);
        stop=1;
    }
    private bool Attacking(){
        return anim.GetBool("Attack");
    }
    private void flipEnemy(){
        if(phisics.velocity.x<-0f){
            sprite.flipX=false;
        }else if(phisics.velocity.x>0f){
            sprite.flipX=true;
        }
    }
    public void Hit(){
        RaycastHit2D touch;
         if(sprite.flipX){
            touch = Physics2D.Raycast(transform.position+new Vector3(1.5f,0,0),Vector2.down,0.2f);
        }else{
            touch = Physics2D.Raycast(transform.position+new Vector3(-1.5f,0,0),Vector2.down,0.2f);
        }
        if(touch.collider != null){
            if(touch.collider.gameObject.CompareTag("Player")){
                touch.collider.gameObject.GetComponent<PlayerControl>().GetDamage();
            }
        }
    }
    public void RandomDrop(){
        numeroDrop=Random.Range(0,5);
        switch (numeroDrop)
        {
            case 0:
                Instantiate(drop[numeroDrop],transform.position,Quaternion.identity);
                break;
            case 1:
                Instantiate(drop[numeroDrop],transform.position,Quaternion.identity);
                break;
            case 2:
                Instantiate(drop[numeroDrop],transform.position,Quaternion.identity);
                break;
            case 3:
                Instantiate(drop[numeroDrop],transform.position,Quaternion.identity);
                break;
            case 4:
                Instantiate(drop[numeroDrop],transform.position,Quaternion.identity);
                break;
            default:
            break;
        }
    }
    public void getDamage(int damage){
        life-=damage;
        if(life<=0){
            Destroy(gameObject);
        }
    }
}
