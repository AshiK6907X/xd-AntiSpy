﻿using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy;
using xdAntiSpy.Locales;

namespace Settings.Edge
{
    public class BrowserSignin : SettingsBase
    {
        public BrowserSignin(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int desiredValue = 0;

        public override string ID() => Strings._edgeBrowserSignin;

        public override string Info() => Strings._edgeBrowserSignin_desc;

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "BrowserSignin", desiredValue);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "BrowserSignin", 0, Microsoft.Win32.RegistryValueKind.DWord);

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
                Registry.SetValue(keyName, "BrowserSignin", 1, Microsoft.Win32.RegistryValueKind.DWord);

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