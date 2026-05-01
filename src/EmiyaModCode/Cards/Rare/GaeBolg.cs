namespace EmiyaMod;

public sealed class GaeBolg : EmiyaCard, ITracedCard
{
    public GaeBolg() : base(0, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy) { }

    public override int CanonicalStarCost => 2;
    protected override PileType GetResultPileType() => PileType.Exhaust;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(30m, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext ctx, CardPlay cardPlay)
    {
        if (cardPlay.Target != null)
            await CreatureCmd.Damage(ctx, cardPlay.Target,
                base.DynamicVars.Damage.BaseValue,
                ValueProp.Move | ValueProp.Unblockable,
                base.Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Damage.UpgradeValueBy(10m);
    }
}
