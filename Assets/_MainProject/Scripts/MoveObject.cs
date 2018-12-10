using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoveObject : MonoBehaviour {


    float distance;
    public float throwForce = 300;
    float disableHold = 1.0f;


    public GameObject item;
    public GameObject tempParent;
    public Transform guide;

    public bool isHolding = false;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "guide")
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        item.GetComponent<Rigidbody>().useGravity = true;
        item = gameObject;
        tempParent = GameObject.Find("guide");
        guide = GameObject.FindWithTag("guide").transform;
        
    }

    // Update is called once per frame
    void Update () {

        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x/2, transform.rotation.eulerAngles.y/2, 0);


        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if(distance >= 0.6f)
        {
            isHolding = false;
            item.transform.parent = null;
            //Invoke("isHolding", disableHold);
        }

        if (isHolding == true)
        {
            if(distance <= 0.6f)
            {
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().detectCollisions = true;

                //item.GetComponent<Rigidbody>().isKinematic = true;
                //item.transform.position = guide.transform.position;
                //item.transform.rotation = guide.transform.rotation;
                item.transform.parent = tempParent.transform;

                item.GetComponent<Rigidbody>().velocity = Vector3.zero;
                item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                /*if (item.GetComponent<Rigidbody>().detectCollisions == false)
                {

                }*/
            }

            if (Input.GetMouseButtonDown(1))
            {
                isHolding = false;
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
            }

        }
        else
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            //item.GetComponent<Rigidbody>().isKinematic = false;
            

        }
	}

    void OnTriggerEnter(Collider other)
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;

    }

    private void OnMouseDown()
    {
        isHolding = true;
        /*item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;

        //item.GetComponent<Rigidbody>().isKinematic = true;
        //item.transform.position = guide.transform.position;
        //item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;

        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;*/

    }
    void OnMouseUp()
    {
        isHolding = false;

        //item.GetComponent<Rigidbody>().useGravity = true;
        //item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        //item.transform.position = guide.transform.position;
    }
}
