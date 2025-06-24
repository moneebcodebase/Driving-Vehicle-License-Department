using System.Diagnostics;
using System.Configuration;

namespace DVLD_DataAccess
{
    static class clsDataAccessSettings
    {
        
        //this is a property for the connection to the database
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DVLDConnectionString"].ConnectionString;


        
        public enum enEventType { Information = 1, Error, Warnning };

        //this is an event logger procedure to log Every Exception or information that could happend
        public static void EventLogger(string SourceName,string Message,enEventType EventType)
        {
            //if the Souce name does not exsits this will create one
            if(!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName,"Applicaiton");
            }


            // a switch case to specify which Type to log in log viewer
            switch (EventType)
            {

                case enEventType.Information:
                    {
                        EventLog.WriteEntry(SourceName,Message,EventLogEntryType.Information);
                        break;
                    }
                case enEventType.Warnning:
                    {
                        EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Warning);
                        break;
                    }
                case enEventType.Error:
                    {
                        EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Error);
                        break;
                    }
            }

        }

    }
}
