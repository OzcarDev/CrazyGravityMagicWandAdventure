using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public static GravityChanger Instance { get; private set; }

    private WallsInterectable _wall = null;
    private CubeInteractable _cube = null;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCubeSelected(CubeInteractable cube)
    {
        _wall = null;
        _cube = cube;
    }

    private void OnWallSelected(WallsInterectable wall)
    {
        if (_cube == null) return;
        _wall = wall;

        var newDir = -_wall.VirtualNormal;
        ChangeGravity(newDir);
    }

    private void ChangeGravity(Vector3 gravityDir)
    {
        Debug.Log(gravityDir);
        _cube.GravEntity.ChangeGravity(gravityDir);
        RestartGravityChange();
    }

    private void RestartGravityChange()
    {
        _cube = null;
        _wall = null;
    }

    private void OnEnable()
    {
        WallsInterectable.OnWallInteract += OnWallSelected;
        CubeInteractable.OnCubeInteract += OnCubeSelected;
    }

    private void OnDisable()
    {
        WallsInterectable.OnWallInteract -= OnWallSelected;
        CubeInteractable.OnCubeInteract -= OnCubeSelected;
    }
}
