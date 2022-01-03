using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Class : SwitchCamera
Description : A class to control all the camera of my scenes
*/
public class SwitchCamera : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    public Camera cam5;
    public Camera cam6;
    public Camera cam7;
    public Camera cam8;
    public Camera cam9;
    public Camera cam10;

    private Vector3 dragOrigin;

    private int numcam = 1;
    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        cam4.enabled = false;
        cam5.enabled = false;
        cam6.enabled = false;
        cam7.enabled = false;
        cam8.enabled = false;
        cam9.enabled = false;  
        cam10.enabled = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.isPaused == false)
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                numcam++;
                if(numcam > 9)
                    numcam = 1;
                switch(numcam)
                {
                    case 1:
                    {
                        cam1.enabled = true;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = false; 
                        cam10.enabled = false;   
                        break;
                    }
                    case 2:
                    {
                        cam1.enabled = false;
                        cam2.enabled = true;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = false;  
                        cam10.enabled = false;  
                        break;
                    }
                    case 3:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = true;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = false;  
                        cam10.enabled = false;  
                        break;
                    }
                    case 4:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = true;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = false; 
                        cam10.enabled = false;   
                        break;
                    }
                    case 5:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = true;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = false; 
                        cam10.enabled = false;   
                        break;
                    }
                    case 6:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = true;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = false; 
                        cam10.enabled = false;   
                        break;
                    }
                    case 7:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = true;
                        cam8.enabled = false;
                        cam9.enabled = false;  
                        cam10.enabled = false;  
                        break;
                    }
                    case 8:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = true;
                        cam9.enabled = false; 
                        cam10.enabled = false;   
                        break;
                    }
                    case 9:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = true; 
                        cam10.enabled = false;   
                        break;
                    }
                }
            } else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                numcam--;
                if(numcam < 1)
                    numcam = 9;
                switch(numcam)
                {
                    case 1:
                    {
                        cam1.enabled = true;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = false; 
                        cam10.enabled = false;   
                        break;
                    }
                    case 2:
                    {
                        cam1.enabled = false;
                        cam2.enabled = true;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = false;  
                        cam10.enabled = false;  
                        break;
                    }
                    case 3:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = true;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = false; 
                        cam10.enabled = false;   
                        break;
                    }
                    case 4:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = true;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = false;  
                        cam10.enabled = false;  
                        break;
                    }
                    case 5:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = true;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = false;
                        cam10.enabled = false;    
                        break;
                    }
                    case 6:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = true;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = false;
                        cam10.enabled = false;    
                        break;
                    }
                    case 7:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = true;
                        cam8.enabled = false;
                        cam9.enabled = false;
                        cam10.enabled = false;    
                        break;
                    }
                    case 8:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = true;
                        cam9.enabled = false;
                        cam10.enabled = false;   
                        break;
                    }
                    case 9:
                    {
                        cam1.enabled = false;
                        cam2.enabled = false;
                        cam3.enabled = false;
                        cam4.enabled = false;
                        cam5.enabled = false;
                        cam6.enabled = false;
                        cam7.enabled = false;
                        cam8.enabled = false;
                        cam9.enabled = true; 
                        cam10.enabled = false;  
                        break;
                    }
                }
            } else if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                cam10.enabled = true;
                cam1.enabled = false;
                cam2.enabled = false;
                cam3.enabled = false;
                cam4.enabled = false;
                cam5.enabled = false;
                cam6.enabled = false;
                cam7.enabled = false;
                cam8.enabled = false;
                cam9.enabled = false;
                return;
            }
            if(cam10.enabled)
            {
                Vector3 pos = cam10.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
                Vector3 move = new Vector3(pos.x * 2, 0, pos.y * 2);
                cam10.transform.Translate(move, Space.World);
            }
        }
        
    }
}
