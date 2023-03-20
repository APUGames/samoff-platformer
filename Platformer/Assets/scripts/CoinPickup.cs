using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] CapsuleCollider2D playerBodyCollider;
    [SerializeField] int coinValue = 100;
    [SerializeField] AudioClip coinPickupSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == playerBodyCollider)
        {
            FindObjectOfType<GameSession>().ProcessPlayerScore(coinValue);

            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
