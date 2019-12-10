using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public string horizontalInputName;
    [SerializeField] public string verticalInputName;
    [SerializeField] public float movementSpeed;

    private CharacterController charController;

    private void Awake(){
        charController=GetComponent<CharacterController>();
    }
    private void Update(){
        PlayerMovement();
    }
    private void PlayerMovement(){
        float verInput = Input.GetAxis(verticalInputName)*movementSpeed*Time.deltaTime;
        float horInput = Input.GetAxis(horizontalInputName)*movementSpeed*Time.deltaTime;
    
        Vector3 forwardMovement = transform.forward * verInput;
        Vector3 rightMovement = transform.right *horInput;

        charController.SimpleMove(forwardMovement + rightMovement);
    }

}
