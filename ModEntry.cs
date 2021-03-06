﻿using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using QuickShop.Framework;
using QuickShop.Framework.Gui;

namespace QuickShop
{
    public class ModEntry : Mod
    {
        private Config _config;
        private static ModEntry _instance;

        public ModEntry()
        {
            _instance = this;
        }

        public override void Entry(IModHelper helper)
        {
            _config = helper.ReadConfig<Config>();
            helper.Events.Input.ButtonPressed += OnButtonPress;
        }

        private void OnButtonPress(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;
            if (!Context.IsPlayerFree)
                return;
            if (e.Button != _config.OpenQuickShop)
                return;
            Game1.activeClickableMenu = new QuickShopScreen();
        }

        public static ModEntry GetInstance()
        {
            return _instance;
        }
    }
}