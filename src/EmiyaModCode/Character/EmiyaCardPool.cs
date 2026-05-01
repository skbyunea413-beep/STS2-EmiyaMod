using BaseLib.Abstracts;
using Godot;

namespace EmiyaMod;

public class EmiyaCardPool : CustomCardPoolModel
{
    public override string Title => EmiyaCharacter.CharacterId;
    public override float H => 0.083f;
    public override float S => 1f;
    public override float V => 0.9f;
    public override Color DeckEntryCardColor => new Color("#ff7700");
    public override bool IsColorless => false;
}
