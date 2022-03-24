using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PickupVR : MonoBehaviour
{
    Grabbable grabbable = null;
    IPickup pickupable = null;


    Grabbable pregrabbable = null;

    int debugCounter = 0;

    public IEnumerator BindPickup(IPickup _pickupable)
    {
        yield return new WaitForSeconds(0.1f);

        //Debug
        //FindObjectOfType<DebugScript>().GetComponent<Text>().text = "InsideBindPickup";

        pickupable = _pickupable;

        Collider collider = gameObject.GetComponent<Collider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider>();
        }

        Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
        if (rigidBody == null)
        {
            rigidBody = gameObject.AddComponent<Rigidbody>();
        }

        //GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<Rigidbody>().isKinematic = true;

        grabbable = gameObject.GetComponent<Grabbable>();
        if (grabbable == null)
        {
            grabbable = gameObject.AddComponent<Grabbable>();
        }


        grabbable.GrabButton = GrabButton.Trigger;
        grabbable.Grabtype = HoldType.HoldDown;


        //replace by OculusQuest2 Andrew Code
        /*
        Collider collider = gameObject.GetComponent<Collider>();
        if (collider==null)
        {
            collider = gameObject.AddComponent<BoxCollider>();
        }

        Throwable throwable = gameObject.GetComponent<Throwable>();
        if (throwable == null)
        {
            throwable = gameObject.AddComponent<Throwable>();
        }

        throwable.onPickUp = new UnityEvent();// Work Around 
        throwable.onDetachFromHand = new UnityEvent();// Work Around 

        throwable.onPickUp.AddListener(pickupable.Pickup);
        throwable.onDetachFromHand.AddListener(pickupable.Detach);

        GetComponent<Rigidbody>().mass = 1;
        GetComponent<Rigidbody>().drag = 5;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        */
    }

    private void Update()
    {

        if (grabbable == null) return;


        if (grabbable.BeingHeld)
        {

            if (pregrabbable != grabbable)
            {
                debugCounter++;
                pickupable.Pickup();


            }

            //Debug
            //FindObjectOfType<DebugScript>().GetComponent<Text>().text = "ObjectGrabbed "+ debugCounter;

            pregrabbable = grabbable;

        }
        else
        {
            if (pregrabbable != null)
                pickupable.Detach();

            pregrabbable = null;

            debugCounter = 0;
            //Debug
            //FindObjectOfType<DebugScript>().GetComponent<Text>().text = "ObjectUnGrabbed " + debugCounter;

        }
    }

    public void RemovePickup(IPickup snappable)
    {


        //Debug
        //FindObjectOfType<DebugScript>().GetComponent<Text>().text = "DestroyIt " ;

        //DestroyImmediate(GetComponent<Grabbable>());

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;

        DestroyImmediate(this);

        //OculusQuest2 Andrew
        /*
        GetComponent<Throwable>().onPickUp.RemoveListener(snappable.Pickup);
        GetComponent<Throwable>().onDetachFromHand.RemoveListener(snappable.Detach);

        GetComponent<Rigidbody>().isKinematic = true;

        DestroyImmediate(GetComponent<Throwable>());
        DestroyImmediate(GetComponent<Interactable>());
        DestroyImmediate(this);
        */
    }
}
