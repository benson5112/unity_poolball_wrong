using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class hall : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private static int count, i = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void SetCountText()
    {
        countText.text = "count : " + count.ToString();
        if(i >= 8)
        {
            winTextObject.SetActive(true);
        }
    }
    
    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("dynamiccollider"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            i = i + 1;

            SetCountText();
        }
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position= new Vector3((float)0,(float)0.5,(float)0);
            Rigidbody rb= other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            count = count - 1;

            SetCountText();
        }
        
    }
}
