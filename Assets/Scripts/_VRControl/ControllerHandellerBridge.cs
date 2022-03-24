using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInputHandler
{
    void OnControllerInputDown();
    void OnControllerInputUp();
}

public class ControllerHandellerBridge : MonoBehaviour
{

    private List<IInputHandler> _inputHandlers = new List<IInputHandler>();
    

    InputBridge inputBridgeInstance;
    void Start()
    {
        inputBridgeInstance = GetComponent<InputBridge>();
    }
    int idebug = 0;
    // Update is called once per frame
    void Update()
    {
        //RightHandActions();

        if (inputBridgeInstance.RightTriggerDown)
        {
            _inputHandlers.ForEach(x => x?.OnControllerInputDown());


        }

        if (inputBridgeInstance.RightTriggerUp)
        {
            _inputHandlers.ForEach(x => x?.OnControllerInputUp());

        }
    }

    public void Subscribe(IInputHandler inputHandler)
    {
        _inputHandlers.Add(inputHandler);
    }


    public void UnSubscribe(IInputHandler inputHandler)
    {
        _inputHandlers.Remove(inputHandler);
    }
}
