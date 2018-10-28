﻿using Kermalis.PokemonBattleEngine.Battle;
using Kermalis.PokemonBattleEngine.Data;
using Kermalis.PokemonBattleEngine.Util;
using System;

namespace Kermalis.PokemonBattleEngine
{
    class PTestProgram
    {
        static readonly PPokemonShell
            pikachu = new PPokemonShell
            {
                Species = PSpecies.Pikachu,
                Nickname = "Pikachu",
                Level = 100,
                Friendship = 255,
                Item = PItem.LightBall,
                Ability = PAbility.LightningRod,
                Gender = PGender.Female,
                Nature = PNature.Timid,
                IVs = new byte[] { 31, 31, 31, 31, 31, 30 }, // Hidden Power Ice/70
                EVs = new byte[] { 0, 0, 4, 252, 0, 252 },
                Moves = new PMove[] { PMove.Thunderbolt, PMove.Thunderbolt, PMove.HiddenPower, PMove.Thunderbolt }, // substitute, thunderbolt, hidden power ice, grass knot
                PPUps = new byte[] { 3, 3, 3, 3 }
            },
            azumarill = new PPokemonShell
            {
                Species = PSpecies.Azumarill,
                Nickname = "ZuWEEE",
                Level = 100,
                Friendship = 255,
                Item = PItem.ChoiceBand,
                Ability = PAbility.HugePower,
                Gender = PGender.Male,
                Nature = PNature.Adamant,
                IVs = new byte[] { 31, 31, 31, 31, 31, 31 }, // Hidden Power Dark/70
                EVs = new byte[] { 252, 252, 0, 0, 0, 4 },
                Moves = new PMove[] { PMove.Waterfall, PMove.AquaJet, PMove.Return, PMove.IcePunch },
                PPUps = new byte[] { 3, 3, 3, 3 }
            },
            latios = new PPokemonShell
            {
                Species = PSpecies.Latios,
                Nickname = "Latios",
                Level = 100,
                Friendship = 255,
                Item = PItem.Leftovers, // choice specs
                Ability = PAbility.Levitate,
                Gender = PGender.Male,
                Nature = PNature.Timid,
                IVs = new byte[] { 31, 30, 31, 30, 31, 30 }, // Hidden Power Fire/70
                EVs = new byte[] { 0, 0, 0, 252, 4, 252 },
                Moves = new PMove[] { PMove.DragonPulse, PMove.DragonPulse, PMove.DragonPulse, PMove.HiddenPower }, // draco meteor, surf, psyshock, hidden power fire
                PPUps = new byte[] { 3, 3, 3, 3 }
            },
            cresselia = new PPokemonShell
            {
                Species = PSpecies.Cresselia,
                Nickname = "Crest",
                Level = 100,
                Friendship = 255,
                Item = PItem.Leftovers,
                Ability = PAbility.Levitate,
                Gender = PGender.Female,
                Nature = PNature.Bold,
                IVs = new byte[] { 31, 31, 31, 31, 31, 31 }, // Hidden Power Dark/70
                EVs = new byte[] { 252, 0, 252, 0, 0, 4 },
                Moves = new PMove[] { PMove.Psychic, PMove.Moonlight, PMove.IceBeam, PMove.Toxic },
                PPUps = new byte[] { 3, 3, 3, 3 }
            },
            darkrai = new PPokemonShell
            {
                Species = PSpecies.Darkrai,
                Nickname = "Darkrai",
                Level = 100,
                Friendship = 255,
                Item = PItem.Leftovers,
                Ability = PAbility.BadDreams,
                Gender = PGender.Genderless,
                Nature = PNature.Timid,
                IVs = new byte[] { 31, 31, 31, 31, 31, 31 }, // Hidden Power Dark/70
                EVs = new byte[] { 4, 0, 0, 252, 0, 252 },
                Moves = new PMove[] { PMove.DarkPulse, PMove.DarkPulse, PMove.NastyPlot, PMove.DarkPulse }, // dark void, dark pulse, nasty plot, substitute
                PPUps = new byte[] { 3, 3, 3, 3 }
            };

        public static void Main(string[] args)
        {
            Console.WriteLine("Pokémon Battle Engine Test");
            Console.WriteLine();

            PTeamShell team1 = new PTeamShell
            {
                DisplayName = "Sasha",
                Party = { pikachu, azumarill }
            };
            PTeamShell team2 = new PTeamShell
            {
                DisplayName = "Jess",
                Party = { darkrai, cresselia }
            };

            PBattle battle = new PBattle(PBattleStyle.Double, team1, team2);
            battle.OnNewEvent += PBattle.ConsoleBattleEventHandler;
            battle.Start();
            PPokemon p0_0 = PKnownInfo.Instance.LocalParty[0];
            PPokemon p0_1 = PKnownInfo.Instance.LocalParty[1];
            PPokemon p1_0 = PKnownInfo.Instance.RemoteParty[0];
            PPokemon p1_1 = PKnownInfo.Instance.RemoteParty[1];

            Console.WriteLine();
            Console.WriteLine(p0_0);
            Console.WriteLine(p0_1);
            Console.WriteLine(p1_0);
            Console.WriteLine(p1_1);

            while ((p0_0.HP > 0 || p0_1.HP > 0) && (p1_0.HP > 0 || p1_1.HP > 0))
            {
                Console.WriteLine();

                // Temporary
                do
                {
                    byte move;
                    bool valid;

                    move = (byte)PUtils.RNG.Next(0, PConstants.NumMoves);
                    valid = battle.SelectActionIfValid(p0_0.Id, move, (byte)(PTarget.FoeLeft));
                    move = (byte)PUtils.RNG.Next(0, PConstants.NumMoves);
                    valid = battle.SelectActionIfValid(p0_1.Id, move, (byte)(PTarget.FoeRight));
                    move = (byte)PUtils.RNG.Next(0, PConstants.NumMoves);
                    valid = battle.SelectActionIfValid(p1_0.Id, move, (byte)(PTarget.FoeLeft));
                    move = (byte)PUtils.RNG.Next(0, PConstants.NumMoves);
                    valid = battle.SelectActionIfValid(p1_1.Id, move, (byte)(PTarget.FoeRight));

                    Console.WriteLine();
                } while (!battle.IsReadyToRunTurn());
                battle.RunTurn();

                Console.WriteLine();
                Console.WriteLine(p0_0);
                Console.WriteLine(p0_1);
                Console.WriteLine(p1_0);
                Console.WriteLine(p1_1);
            }
            Console.ReadKey();
        }
    }
}
