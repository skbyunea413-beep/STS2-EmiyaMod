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

    public override string PlaceholderID => "regent";

    public override Color NameColor => CharColor;
    public override CharacterGender Gender => CharacterGender.Masculine;
    public override int StartingHp => 75;
    public override bool ShouldAlwaysShowStarCounter => true;

    public override IEnumerable<CardModel> StartingDeck =>
    [
        ModelDb.Card<Reinforce>(),
        ModelDb.Card<Reinforce>(),
        ModelDb.Card<Reinforce>(),
        ModelDb.Card<Reinforce>(),
        ModelDb.Card<Guard>(),
        ModelDb.Card<Guard>(),
        ModelDb.Card<Guard>(),
        ModelDb.Card<Guard>(),
        ModelDb.Card<TraceSword>(),
        ModelDb.Card<RinsAdvice>(),
        ModelDb.Card<Erosion>(),
        ModelDb.Card<AbnormalResilience>(),
        ModelDb.Card<Avalon>(),
        ModelDb.Card<NineLives>(),
    ];

    public override IReadOnlyList<RelicModel> StartingRelics => [ModelDb.Relic<MagicCircuit>()];

    public override CardPoolModel CardPool => ModelDb.CardPool<EmiyaCardPool>();
    public override RelicPoolModel RelicPool => ModelDb.RelicPool<EmiyaRelicPool>();
    public override PotionPoolModel PotionPool => ModelDb.PotionPool<EmiyaPotionPool>();
}
