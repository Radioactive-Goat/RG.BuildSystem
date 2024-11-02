using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ConfiguratorWindow : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset _visualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/Configurator Window")]
    public static void ShowExample()
    {
        ConfiguratorWindow wnd = GetWindow<ConfiguratorWindow>();
        wnd.titleContent = new GUIContent("Configurator Window");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        VisualElement labelFromUXML = _visualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
    }
}
