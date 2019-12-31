using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook: MonoBehaviour
{
    [SerializeField]
    private Transform  player ;
    [SerializeField]
    private Transform Fppcamera;
    [SerializeField]
    private bool invert;
    [SerializeField]
    private bool Can_Unlock = true;
    [SerializeField]
    private float mouseSensitivity = 5f;
    [SerializeField]
    private float smoothing = 2.0f;
    [SerializeField]
    private int smooth_Steps = 10;
    [SerializeField]
    private float smooth_Weight = 0.4f;
    [SerializeField]
    private float roll_Angle = 10f;
    //public float smoothing = 2.0f;
    [SerializeField]
    private float roll_Speed = 3f;
    [SerializeField]
    private Vector2 default_Look_Limits = new Vector2(-70, 80f);
    private Vector2 look_Angles;
    private Vector2 current_Mouse_Look;
    private Vector2 smooth_Move;
    private Vector2 SmoothV;
    private Vector2 mouseLook;
    private float current_Roll_Angle;
    private int last_Look_Frame;

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
      

    }
    void Update()
    {
        lockandunlockCursor();
        if (Cursor.lockState == CursorLockMode.Locked) ;
        {
            LookAround();
        }
    }
    void lockandunlockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ;
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;


            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
        void LookAround()
        {

             float mouseX = Input.GetAxis(MouseAxis.MOUSE_X);
             float mouseY = Input.GetAxis("Mouse Y");
        float rotAmountX = mouseX * mouseSensitivity; 
             float rotAmountY = mouseY * mouseSensitivity;
        rotAmountX = Mathf.Clamp(rotAmountX, default_Look_Limits.x, default_Look_Limits.y);               
             Vector3 rotfppcam = Fppcamera.transform.rotation.eulerAngles;
             Vector3 rotplayer = player.transform.rotation.eulerAngles;
            rotfppcam.x -= rotAmountY;
            rotfppcam.z = 0;
             rotplayer.y += rotAmountX;
            Fppcamera.rotation = Quaternion.Euler(rotfppcam);
            player.rotation = Quaternion.Euler(rotplayer);
        }
    
        

}
