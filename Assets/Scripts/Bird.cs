using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class Bird : MonoBehaviour
{
    private Vector3 cameraPosition;

    private Vector3 IntialPosition;

    private Vector3 DirectionPosition;
    [SerializeField] float force;

    private Rigidbody2D Physics;

    private SpriteRenderer ColourChange;

    private bool ButtonRelease;

    private float TimeCount;

    private float TimeCountforColourChange;

    private bool ChangeToWhite;

    private LineRenderer line;

    private bool RandomMovement;

    private float a;

    public float cha;
    
    bool floating = true;

   // Start is called before the first frame update
    void Start()
    {
     
        IntialPosition = transform.position;
        Physics = GetComponent<Rigidbody2D>();
        ColourChange = GetComponent<SpriteRenderer>();
        line = GetComponent<LineRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (RandomMovement)
        {
            transform.position = new Vector3();
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, IntialPosition);
        
        PlayerReset();

        ColourChanger();

        Floating();
    }

    private void OnMouseUp()
    {
        DirectionPosition = IntialPosition - transform.position;
        Physics.AddForce(DirectionPosition * force);
        Physics.gravityScale = 1;
        ButtonRelease = true;
        ChangeToWhite = true;
        line.enabled = false;
    }
    
    private void OnMouseDrag()
    {
        TimeCountforColourChange = 0;
        ChangeToWhite = false;
        ColourChange.color = Color.red;
        cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cameraPosition.x, cameraPosition.y, 0f);
        line.enabled = true;
        floating = false;
        
    }


    void ColourChanger()
    {
        if (ButtonRelease && ChangeToWhite)
            TimeCountforColourChange += Time.deltaTime;
        if (TimeCountforColourChange > cha)
        {
            ColourChange.color = Color.white;
        }
        
           
    }
    
    void PlayerReset()
    {

        if (transform.position.y > 9.09 ||
            transform.position.y < -9.30 ||
            transform.position.x > 13.37 ||
            transform.position.x < -13.44 ||
            (ButtonRelease && Physics.velocity.magnitude <= 0.1f))
        {
            TimeCount += Time.deltaTime;
            if (TimeCount > 2.5f)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Floating()
    {
        if (floating)
        {
            transform.position += new Vector3(Random.Range(-1f, 1f), Random.Range(-2f, 2f), 0f) * Time.deltaTime;
        }
    }
}
