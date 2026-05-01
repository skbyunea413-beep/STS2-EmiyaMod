namespace EmiyaMod;

public sealed class RuleBreaker : EmiyaCard
{
    public RuleBreaker() : base(1, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy) { }

    public override int CanonicalStarCost => 2;
    public override IEnumerable<CardTag> Tags => [EmiyaCardTags.Traced];
    protected override PileType GetResultPileType() => PileType.Exhaust;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(10m, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext ctx, CardPlay cardPlay)
    {
        await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue)
            .FromCard(this).Targeting(cardPlay.Target)
            .WithHitFx("vfx/vfx_attack_heavy")
            .Execute(ctx);

        if (cardPlay.Target != null)
        {
            foreach (var power in cardPlay.Target.Powers.ToList())
                await PowerCmd.Remove(power);
        }
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Damage.UpgradeValueBy(5m);
    }
}
