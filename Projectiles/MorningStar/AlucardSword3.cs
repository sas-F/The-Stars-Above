﻿
using Microsoft.Xna.Framework;
using StarsAbove.Buffs.MorningStar;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StarsAbove.Projectiles.MorningStar
{
    public class AlucardSword3 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Morning Star");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 70;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Projectile.type] = 3;
		}

		public override void SetDefaults()
		{
			// This method right here is the backbone of what we're doing here; by using this method, we copy all of
			// the Meowmere Projectile's SetDefault stats (such as projectile.friendly and projectile.penetrate) on to our projectile,
			// so we don't have to go into the source and copy the stats ourselves. It saves a lot of time and looks much cleaner;
			// if you're going to copy the stats of a projectile, use CloneDefaults().

			Projectile.CloneDefaults(ProjectileID.EmpressBlade);

			// To further the Cloning process, we can also copy the ai of any given projectile using AIType, since we want
			// the projectile to essentially behave the same way as the vanilla projectile.
			AIType = ProjectileID.EmpressBlade;

			// After CloneDefaults has been called, we can now modify the stats to our wishes, or keep them as they are.
			// For the sake of example, lets make our projectile penetrate enemies a few more times than the vanilla projectile.
			// This can be done by modifying projectile.penetrate
			Projectile.width = 146;
			Projectile.height = 146;
			Projectile.minion = true;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.minionSlots = 3f;
			Projectile.timeLeft = 240;
			Projectile.penetrate = 999;
			Projectile.hide = false;
			Projectile.alpha = 255;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 120;
			DrawOffsetX = -14;
		}
        public override bool PreAI()
        {
			Player player = Main.player[Projectile.owner];
			player.empressBlade = false;
			return true;
		}
        public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			if (!player.HasBuff(BuffType<AlucardSwordBuff3>()))
            {
				Projectile.Kill();
            }
			Projectile.timeLeft = 10;
			Projectile.alpha -= 10;
			

			base.AI();
		}
		public override bool PreDraw(ref Color lightColor)
		{
			default(Effects.WhiteTrail).Draw(Projectile);
			//default(Effects.SwordSwing).Draw(Projectile);
			return true;
		}
		// While there are several different ways to change how our projectile could behave differently, lets make it so
		// when our projectile finally dies, it will explode into 4 regular Meowmere projectiles.
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			Player player = Main.player[Projectile.owner];

        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
			Player player = Main.player[Projectile.owner];

			if(Main.rand.Next(0,100) > 90)
            {
				crit = true;
            }
			if(target.HasBuff(BuffType<MorningStarHit>()))
            {
				damage = (int)(damage * 1.3);
            }
		}
        public override void Kill(int timeLeft)
		{
			

		}

	}
}
