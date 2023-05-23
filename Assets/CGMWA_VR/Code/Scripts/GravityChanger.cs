using System;
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

    private void Start()
    {
        WallsInterectable.OnWallSelected
            .Subscribe(OnWallSelected)
            .AddTo(this);

        CubeInteractable.OnCubeSelected
            .Subscribe(OnCubeSelected)
            .AddTo(this);
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

        var newDir = -_wall.transform.forward;
        Debug.Log(newDir);
        _cube.GravEntity.ChangeGravity(newDir);
    
    }
}
