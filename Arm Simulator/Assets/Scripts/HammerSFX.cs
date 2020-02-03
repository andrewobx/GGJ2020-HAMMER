using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerSFX : MonoBehaviour
{


    public AudioClip nail;
    public AudioClip nailTwo;
    public AudioClip wood;
    public AudioClip woodTwo;

    int count;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        count = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "nail" && count % 2 == 0)
        {
            Debug.Log("nail");
            audioSource.PlayOneShot(nail, 0.7F);
            count++;
        }
        else if (collision.gameObject.tag == "nail" && count % 2 != 0)
        {
            Debug.Log("nailTwo");

            audioSource.PlayOneShot(nailTwo, 0.7F);
            count++;
        }
        if (collision.gameObject.tag == "wood" && count % 2 == 0)
        {
            Debug.Log("wood");

            audioSource.PlayOneShot(wood, 0.7F);
            count++;
        }
        else if (collision.gameObject.tag == "wood" && count % 2 != 0)
        {
            Debug.Log("woodTwo");

            audioSource.PlayOneShot(woodTwo, 0.7F);
            count++;
        }
    }

}
