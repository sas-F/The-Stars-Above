﻿
using Microsoft.Xna.Framework;
using StarsAbove.Buffs.RedMage;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace StarsAbove.Projectiles.RedMage
{
    public class RedMageFocus : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Mage's Foci");
		}

		public override void SetDefaults()
		{
			
			AIType = 0;
			Projectile.width = 62;
			Projectile.height = 62;
			Projectile.minion = false;
			Projectile.minionSlots = 0f;
			Projectile.timeLeft = 240;
			Projectile.penetrate = 999;
			Projectile.hide = false;
			Projectile.alpha = 255;
			Projectile.netImportant = true;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;

		}
		int idlePause;
		bool floatUpOrDown; //false is Up, true is Down
		public override bool PreAI()
        {
			Player player = Main.player[Projectile.owner];
			//player.suspiciouslookingTentacle = false;
			return true;
		}
        public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			Player projOwner = Main.player[Projectile.owner];

			Projectile.scale = 0.7f;
			if (!player.HasBuff(BuffType<RedMageHeldBuff>()))
            {
				Projectile.Kill();
            }
			Projectile.timeLeft = 10;
			Projectile.alpha -= 10;

			player.SetCompositeArmBack(true, Player.CompositeArmStretchAmount.Full, (player.Center - 
				new Vector2(Projectile.Center.X, (Projectile.Center.Y + DrawOriginOffsetY) + 20)
				).ToRotation() + MathHelper.PiOver2);

			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			Projectile.direction = projOwner.direction;
			
			
			Projectile.spriteDirection = Projectile.direction;
			Projectile.rotation = player.velocity.X * 0.05f;

			//Projectile.position.X = player.Center.X;
			if (Projectile.spriteDirection == 1)
			{
				Projectile.position.X = player.Center.X;

			}
			else
			{
				Projectile.position.X = player.Center.X - 62;

			}
			Projectile.position.Y = ownerMountedCenter.Y - (float)(Projectile.height / 2) - 12;

			//This is 0 unless a auto attack has been initated, in which it'll tick up.


			if (Projectile.alpha < 0)
			{
				Projectile.alpha = 0;
			}
			if (Projectile.alpha > 255)
			{
				Projectile.alpha = 255;
			}



			UpdateMovement();
			


			
		}
		private void UpdateMovement()
		{
			if (floatUpOrDown)//Up
			{
				if (Projectile.ai[0] > 7)
				{
					DrawOriginOffsetY++;
					Projectile.ai[0] = 0;
				}
			}
			else
			{
				if (Projectile.ai[0] > 7)
				{
					DrawOriginOffsetY--;
					Projectile.ai[0] = 0;
				}
			}
			if (DrawOriginOffsetY > -10)
			{
				idlePause = 10;
				DrawOriginOffsetY = -10;
				floatUpOrDown = false;

			}
			if (DrawOriginOffsetY < -20)
			{
				idlePause = 10;
				DrawOriginOffsetY = -20;
				floatUpOrDown = true;

			}
			if (idlePause < 0)
			{
				if (DrawOriginOffsetY < -12 && DrawOriginOffsetY > -18)
				{
					Projectile.ai[0] += 2;
				}
				else
				{
					Projectile.ai[0]++;
				}
			}

			idlePause--;

		}

		public override void Kill(int timeLeft)
		{
			

		}

	}
}
