using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class ConfiguratorWindow : EditorWindow
{
    [FormerlySerializedAs("m_VisualTreeAsset")] [SerializeField]
    private VisualTreeAsset _visualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/ConfiguratorWindow")]
    public static void ShowExample()
    {
        ConfiguratorWindow wnd = GetWindow<ConfiguratorWindow>();
        wnd.titleContent = new GUIContent("ConfiguratorWindow");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Instantiate UXML
        VisualElement labelFromUXML = _visualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
    }
}
