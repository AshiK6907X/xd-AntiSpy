﻿using Microsoft.Win32;
using System;
using System.Drawing;
using xdAntiSpy;
using xdAntiSpy.Locales;

namespace Settings.Taskbar
{
    internal class TaskView : SettingsBase
    {
        public TaskView(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
        private const int desiredValue = 1;

        public override string ID()
        {
            return Strings._taskbarTaskView;
        }

        public override string Info()
        {
            return Strings._taskbarTaskView_desc;
        }

        public override bool CheckFeature()
        {
            return !(
                   Utils.IntEquals(keyName, "ShowTaskViewButton", desiredValue)
             );
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "ShowTaskViewButton", 0, RegistryValueKind.DWord);
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
                Registry.SetValue(keyName, "ShowTaskViewButton", 1, RegistryValueKind.DWord);
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