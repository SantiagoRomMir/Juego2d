using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
	// comentario desde maquina virtual 
       if(collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<PlayerControl>().GetDamage();
        }
        collision.gameObject.transform.position=collision.gameObject.GetComponent<PlayerControl>().lastPosition;
    }
}
