using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject complete;
    public GameObject menuGameOver;
    public bool gameOver = false;
    public bool start = false;
    public bool levelComplete = false;

    //public Renderer fondo;
    public float velocidad = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        start = true;
        menuGameOver.SetActive(false);
        complete.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }
        if(start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene( SceneManager.GetActiveScene().name );
            }
        }
        if(start == true && gameOver == false)
        {
            //menuPrincipal.SetActive(false);
            //fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;
            
        }

        if(levelComplete)
        {
            complete.SetActive(true);
            //menuPrincipal.SetActive(false);
            //fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;
            
        }
    }
}