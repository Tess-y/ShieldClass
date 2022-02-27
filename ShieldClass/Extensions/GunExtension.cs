﻿using System;
using HarmonyLib;
using UnityEngine;

public static class GunExtension
{
	public static void CopyGunStats(this Gun copyToGun, Gun copyFromGun)
	{
		copyToGun.ammo = copyFromGun.ammo;
		copyToGun.ammoReg = copyFromGun.ammoReg;
		copyToGun.attackID = copyFromGun.attackID;
		copyToGun.attackSpeed = copyFromGun.attackSpeed;
		copyToGun.attackSpeedMultiplier = copyFromGun.attackSpeedMultiplier;
		copyToGun.bodyRecoil = copyFromGun.bodyRecoil;
		copyToGun.bulletDamageMultiplier = copyFromGun.bulletDamageMultiplier;
		copyToGun.bulletPortal = copyFromGun.bulletPortal;
		copyToGun.bursts = copyFromGun.bursts;
		copyToGun.chargeDamageMultiplier = copyFromGun.chargeDamageMultiplier;
		copyToGun.chargeEvenSpreadTo = copyFromGun.chargeEvenSpreadTo;
		copyToGun.chargeNumberOfProjectilesTo = copyFromGun.chargeNumberOfProjectilesTo;
		copyToGun.chargeRecoilTo = copyFromGun.chargeRecoilTo;
		copyToGun.chargeSpeedTo = copyFromGun.chargeSpeedTo;
		copyToGun.chargeSpreadTo = copyFromGun.chargeSpreadTo;
		copyToGun.cos = copyFromGun.cos;
		copyToGun.currentCharge = copyFromGun.currentCharge;
		copyToGun.damage = copyFromGun.damage;
		copyToGun.damageAfterDistanceMultiplier = copyFromGun.damageAfterDistanceMultiplier;
		copyToGun.defaultCooldown = copyFromGun.defaultCooldown;
		copyToGun.dmgMOnBounce = copyFromGun.dmgMOnBounce;
		copyToGun.dontAllowAutoFire = copyFromGun.dontAllowAutoFire;
		copyToGun.drag = copyFromGun.drag;
		copyToGun.dragMinSpeed = copyFromGun.dragMinSpeed;
		copyToGun.evenSpread = copyFromGun.evenSpread;
		copyToGun.explodeNearEnemyDamage = copyFromGun.explodeNearEnemyDamage;
		copyToGun.explodeNearEnemyRange = copyFromGun.explodeNearEnemyRange;
		copyToGun.forceSpecificAttackSpeed = copyFromGun.forceSpecificAttackSpeed;
		copyToGun.forceSpecificShake = copyFromGun.forceSpecificShake;
		copyToGun.gravity = copyFromGun.gravity;
		copyToGun.hitMovementMultiplier = copyFromGun.hitMovementMultiplier;
		//copyToGun.holdable = copyFromGun.holdable;
		copyToGun.ignoreWalls = copyFromGun.ignoreWalls;
		copyToGun.isProjectileGun = copyFromGun.isProjectileGun;
		copyToGun.isReloading = copyFromGun.isReloading;
		copyToGun.knockback = copyFromGun.knockback;
		copyToGun.lockGunToDefault = copyFromGun.lockGunToDefault;
		copyToGun.multiplySpread = copyFromGun.multiplySpread;
		copyToGun.numberOfProjectiles = copyFromGun.numberOfProjectiles;
		copyToGun.objectsToSpawn = copyFromGun.objectsToSpawn;
		copyToGun.overheatMultiplier = copyFromGun.overheatMultiplier;
		copyToGun.percentageDamage = copyFromGun.percentageDamage;
		copyToGun.player = copyFromGun.player;
		copyToGun.projectielSimulatonSpeed = copyFromGun.projectielSimulatonSpeed;
		copyToGun.projectileColor = copyFromGun.projectileColor;
		copyToGun.projectiles = copyFromGun.projectiles;
		copyToGun.projectileSize = copyFromGun.projectileSize;
		copyToGun.projectileSpeed = copyFromGun.projectileSpeed;
		copyToGun.randomBounces = copyFromGun.randomBounces;
		copyToGun.recoil = copyFromGun.recoil;
		copyToGun.recoilMuiltiplier = copyFromGun.recoilMuiltiplier;
		copyToGun.reflects = copyFromGun.reflects;
		copyToGun.reloadTime = copyFromGun.reloadTime;
		copyToGun.reloadTimeAdd = copyFromGun.reloadTimeAdd;
		copyToGun.shake = copyFromGun.shake;
		copyToGun.shakeM = copyFromGun.shakeM;
		copyToGun.ShootPojectileAction = copyFromGun.ShootPojectileAction;
		copyToGun.shootPosition = copyFromGun.shootPosition;
		copyToGun.sinceAttack = copyFromGun.sinceAttack;
		copyToGun.size = copyFromGun.size;
		copyToGun.slow = copyFromGun.slow;
		copyToGun.smartBounce = copyFromGun.smartBounce;
		//copyToGun.soundDisableRayHitBulletSound = copyFromGun.soundDisableRayHitBulletSound;
		//copyToGun.soundGun = copyFromGun.soundGun;
		//copyToGun.soundImpactModifier = copyFromGun.soundImpactModifier;
		//copyToGun.soundShotModifier = copyFromGun.soundShotModifier;
		copyToGun.spawnSkelletonSquare = copyFromGun.spawnSkelletonSquare;
		copyToGun.speedMOnBounce = copyFromGun.speedMOnBounce;
		copyToGun.spread = copyFromGun.spread;
		copyToGun.teleport = copyFromGun.teleport;
		copyToGun.timeBetweenBullets = copyFromGun.timeBetweenBullets;
		copyToGun.timeToReachFullMovementMultiplier = copyFromGun.timeToReachFullMovementMultiplier;
		copyToGun.unblockable = copyFromGun.unblockable;
		copyToGun.useCharge = copyFromGun.useCharge;
		copyToGun.waveMovement = copyFromGun.waveMovement;

		Traverse.Create(copyToGun).Field("attackAction").SetValue((Action)Traverse.Create(copyFromGun).Field("attackAction").GetValue());
		//Traverse.Create(copyToGun).Field("gunAmmo").SetValue((GunAmmo)Traverse.Create(copyFromGun).Field("gunAmmo").GetValue());
		Traverse.Create(copyToGun).Field("gunID").SetValue((int)Traverse.Create(copyFromGun).Field("gunID").GetValue());
		Traverse.Create(copyToGun).Field("spreadOfLastBullet").SetValue((float)Traverse.Create(copyFromGun).Field("spreadOfLastBullet").GetValue());

		Traverse.Create(copyToGun).Field("forceShootDir").SetValue((Vector3)Traverse.Create(copyFromGun).Field("forceShootDir").GetValue());
	}
}
