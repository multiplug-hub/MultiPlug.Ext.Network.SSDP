using MultiPlug.Base.Diagnostics;

namespace MultiPlug.Ext.Network.SSDP.Diagnostics
{
    internal class EventLogDefinitions
    {
        internal const string DefinitionsId = "MultiPlug.Ext.Network.SSDP.EN";

        internal static EventLogDefinition[] Definitions { get; set; } = new EventLogDefinition[]
        {
            new EventLogDefinition { Code = (uint) EventLogEntryCodes.SourceSSDP, Source = (uint) EventLogEntryCodes.Reserved, StringFormat = "SSDP", Type = EventLogEntryType.Information },
        };
    }
}
