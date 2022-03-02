# Simple WebXR Teleporter

based on [@IJEMIN](https://github.com/IJEMIN) [Simple VR Teleporter](https://github.com/IJEMIN/Simple-Unity-VR-Teleporter) with added support for WebXR.

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/PWk4uvdKSUs/0.jpg)](https://www.youtube.com/watch?v=PWk4uvdKSUs)

Simple Teleporter script without any plug-in or dependencies.
All scripts are accessible.

* All you need to do is :

~~~
VRTeleporter.ToggleDisplay(true);
VRTeleporter.Teleport();
~~~

Your can download managed asset from [Unity Asset Store](https://assetstore.unity.com/packages/tools/input-management/simple-vr-teleport-115996).

# Quick Start



## Setup
You can find 'Teleporter', 'FlatTeleporter' and 'WebXRTeleporter' Prefabs on Runtime/Prefabs folder.

1. Attach Teleporter prefab as a child of game object which representing VR Hand(or position where render of path start).
2. Asign Body Transform property with game object which you want to teleport. (example: Root of player game object)

## How to control VRTeleporter

**All you need to do :**

1. Get reference of VRTeleporter object.
2. Use two public method of VRTeleporter script.

(You can check SampleVRTeleporterController.cs in Sample folder)

### Public Methods

#### void ToggleDisplay(bool active)

- Active and display visual.
- Update Path Vertices.
- Check ground position.

Once `ToggleDisplay(true)` is called, VRTeleporter automatically update it's arc path on every fixed update.

(This means you don't need to call ToggleDisplay(True) on every frame whild holding down button. Just calling once for Input.GetButtonDown is enough.)

Calling `ToggleDisplay(false)` will turn off renderer and stop updating path and ground position.

#### void Teleport()

- Teleport bodyTransform to detected ground position.

Use this when player release input button.
(example: Call Teleport method when Input.GetMouseButtonUp(0) is true)

## Example of how to control VRTeleporter

~~~
    public VRTeleporter teleporter;
    
    void Update () {

        if(Input.GetMouseButtonDown(0))
        {
            teleporter.ToggleDisplay(true);
        }

        if(Input.GetMouseButtonUp(0))
        {
            teleporter.Teleport();
            teleporter.ToggleDisplay(false);
        }
    }
~~~

# Properties of VRTeleporter
- Position Marker : Game object used as ground position marker
- Body Transform : Game object which will be teleported
- Offset Origin Transform : Origin to set teleportation offset by (e.g. head or camera)
- Exclude Layers : Layers which you don't want to check
- Angle : Take-off angle of arc start position
- Strength : Factor for how far arc gonna go

# How to modify Looks

Just modify material used by line renderer of Teleport object, and material used by mesh renderer of Marker object.

# ETC
- VRTeleprter script is accessible, you can change whatever you want.

License
-------
[MIT](LICENSE.md)