namespace EmiyaMod;

public sealed class Caliburn : EmiyaCard, ITracedCard
{
    public Caliburn() : base(1, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy) { }

    public override int CanonicalStarCost => 2;
    protected override PileType GetResultPileType() => PileType.Exhaust;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(45m, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext ctx, CardPlay cardPlay)
    {
        await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue)
            .FromCard(this).Targeting(cardPlay.Target)
            .WithHitFx("vfx/sovereign_blade")
            .Execute(ctx);
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Damage.UpgradeValueBy(15m);
    }
}
