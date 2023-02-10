using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoundCameraPos : CinemachineExtension
{
    //Definition of an unit which is 32 pixels
    public float PixelsPerUnit = 32;

    //This method have to call in all derived class
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        //Is it a body stage?
        if (stage == CinemachineCore.Stage.Body)
        {
            //Yes. Set a camera on a specific place on the scene.
            //Read a final position of a camera
            Vector3 pos = state.FinalPosition;
            //Instruction call our method Round() and create a Vector where the new position of the camera is and has all pixels.
            Vector3 pos2 = new Vector3(Round(pos.x), Round(pos.y), pos.z);
            state.PositionCorrection += pos2 - pos;
        }
    }

    float Round(float x)
    { 
        return Mathf.Round(x * PixelsPerUnit) / PixelsPerUnit; 
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
