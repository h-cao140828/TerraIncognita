using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{

    public enum LandState
    {
        Soil, FarmLand, Watered
    }

    public LandState landState;

    public Material soilMat, farmLandMat, wateredMat;

    new Renderer renderer;

    // The selection gameobject to enable when the player is selecting the land
    public GameObject select;

    // Start is called before the first frame update
    void Start()
    {
        // Get the renderer component
        renderer = GetComponent<Renderer>();

        // Default land state set to soil
        SwitchLandState(LandState.Soil);

        // Deselect land by default
        Select(false);
    }

    public void SwitchLandState(LandState stateToSwitch)
    {
        // Set land state
        landState = stateToSwitch;

        Material materialToSwitch = soilMat;
       
        // Update the land material
        switch(stateToSwitch)
        {
            case LandState.Soil:
                // Switch to soil material
                materialToSwitch = soilMat;
                break;
            case LandState.FarmLand:
                // Switch to farmland material
                materialToSwitch = farmLandMat;
                break;
            case LandState.Watered:
                // Switch to watered material
                materialToSwitch = wateredMat;
                break;
        }

        // Get renderer to apply the changes
        renderer.material = materialToSwitch;
    }

    public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }

    public void Interact()
    {
        SwitchLandState(LandState.FarmLand);
    }
}
