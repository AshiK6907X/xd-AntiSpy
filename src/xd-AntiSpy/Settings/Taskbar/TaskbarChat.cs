﻿using xdAntiSpy;
using xdAntiSpy.Locales;
using Microsoft.Win32;
using System;
using System.Drawing;

namespace Settings.Taskbar
{
    internal class TaskbarChat : SettingsBase
    {
        public TaskbarChat( Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const int desiredValue = 1;

        public override string ID()
        {
            return Strings._taskbarTaskbarChat;
        }

        public override string Info()
        {
            return Strings._taskbarTaskbarChat_desc;
        }

        public override bool CheckFeature()
        {
            return !(
                   Utils.IntEquals(keyName, "TaskbarMn", desiredValue)
             );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "TaskbarMn", 0, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, "TaskbarMn", 1, RegistryValueKind.DWord);
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