﻿using EverQuestDPSPlugin;
using EverQuestDPSPlugin.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EQDPSPluginUnitTests
{
    [TestClass]
    public sealed class EverQuestDPSPluginTests
    {
        EverQuestDPSPlugin.EverQuestDPSPlugin eqDPSPlugin;
        [TestInitialize] 
        public void Init() { 
            eqDPSPlugin = new EverQuestDPSPlugin.EverQuestDPSPlugin();
        }

        [DataTestMethod]
        [DataRow("himself")]
        [DataRow("herself")]
        [DataRow("itself")]
        [DataRow("themselves")]
        [TestCategory("Plugin Tests")]
        public void selfIsTrue(string selfTest)
        {
            Assert.IsTrue(eqDPSPlugin.CheckIfSelf(selfTest));
        }

        [DataTestMethod]
        [DataRow("ourself")]
        [DataRow("myself")]
        [DataRow("weselves")]
        [DataRow("theirselves")]
        [TestCategory("Plugin Tests")]
        public void selfIsFalse(string selfTest)
        {
            Assert.IsFalse(eqDPSPlugin.CheckIfSelf(selfTest));
        }

        [TestMethod]
        [TestCategory("Plugin Tests")]
        public void RegexStringTestExceptionOnNullString()
        {
            Assert.ThrowsException<ArgumentNullException>(new Action(() => eqDPSPlugin.RegexString(null)));
        }

        [DataTestMethod]
        [TestCategory("")]
        [DataRow(EverQuestSwingType.NonMelee, String.Empty, 0, DateTime.Now, "attacker", "Hitpoints", "victim", )]
        public void GetMasterSwing(EverQuestSwingType eqst
            , String criticalAttack
            , Int64 damage, DateTime timestampOfAttack
            , String damageType, String attacker, String typeOfResource, String victim)
        {
            MasterSwing testMasterSwing = 
                EverQuestDPSPlugin.GetMasterSwing(
                    eqst
                , criticalAttack
                , new Dnum(damage)
                , timestampOfAttack
                , damageType
                , attacker
                , typeOfResource
                , victim);
            Assert.IsTrue(testMasterSwing.Victim == victim);
            Assert.IsTrue(testMasterSwing.Attacker == attacker);
            Assert.IsTrue(testMasterSwing.Date == timestampOfAttack);
            Assert.IsFalse(testMasterSwing.Attacker == String.Empty);
            Assert.IsFalse(testMasterSwing.Victim == String.Empty);
            Assert.IsTrue(testMasterSwing.Critical == criticalAttack.Contains("Critical"));
            Assert.IsTrue(testMasterSwing.DamageType == damageType);
            Assert.IsTrue()
        }
    }
}
