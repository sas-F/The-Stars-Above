using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using SubworldLibrary;
using StarsAbove.Subworlds;

namespace StarsAbove.SceneEffects
{
    public class EverlastingLight : ModSceneEffect
	{
        public override bool IsSceneEffectActive(Player player)
        {
            if (DownedBossSystem.downedWarrior)
            {
                SkyManager.Instance.Deactivate("StarsAbove:EverlastingLight");
                return false;
            }
            if (NPC.downedMoonlord && !DownedBossSystem.downedWarrior && (SubworldSystem.Current == null || SubworldSystem.IsActive<Observatory>()))
            {
                return true;
            }
            
            
            return false;
        }
        public override void SpecialVisuals(Player player, bool isActive)
        {
            if(isActive)
            {
                SkyManager.Instance.Activate("StarsAbove:EverlastingLight");

                Main.time = 18000;
                Main.dayTime = true;
            }
            

        }
        

		public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/EverlastingLight");
        public override SceneEffectPriority Priority => SceneEffectPriority.Event;


    }
}
