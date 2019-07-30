using System;
using System.Diagnostics;

namespace NctTools.Models
{
    /// <summary>
    /// Contains the values of status codes defined for ApiResult.
    /// </summary>
    public enum ApiResultStatusCode
    {
        /// <summary>
        /// Request has been successfully processed
        /// </summary>
        OK = 200,

        /// <summary>
        /// Request has already successfully been processed 
        /// </summary>
        AlreadyOk = 201,

        /// <summary>
        /// Request has been successfully processed and that the response has no content
        /// </summary>
        NoContent = 204,

        /// <summary>
        /// Request has been successfully processed and entity is off limit
        /// </summary>
        OffLimit = 301,

        /// <summary>
        /// Entity from request has been cancelled
        /// </summary>
        Cancelled = 302,

        /// <summary>
        /// Maintenance
        /// </summary>
        Maintenance = 310,

        /// <summary>
        /// Request data is invalid
        /// </summary>
        InvalidData = 400,

        /// <summary>
        /// SMTP error
        /// </summary>
        SmtpError = 401,

        /// <summary>
        /// Coordinate for request are invalid
        /// </summary>
        BadShopCoordinate = 402,

        /// <summary>
        /// Invalid token
        /// </summary>
        InvalidToken = 403,

        /// <summary>
        /// Partial or complete data not found
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// One or several resources already exists and causes conflictual issues
        /// </summary>
        Conflict = 409,

        /// <summary>
        /// Incorrect password
        /// </summary>
        WrongPassword = 410,

        /// <summary>
        /// Invalid account
        /// </summary>
        InvalidAccount = 411,

        /// <summary>
        /// Internal error
        /// </summary>
        InternalError = 500,

        /// <summary>
        /// Emergency Fail-safe
        /// </summary>
        Emergency = 999
    }

    /// <summary>
    /// API status
    /// </summary>
    public class APIStatus : Status
    {
        /// <summary>
        /// Return code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Namespace
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// .NET class
        /// </summary>
        public string NetClass { get; set; }

        /// <summary>
        /// Method used
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public APIStatus()
        {
        }

        /// <summary>
        /// Method returning the status of the API (with default values)
        /// </summary>
        /// <param name="success">Bool, true by default</param>
        /// <param name="code">Return code, 200 by defaut</param>
        /// <param name="message">Message returned, empty by defaut</param>
        /// <param name="error">Error, empty by default</param>
        public APIStatus(bool success = true, int code = 200, string message = "", string error = "")
        {
            Success = success;
            Code = code;
            Message = message;
            Error = error;

            if (success == false)
            {
                var stackTrace = new StackTrace();
                var entryAssembly = System.Reflection.Assembly.GetEntryAssembly().ManifestModule.Name;
                foreach (var stackFrame in stackTrace.GetFrames())
                {
                    var method = stackFrame.GetMethod();
                    if (method?.DeclaringType.Assembly.ManifestModule.Name == entryAssembly)
                    {
                        Namespace = method.DeclaringType.Namespace;
                        NetClass = method.DeclaringType.Name;
                        Method = method.Name;
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// Method returning the status of the API (when error)
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="success">Bool, false</param>
        /// <param name="code">Code</param>
        /// <param name="message">Message, empty by default</param>
        public APIStatus(Exception ex, bool success = false, int code = (int)ApiResultStatusCode.InternalError, string message = "")
        {
            Success = success;
            Code = code;
            Message = message;

            if (ex == null)
            {
                Error = string.Empty;
            }
            else if (ex.InnerException != null)
            {
                Error = ex.InnerException.Message;
            }
            else
            {
                Error = ex.Message;
            }
            if (!success)
            {
                var stackTrace = new StackTrace(ex);
                var method = stackTrace.GetFrame(0).GetMethod();
                Namespace = method.DeclaringType.Namespace;
                NetClass = method.DeclaringType.Name;
                Method = method.Name;
            }
        }
    }
}
