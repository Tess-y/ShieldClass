﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.Utils;
using ShieldClassNamespace.Interfaces;
using ShieldClassNamespace.MonoBehaviours;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using UnityEngine;
using TMPro;
using ClassesManagerReborn.Util;

namespace ShieldClassNamespace.Cards
{
    class ShieldHero : CustomCard
    {
        public static CardInfo card = null;

        public const string ShieldHeroClassName = "Shield Hero";
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            block.cdAdd = 0.5f;

            cardInfo.allowMultiple = false;
            gameObject.GetOrAddComponent<ClassNameMono>();
            ShieldClass.instance.DebugLog($"[{ShieldClass.ModInitials}][Card] {GetTitle()} Built");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {

            var abyssalCard = CardManager.cards.Values.Select(card => card.cardInfo).First(c => c.name.Equals("AbyssalCountdown"));
            var statMods = abyssalCard.gameObject.GetComponentInChildren<CharacterStatModifiers>();
            var abyssalObj = statMods.AddObjectToPlayer;

            var obj2 = Instantiate(abyssalObj);

            var shieldHeroObj = Instantiate(ShieldClass.instance.shieldHeroAssets.LoadAsset<GameObject>("A_ShieldHero"), player.transform);
            shieldHeroObj.name = "A_ShieldHeroUpgrader";
            shieldHeroObj.transform.localPosition = Vector3.zero;

            var abyssal = obj2.GetComponent<AbyssalCountdown>();

            var upgrader = shieldHeroObj.AddComponent<ShieldHeroUpgrader>();
            upgrader.soundUpgradeChargeLoop = abyssal.soundAbyssalChargeLoop;

            UnityEngine.GameObject.Destroy(obj2);

            abyssal = shieldHeroObj.GetComponent<AbyssalCountdown>();
            abyssal.soundAbyssalChargeLoop = upgrader.soundUpgradeChargeLoop;

            upgrader.counter = 0;
            upgrader.upgradeTime = 9f;
            upgrader.timeToEmpty = 6f;
            upgrader.upgradeCooldown = 12f;
            upgrader.outerRing = abyssal.outerRing;
            upgrader.fill = abyssal.fill;
            upgrader.rotator = abyssal.rotator;
            upgrader.still = abyssal.still;
            upgrader.blockModifier.additionalBlocks_add = 1;
            upgrader.characterDataModifier.maxHealth_mult = 0.9f;


            ShieldClass.instance.ExecuteAfterFrames(5, () =>
            {
                UnityEngine.GameObject.Destroy(abyssal);
            });

            characterStats.objectsAddedToPlayer.Add(shieldHeroObj);

            ShieldClass.instance.DebugLog($"[{ShieldClass.ModInitials}][Card] {GetTitle()} Added to Player {player.playerID}");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            ShieldClass.instance.DebugLog($"[{ShieldClass.ModInitials}][Card] {GetTitle()} removed from Player {player.playerID}");
        }

        protected override string GetTitle()
        {
            return "Shield Hero";
        }
        protected override string GetDescription()
        {
            return "Use the power of your shield to take down foes. Gain levels by standing still or blocking enemy bullets.";
        }
        protected override GameObject GetCardArt()
        {
            GameObject art;

            try
            {
                art = ShieldClass.instance.shieldHeroAssets.LoadAsset<GameObject>("C_ShieldHero");
            }
            catch
            {
                art = null;
            }

            return art;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Blocks per Upgrade",
                    amount = "+0.5",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "HP per Upgrade",
                    amount = "-10%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Block Cooldown",
                    amount = "+0.5s",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DefensiveBlue;
        }
        public override string GetModName()
        {
            return ShieldClass.ModInitials;
        }
        public override bool GetEnabled()
        {
            return true;
        }
    }
}
