using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangeSpriteElement : StoryElement
{
    public override string ElementName => "Change Sprite";

    public override Color32 DisplayColor => _displayColor;
    private Color32 _displayColor = new Color32().Character();

    public override StoryElementTypes Type => StoryElementTypes.Character;

    public string CharacterName;
    public Sprite NewSprite;

    public override void DisplayLayout(Rect layoutRect)
    {
#if UNITY_EDITOR
        CharacterName = EditorGUILayout.TextField("Character Name", CharacterName);

        GUILayout.Label("New Character Sprite", EditorStyles.boldLabel);
        NewSprite = EditorGUILayout.ObjectField(NewSprite, typeof(Sprite), false) as Sprite;
#endif
    }

    public override IEnumerator Execute(GameManager managerCallback, UVNFCanvas canvas)
    {
        managerCallback.CharacterManager.ChangeCharacterSprite(CharacterName, NewSprite);
        return null;
    }
}
