namespace EmiyaMod;

public sealed class RapidTrace : EmiyaCard
{
    public RapidTrace() : base(0, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy) { }

    public override IEnumerable<CardTag> Tags => [EmiyaCardTags.Traced];

    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(6m, ValueProp.Move)];

    protected override PileType GetResultPileType() => PileType.Exhaust;

    protected override async Task OnPlay(PlayerChoiceContext ctx, CardPlay cardPlay)
    {
        await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue)
            .FromCard(this)
            .Targeting(cardPlay.Target)
            .WithHitFx("vfx/vfx_attack_blunt")
            .Execute(ctx);
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Damage.UpgradeValueBy(4m);
    }
}
