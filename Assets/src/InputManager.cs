using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using src.core;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputManager _instance;
    private void Awake()
    {
        _instance = this;
    }
    
    [SerializeField] private CellsContainer _cellsContainer;


    public static bool CanChooseCell(string cellName, ChessSide side)
    {
        return true;
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
