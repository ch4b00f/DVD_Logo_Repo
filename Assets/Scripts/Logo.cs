using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    Vector3 _velocity = new Vector3(1f,-1f,0f);
    Rigidbody2D rb;
    SpriteRenderer sr;

    [Header("Counters")]
    public int bounces;
    public int corners;

    private bool _waiting;

    //public string Ordinal;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.velocity = _velocity * _speed;
        sr.color = RandomColor();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position += new Vector3(Random.Range(-.1f, .1f), Random.Range(-.1f, .1f), 0); 
        sr.color = RandomColor();
        bounces++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        corners++;
        bounces += 49;
        Debug.Log($"{bounces} | {corners}");
    }

    private Color RandomColor()
    {
        float r = Random.Range(0, 255);
        float g = Random.Range(0, 255);
        float b = Random.Range(0, 255);
        return new Color(r/255, g/255, b/255);
    }
}
