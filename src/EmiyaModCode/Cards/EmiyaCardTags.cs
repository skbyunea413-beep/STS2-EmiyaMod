namespace EmiyaMod;

// CardTag is a plain enum - cannot add dynamic values.
// We use a marker interface on cards instead.
// Check card.GetType() or custom interfaces to identify Traced cards.
public interface ITracedCard { }
