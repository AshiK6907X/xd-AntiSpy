﻿using xdAntiSpy;
using xdAntiSpy.Locales;
using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Edge
{
    public class GamerMode : SettingsBase
    {
        public GamerMode(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int desiredValue = 0;

        public override string ID() => Strings._edgeGamerMode;

        public override string Info() => Strings._edgeGamerMode_desc;

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "GamerModeEnabled", desiredValue);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "GamerModeEnabled", 0, Microsoft.Win32.RegistryValueKind.DWord);

                return true;
            }
            catch (Exception ex)
            {
                logger.Log("Code red in " + ex.Message, Color.Red);
            }

            return false;
        }

        public override bool UndoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "GamerModeEnabled", 1, Microsoft.Win32.RegistryValueKind.DWord);

                return true;
            }
            catch (Exception ex)
            {
                logger.Log("Code red in " + ex.Message, Color.Red);
            }

            return false;
        }
    }
}