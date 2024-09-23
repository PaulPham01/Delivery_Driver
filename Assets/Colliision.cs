using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliision : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1); 
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log("Goalll...");
        if (other.tag == "Package" && hasPackage == false)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }   
        
        if (other.tag == "Customer")
        {
            if (hasPackage == true)
                {
                    Debug.Log("Package delivered");
                    hasPackage = false;
                    spriteRenderer.color = noPackageColor;
                }
            else
            {
                Debug.Log("You dont has the Package");   
            }
        }  
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
