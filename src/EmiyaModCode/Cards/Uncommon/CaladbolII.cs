namespace EmiyaMod;

public sealed class CaladbolII : EmiyaCard
{
    public CaladbolII() : base(1, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy) { }

    public override int CanonicalStarCost => 1;
    public override IEnumerable<CardTag> Tags => [EmiyaCardTags.Traced];
    protected override PileType GetResultPileType() => PileType.Exhaust;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(20m, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext ctx, CardPlay cardPlay)
    {
        await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue)
            .FromCard(this).Targeting(cardPlay.Target)
            .WithHitFx("vfx/vfx_attack_heavy")
            .Execute(ctx);

        if (cardPlay.Target != null)
            await PowerCmd.Apply<VulnerablePower>(ctx, cardPlay.Target, 2m, base.Owner.Creature, this);
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Damage.UpgradeValueBy(8m);
    }
}
