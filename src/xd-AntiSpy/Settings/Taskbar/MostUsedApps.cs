﻿using xdAntiSpy;
using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy.Locales;

namespace Settings.Taskbar
{
    internal class MostUsedApps : SettingsBase
    {
        public MostUsedApps( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\Explorer";
        private const int desiredValue = 2;

        public override string ID()
        {
            return Strings._taskbarMostUsedApps;
        }

        public override string Info()
        {
            return Strings._taskbarMostUsedApps_desc;
        }

        public override bool CheckFeature()
        {
            return (
                   Utils.IntEquals(keyName, "ShowOrHideMostUsedApps", desiredValue)
             );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "ShowOrHideMostUsedApps", 2, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, "ShowOrHideMostUsedApps", 1, RegistryValueKind.DWord);
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