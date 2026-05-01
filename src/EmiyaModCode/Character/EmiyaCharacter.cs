using BaseLib.Abstracts;
using Godot;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.CardPools;

namespace EmiyaMod;

public class EmiyaCharacter : PlaceholderCharacterModel
{
    public const string CharacterId = "EmiyaMod";
    public static readonly Color CharColor = new Color("#ff7700");

    protected override string PlaceholderID => "ironclad";

    public override Color NameColor => CharColor;
    public override CharacterGender Gender => CharacterGender.Male;
    public override int StartingHp => 75;
    public override bool ShouldAlwaysShowStarCounter => true;

    public override IEnumerable<CardModel> StartingDeck =>
    [
        ModelDb.Card<Reinforce>(),
        ModelDb.Card<Reinforce>(),
        ModelDb.Card<TraceSword>(),
        ModelDb.Card<TraceSword>(),
        ModelDb.Card<StructuralAnalysis>(),
        ModelDb.Card<StructuralAnalysis>(),
        ModelDb.Card<RinsAdvice>(),
        ModelDb.Card<RinsAdvice>(),
        ModelDb.Card<Guard>(),
        ModelDb.Card<Guard>(),
    ];

    public override IReadOnlyList<RelicModel> StartingRelics => [ModelDb.Relic<MagicCircuit>()];

    // Temporary: use Ironclad card pool until EmiyaMod has enough Common/Uncommon/Rare cards.
    // Replace with ModelDb.CardPool<EmiyaCardPool>() once card set is complete.
    public override CardPoolModel CardPool => ModelDb.CardPool<IroncladCardPool>();
    public override RelicPoolModel RelicPool => ModelDb.RelicPool<EmiyaRelicPool>();
    public override PotionPoolModel PotionPool => ModelDb.PotionPool<EmiyaPotionPool>();
}
