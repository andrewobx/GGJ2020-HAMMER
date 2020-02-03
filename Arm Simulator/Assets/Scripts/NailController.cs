using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NailController : MonoBehaviour
{

    public string nextScene;
    public float maxHeight;
    public float minHeight;
    public Canvas restartScreen;

    SpringJoint joint;
    Rigidbody rb;
    
    bool lost;
    bool won;
    bool endFlag;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        joint = GetComponent<SpringJoint>();

        won = false;
        lost = false;
        endFlag = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 position = this.transform.position;
        // Debug.Log(position.y);

        if (this.transform.position.y < minHeight && !won)
        {
            won = true;
            endFlag = true;
        }

        if (this.transform.position.y > maxHeight && !lost)
        {
            lost = true;
            endFlag = true;
        }

        if (lost && endFlag)
        {
            // turn into normal object
            joint.breakForce = 0;
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
            this.gameObject.layer = LayerMask.NameToLayer("Hammer");
            StartCoroutine(restartAfterTime(1f));

            endFlag = false;
        }

        if(won && endFlag)
        {
            StartCoroutine(winAfterTime(5f));

            endFlag = false;
        }

    }

    IEnumerator winAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator restartAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        restartScreen.gameObject.SetActive(true);
    }

}
