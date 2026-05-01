namespace EmiyaMod;

public sealed class Erosion : EmiyaCard
{
    public Erosion() : base(0, CardType.Skill, CardRarity.Uncommon, TargetType.Self) { }

    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new HpLossVar(3m), new IntVar("Thorns", 3)];

    protected override async Task OnPlay(PlayerChoiceContext ctx, CardPlay cardPlay)
    {
        await CreatureCmd.Damage(ctx, base.Owner.Creature, base.DynamicVars.HpLoss.BaseValue,
            DamageProps.cardHpLoss, base.Owner.Creature, this);
        await PowerCmd.Apply<ThornsPower>(ctx, base.Owner.Creature, base.DynamicVars["Thorns"].BaseValue,
            base.Owner.Creature, this);
        await CardPileCmd.Draw(ctx, 1m, base.Owner);
    }

    public override async Task AfterCardDrawn(PlayerChoiceContext ctx, CardModel card, bool fromHandDraw)
    {
        if (card != this) return;
        await CardCmd.AutoPlay(ctx, this, null);
    }

    protected override void OnUpgrade()
    {
        base.DynamicVars["Thorns"].UpgradeValueBy(1m);
    }
}
