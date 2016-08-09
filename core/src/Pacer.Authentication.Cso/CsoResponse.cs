using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pacer.Authentication.Cso
{
    public class CsoResponse
    {
        /// <summary>
        /// CSO username
        /// </summary>
        public string LoginId { get; set; }

        /// <summary>
        /// Numeric error code, or 0 if successful
        /// </summary>
        public int LoginResult { get; set; }

        /// <summary>
        /// Text describing failure, if any
        /// </summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// CSO authentication token (if login successful).
        /// </summary>
        public string NextGenCSO { get; set; }

        /// <summary>
        /// Legacy authentication token (if login successful).
        /// </summary>
        public string PacerSession { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Client code
        /// </summary>
        public string ClientCode { get; set; }

        /// <summary>
        /// Text that describes to user the requirements for client code,
        /// such as using example 5 numeric characters
        /// </summary>
        public string ClientCodeDescription { get; set; }

        /// <summary>
        /// PACER preferences for this account.
        /// The only value now used is of the form “receipt=Y”
        /// </summary>
        public string PacerPrefs { get; set; }

        /// <summary>
        /// Regular Expression for Client Code,
        /// for example “^[0-9][0-9][0-9][0-9][0-9]$”.
        /// </summary>
        public string ClientValidation { get; set; }

        /// <summary>
        /// IP address of external user
        /// </summary>
        public string UserIPAddress { get; set; }

        /// <summary>
        /// Timestamp indicating when session will expire from CM/ECF cache
        /// and revalidate with CAP server. Format is in RFC 822 and updated
        /// by RFC 1123.
        /// </summary>
        public string Expires { get; set; }

        /// <summary>
        /// Time in minutes until session expires; same information as Expires, but
        /// in a format that is easier to parse in Perl.
        /// </summary>
        public int TimeToLive { get; set; }

        /// <summary>
        /// Firm ID
        /// </summary>
        public string FirmId { get; set; }

        /// <summary>
        /// PSC Account Number
        /// </summary>
        public string CSOId { get; set; }

        /// <summary>
        /// Numeric status code, or 0 if active
        /// </summary>
        public int PacerStatus { get; set; }

        /// <summary>
        /// Text providing users additional information regarding 
        /// their PACER account status
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Exempt status (a = always, n = never, or s = sometimes)
        /// </summary>
        public string ExemptStatus { get; set; }

        /// <summary>
        /// Provide a list of courts for which the user is exempt when 
        /// ExemptStatus = “s”. The list will contain name value pairs
        /// separated by semicolons, “courtId=defaultStatus”, or “all” 
        /// for CJA attorneys. The courtId will be the court’s PSC court
        /// Id and defaultStatus will be “n” if default is off or “y” if 
        /// default is on (e.g., TXWDC=y;TXEDC=y;TXSDC=y).
        /// </summary>
        public string ExcemptJurisdiction { get; set; }

        /// <summary>
        /// Account type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Returns “1” if the user has an entry in the filer_court table,
        /// or “0” if no entry is found. This is ONLY used internally by PSC
        /// and is not needed by CM/ECF.
        /// </summary>
        public string FilerStatus { get; set; }
    }
}
