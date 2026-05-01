namespace EmiyaMod;

public sealed class Hrunting : EmiyaCard
{
    public Hrunting() : base(1, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy) { }

    public override int CanonicalStarCost => 1;
    public override IEnumerable<CardTag> Tags => [EmiyaCardTags.Traced];
    protected override PileType GetResultPileType() => PileType.Exhaust;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(12m, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext ctx, CardPlay cardPlay)
    {
        for (int i = 0; i < 2; i++)
        {
            await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue)
                .FromCard(this).Targeting(cardPlay.Target)
                .WithHitFx("vfx/vfx_attack_heavy")
                .Execute(ctx);
        }
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars.Damage.UpgradeValueBy(4m);
    }
}
