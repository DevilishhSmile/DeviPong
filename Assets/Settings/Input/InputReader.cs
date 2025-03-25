using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public interface IInputReader
{
    Vector2 Direction { get; }
    void EnablePlayerAction();
}
    
public class InputReader : ScriptableObject, IPlayerActions, IInputReader
{
    public event UnityAction<Vector2> Move = delegate { };

    private InputSystem_Actions _inputActions;

    public Vector2 Direction => _inputActions.Player.Move.ReadValue<Vector2>();
    
    #if UNITY_EDITOR
    private const string AssetPath = "Assets/Settings/Input/InputReader.asset"; 
    
    [InitializeOnLoadMethod]
    static void RunOnStart()
    {
        InputReader inputReader = AssetDatabase.LoadAssetAtPath<InputReader>(AssetPath);
        if (inputReader == null)
        {
            inputReader = CreateInstance<InputReader>();
            AssetDatabase.CreateAsset(inputReader, AssetPath);
            AssetDatabase.SaveAssets();
        }
        AssetDatabase.Refresh();
    }
    #endif
    public void EnablePlayerAction()
    {
        if (_inputActions == null)
        {
            _inputActions = new InputSystem_Actions();
            _inputActions.Player.SetCallbacks(this);
        }
        _inputActions.Player.Enable();
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        Move.Invoke(context.ReadValue<Vector2>());
    }
}
