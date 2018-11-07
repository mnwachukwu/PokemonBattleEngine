﻿namespace Kermalis.PokemonBattleEngine.Data
{
    public static class PConstants
    {
        public const byte MaxLevel = 100; // [Default: 100]

        public const byte MaxPartySize = 6; // [Default: 6]

        public const byte MaxPokemonNameLength = 10; // [Default: 10]
        public const byte MaxPlayerNameLength = 7; // [Default: 7]

        public const ushort MaxTotalEVs = 510; // [Default: 510]
        // Raising MaxIVs will not affect Hidden Power.
        public const byte MaxIVs = 31; // [Default: 31]

        public const double NatureStatBoost = 0.1; // [Default: 0.1]
        public const sbyte MaxStatChange = 6; // [Default: 6]

        public const byte NumMoves = 4; // [Default: 4]
        // PPMultiplier is quite important. Each move has a base PP that is a multiple of it (5, 15, 40, etc.)
        // For example, Growl is a tier 8 move. Its base PP will be 40 (tier * PPMultiplier).
        // For PP-Ups, Growl will go by: (tier * PPMultiplier) + (tier * PPUps) giving a 64 maximum when MaxPPUps is 3
        // If PPMultiplier is changed to 6, Growl will have a base PP of 48 and its maximum will be 72 when MaxPPUps is 3
        // Transform will also change the Max PP of each copied move to PPMultiplier.
        public const byte PPMultiplier = 5; // [Default: 5]
        public const byte MaxPPUps = 3; // [Default: 3]

        public const byte ConfusionMinTurns = 1; // [Default: 1]
        public const byte ConfusionMaxTurns = 4; // [Default: 4]
        public const byte SleepMinTurns = 1; // [Default: 1]
        public const byte SleepMaxTurns = 3; // [Default: 3]
        public const byte BurnDamageDenominator = 8; // [Default: 8 (1/8 damage each turn)]
        public const byte PoisonDamageDenominator = 8; // [Default: 8 (1/8 damage each turn)]
        public const byte ToxicDamageDenominator = 16; // [Default: 16 (1/16 damage increasingly each turn)]

        public const byte LeftoversDenominator = 16; // [Default: 16 (1/16 health each turn)]

        public const byte ReflectLightScreenTurns = 5; // [Default: 5]
    }
}
