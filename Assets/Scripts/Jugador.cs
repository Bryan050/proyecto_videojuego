using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float fuerzaSalto;
    private float horizontal;
    private bool isFacingRight = false;
    private Animator animator;

    private float velocidad = 8f;
    private Transform groundCheck;
    private LayerMask groudLayer;
    public GameManager gameManager;
    public byte numJumps = 0;
    private bool isJumping = false;
    private static int puntos = 0;
    public Text impPuntos;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) && numJumps != 2){
            numJumps +=1;
            isJumping = true;
            rigidbody2D.AddForce(new Vector2(0,fuerzaSalto));
        }
        if((horizontal > 0.1f || horizontal < -0.1f) && isJumping == false){
            animator.SetBool("estaCorriendo", true);
        }else{
            animator.SetBool("estaCorriendo", false);
        }
        Flip();
    }

    private void FixedUpdate() {
        rigidbody2D.velocity = new Vector2(horizontal * velocidad, rigidbody2D.velocity.y);
    }

    private void Flip(){
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "plataforma"){
            isJumping = false;
            numJumps = 0;
        }
        if (collision.gameObject.tag == "obstaculo")
        {
            gameManager.gameOver = true;
        }

        if (collision.gameObject.tag == "bandera")
        {
            gameManager.levelComplete = true;
        }

        if (collision.gameObject.tag == "moneda")
        {
            Destroy(collision.gameObject);
            puntos+=1;
            impPuntos.text = puntos.ToString();
        }
        
    }

    /*private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Pies")){
            isJumping = false;
            numJumps = 0;
        }
    }*/
}
