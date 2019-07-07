﻿using Kingpin.Tier.Constants.Enums;
using Kingpin.Tier.Mappings.Classes;
using Microsoft.Extensions.Logging;
using System;

namespace Kingpin.Tier.Logging.Classes
{
    public static class LoggingTransistor
    {
        private const LogLevel DefaultLogLevel = LogLevel.None;

        private static void Emit(this ILogger @this, Enum appEventData, string logData) => @this.Log(
                GetApplicationEventLevel(appEventData),
                GetApplicationEventCode(appEventData),
                logData,
                DateTime.Now.ToShortDateString());

        public static void WriteGetItemNotFoundLog(this ILogger @this, string logData)
        {
            @this.Emit(ApplicationEvents.GetItemNotFound, logData);

            WriteDiagnostics(logData);
        }

        public static void WriteUpdateItemLog(this ILogger @this, string logData)
        {
            @this.Emit(ApplicationEvents.UpdateItem, logData);

            WriteDiagnostics(logData);
        }

        public static void WriteDeleteItemLog(this ILogger @this, string logData)
        {
            @this.Emit(ApplicationEvents.DeleteItem, logData);

            WriteDiagnostics(logData);
        }

        public static void WriteInsertItemLog(this ILogger @this, string logData)
        {
            @this.Emit(ApplicationEvents.InsertItem, logData);

            WriteDiagnostics(logData);
        }

        public static void WriteGetItemFoundLog(this ILogger @this, string logData)
        {
            @this.Emit(ApplicationEvents.GetItemFound, logData);

            WriteDiagnostics(logData);
        }

        private static void WriteDiagnostics(string logData) => System.Diagnostics.Debug.WriteLine(logData);

        private static int GetApplicationEventCode(Enum appEventData) => (int)Convert.ChangeType(appEventData, appEventData.GetTypeCode());

        private static LogLevel GetApplicationEventLevel(Enum appEventData)
        {
            if (LoggingProfile.LogLevelMapings.ContainsKey(appEventData))
            {
                return LoggingProfile.LogLevelMapings[appEventData];
            }
            else
            {
                return DefaultLogLevel;
            }
        }
    }
}