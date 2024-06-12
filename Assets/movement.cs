using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    public int keysCollected = 0;
    public TMP_Text countText;

    void Start(){
        body = GetComponent<Rigidbody2D>();
    }

    void Update(){
        countText.text = keysCollected.ToString();

        if(Input.GetKey("left"))
        {
            body.velocity = new Vector3(-speed,body.velocity.y,0);
            Debug.Log("left");
        }
        else if(Input.GetKey("right"))
        {
            body.velocity = new Vector3(speed,body.velocity.y,0);
            Debug.Log("right");
        }
        else{
            body.velocity = new Vector3(0,body.velocity.y,0);
        }

        if(Input.GetKey("up"))
        {
            body.velocity = new Vector3(body.velocity.x,speed,0);
            Debug.Log("up");
        }
        else if(Input.GetKey("down"))
        {
            body.velocity = new Vector3(body.velocity.x,-speed,0);
            Debug.Log("down");
        }
        else{
            body.velocity = new Vector3(body.velocity.x,0,0);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.GetComponent<Key>() != null){
            keysCollected += 1;
            Destroy(c.gameObject);
        }

        if(c.gameObject.GetComponent<Lock>() != null){
            if(keysCollected >= c.gameObject.GetComponent<Lock>().keysNeeded){
                SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
            }
        }
    }
}
