using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(IntJaggedArray))]
public class IntJaggedArrayDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Start property drawing
        EditorGUI.BeginProperty(position, label, property);

        // Retrieve jagged array fields
        SerializedProperty outerArrayLengthsProp = property.FindPropertyRelative("outerArrayLengths");

        // Display label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Calculate rects
        Rect outerRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

        // Draw outer array
        for (int i = 0; i < outerArrayLengthsProp.arraySize; i++)
        {
            SerializedProperty lengthProp = outerArrayLengthsProp.GetArrayElementAtIndex(i);

            // Draw header for inner array
            EditorGUI.LabelField(outerRect, $"Array {i}");

            // Draw inner array editor
            int innerSize = lengthProp.intValue;

            for (int j = 0; j < innerSize; j++)
            {
                outerRect.y += EditorGUIUtility.singleLineHeight;
                EditorGUI.IntField(outerRect, $"Element [{i}][{j}]", property.GetArrayElementAtIndex(j).intValue);
            }
        }

        EditorGUI.EndProperty();
    }
}