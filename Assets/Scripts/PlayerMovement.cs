using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public FixedJoystick fixedJoystick;
    private Player playerScript;
    
    private void Start() {
        playerScript = GetComponent<Player>();
    }

    public void Update()
    {
        if(!playerScript.playerIsDead) {
            PlayerRotation();
            PlayerMovementTranslate();
        }
        
    }

    private void PlayerRotation() {
        if(fixedJoystick.Horizontal > 0) 
            transform.rotation = new Quaternion(0, 0, 0, 0);
        else if(fixedJoystick.Horizontal < 0)
            transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    private void PlayerMovementTranslate() {
        Vector3 direction = Vector3.up * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
    }
}
