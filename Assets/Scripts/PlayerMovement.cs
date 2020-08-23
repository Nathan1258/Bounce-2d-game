using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    private bool readyToJump;
    public int staminaToAdd = 50;
    private GameObject ballClick;

    private Rigidbody2D rb;

    //Visuals
    public GameObject sprite;
    private TrailRenderer trailRenderer;
    private Vector3 squashScale, defaultScale;
    private Vector3 velSquash;
    public LineRenderer lr;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ballClick = GameObject.Find("Ball Click Area");
        
        rb = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        readyToJump = false;
        squashScale = new Vector3(0.8f, 0.6f, 1f);
        defaultScale = sprite.transform.localScale;

       
        trailRenderer.time = 2;
        trailRenderer.material.color = Color.white;
        trailRenderer.startWidth = 0.1f;
        trailRenderer.endWidth = 0.1f;
        trailRenderer.enabled = true;
    }

    private void LateUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.name == ballClick.gameObject.name && Input.GetMouseButton(0))
            {
                Debug.Log(readyToJump);
                readyToJump = true;
            }
        }

        startTrajectory();
    }

    public void accelerateUp()
    {
        rb.AddForce(Vector2.up * 10);
    }


    private void startTrajectory()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && readyToJump == true)
        {
            lr.enabled = true;
            toggleSlowMo(true);
            DrawLine(mousepos);
            readyToJump = true;

            sprite.transform.localScale = Vector3.SmoothDamp(sprite.transform.localScale, squashScale, ref velSquash, 0.2f);

            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
            lookPos = lookPos - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            sprite.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            BounceSystem.instance.isUsingSlowmo = true;
        }

        if (Input.GetMouseButtonUp(0) && readyToJump == true)
        {
            lr.enabled = false;

            //Time.timeScale = 1;
            toggleSlowMo(false);

            Vector3 ballFingerDiff = mousepos - sprite.transform.position;               

            Vector2 shotForce = new Vector2(ballFingerDiff.x * 3, ballFingerDiff.y * 3);   

            rb.velocity = shotForce;

            sprite.transform.localScale = defaultScale;

            readyToJump = false;
            BounceSystem.instance.isUsingSlowmo = false;
        }
    }

    private void DrawLine(Vector3 mousepos)
    {
        Vector3 startPos = sprite.transform.position;
        Vector3 endPos = mousepos;
        float maxDist = 3;
        Vector3 dir = endPos - startPos;
        float dist = Mathf.Clamp(Vector3.Distance(startPos, endPos), 0, maxDist);

        endPos = startPos + (dir.normalized * dist);
        lr.SetPosition(0, startPos);
        lr.SetPosition(1, endPos);
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.startColor = Color.white;
        lr.endColor = Color.clear;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BounceSystem.instance.addStamina(staminaToAdd);
    }

    private void toggleSlowMo(bool state)
    {
        if (state)
        {
            // Toggle slow Mo
            Time.timeScale = 0.05f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
        else
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02F;
        }
    }
}
