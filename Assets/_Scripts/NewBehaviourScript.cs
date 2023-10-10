using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;

    public float xAxyx, yAxyx;

    private Rigidbody2D rb;

    public GameObject coin;

    public GameObject enemyPrefab;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(Vector3.left * speed);

        coin = GameObject.FindGameObjectWithTag("coin");
        Debug.Log(coin.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        xAxyx = Input.GetAxis("Horizontal");
        yAxyx = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(xAxyx, yAxyx, 0) * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision With " + collision.gameObject.name);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Exit With " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter With " + collision.gameObject.name);
       
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            for (int i = 0; i < 5; i++)
            {
               GameObject newEnemy = Instantiate(enemyPrefab, Vector3.right * i * 5, Quaternion.identity);
                Destroy(newEnemy, 5f);
            }
        }
    }
}

