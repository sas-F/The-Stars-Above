﻿
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace StarsAbove.Projectiles.RedMage
{
    public class VerholyExplosion : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Verholy");
			
		}

		public override void SetDefaults() {
			Projectile.width = 750;
			Projectile.height = 750;
			Projectile.aiStyle = 0;
			Projectile.timeLeft = 1;
			Projectile.penetrate = -1;
			Projectile.scale = 1f;
			Projectile.alpha = 255;
			Projectile.penetrate = -1;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.tileCollide = false;

		}

		// In here the AI uses this example, to make the code more organized and readable
		// Also showcased in ExampleJavelinProjectile.cs
		public float movementFactor // Change this value to alter how fast the spear moves
		{
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}

		
		public override void AI() {
			//Main.PlaySound(SoundLoader.customSoundType, (int)projectile.Center.X, (int)projectile.Center.Y, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/GunbladeImpact"));

			Projectile.ai[0] += 1f;
			for (int d = 0; d < 30; d++)
			{
				Dust.NewDust(Projectile.Center, 0, 0, 226, 0f + Main.rand.Next(-20, 20), 0f + Main.rand.Next(-20, 20), 150, default(Color), 1f);
			}
			for (int d = 0; d < 44; d++)
			{
				Dust.NewDust(Projectile.Center, 0, 0, 91, 0f + Main.rand.Next(-15, 15), 0f + Main.rand.Next(-5, 5), 150, default(Color), 1f);
			}
			for (int d = 0; d < 26; d++)
			{
				Dust.NewDust(Projectile.Center, 0, 0, 20, 0f + Main.rand.Next(-16, 16), 0f + Main.rand.Next(-16, 16), 150, default(Color), 1f);
			}
			for (int d = 0; d < 30; d++)
			{
				Dust.NewDust(Projectile.Center,0, 0, 91, 0f + Main.rand.Next(-13, 13), 0f + Main.rand.Next(-13, 13), 150, default(Color), 1f);
			}
			
			
			
			// Fade in
			Projectile.alpha--;
				if (Projectile.alpha < 100)
				{
					Projectile.alpha = 100;
				}

			
		}
	}
}
