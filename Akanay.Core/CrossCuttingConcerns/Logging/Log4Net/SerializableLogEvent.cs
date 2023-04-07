using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public object MessageObject => _loggingEvent.MessageObject;
        //public string RenderedMessage => _loggingEvent.RenderedMessage;
        //public string UserName => _loggingEvent.UserName;
        //public DateTime TimeStamp => _loggingEvent.TimeStamp;
        //public string Identity => _loggingEvent.Identity;
        //public string Domain => _loggingEvent.Domain;
        //public string ThreadName => _loggingEvent.ThreadName;
        //public Exception ExceptionObject => _loggingEvent.ExceptionObject;
        //public string Level => _loggingEvent.Level.Name;
        //public string LoggerName => _loggingEvent.LoggerName;
        //public LocationInfo LocationInformation => _loggingEvent.LocationInformation;
        //public IDictionary Properties => _loggingEvent.GetProperties();






    }
}
