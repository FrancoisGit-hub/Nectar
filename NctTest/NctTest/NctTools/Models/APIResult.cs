using System;

namespace NctTools.Models
{
    /// <summary>
    /// Result of the API class (with generic data)
    /// </summary>
    /// <typeparam name="T">Data</typeparam>
    public class APIResult<T>
    {
        /// <summary>
        /// Dash
        /// </summary>
        private const string DASH = " - ";

        /// <summary>
        /// Generic entity containing the data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// API Status
        /// </summary>
        public APIStatus Status { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public APIResult()
        {
        }

        /// <summary>
        /// Override the default to ToString() method to return the detailed string of API return
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Data == null || Status == null)
            {
                return "API RESULT IS NULL";
            }

            string result = "API - '";
            object type = Data.GetType();

            result += nameof(type) + "' - ";
            result += "Success=" + Status.Success.ToString() + DASH;
            result += "Code=" + Status.Code.ToString() + DASH;
            result += "Message=" + Status.Message + DASH;
            result += "Error=" + Status.Error;

            return result;
        }

        /// <summary>
        /// Make new status (empty, by default)
        /// </summary>
        /// <param name="success">Success</param>
        /// <param name="code">Code</param>
        /// <param name="msg">Message</param>
        /// <param name="err">Error</param>
        public void MakeStatus(bool success, int code, string msg, string err = "")
        {
            Status = new APIStatus(success, code, msg, err);
        }

        /// <summary>
        /// Make new status (internal error status, by default)
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="success">Success</param>
        /// <param name="code">Code</param>
        /// <param name="msg">Message</param>
        public void MakeStatus(Exception ex, bool success = false, int code = (int)ApiResultStatusCode.InternalError, string msg = "Erreur, veuillez réessayer plus tard.")
        {
            Status = new APIStatus(ex, success, code, msg);
        }

        /// <summary>
        /// Custom constructor (OK status)
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="success">Success</param>
        /// <param name="code">Code</param>
        /// <param name="msg">Message</param>
        /// <param name="err">Error</param>
        public APIResult(T data, bool success = true, int code = 200, string msg = "", string err = "")
        {
            if (data != null)
            {
                Data = data;
            }
            MakeStatus(success, code, msg, err);
        }

        /// <summary>
        /// Custom constructor (internal error status)
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="ex">Exception</param>
        /// <param name="code">Code</param>
        /// <param name="msg">Message</param>
        /// <param name="success">Success</param>
        public APIResult(T data, Exception ex, int code = (int)ApiResultStatusCode.InternalError, string msg = "Erreur, veuillez réessayer plus tard.", bool success = false)
        {
            if (data == null)
            {
                Data = data;
            }
            MakeStatus(ex, success, code, msg);
        }

        /// <summary>
        /// Custom constructor (internal error status, without data)
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="code">Code</param>
        /// <param name="msg">Message</param>
        /// <param name="success">Success</param>
        public APIResult(Exception ex, int code = (int)ApiResultStatusCode.InternalError, string msg = "Erreur, veuillez réessayer plus tard.", bool success = false)
        {
            MakeStatus(ex, success, code, msg);
        }
    }

    /// <summary>
    /// Result of the API class
    /// </summary>
    public class APIResult
    {
        /// <summary>
        /// Data
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public APIStatus Status { get; set; }

        /// <summary>
        /// Make new status (empty, by default)
        /// </summary>
        /// <param name="success">Success</param>
        /// <param name="code">Code</param>
        /// <param name="msg">Message</param>
        /// <param name="error">Error</param>
        public void MakeStatus(bool success, int code, string msg, string error = "")
        {
            Status = new APIStatus(success, code, msg, error);
        }

        /// <summary>
        /// Make new status (internal error status, by default)
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="success">Success</param>
        /// <param name="code">Code</param>
        /// <param name="msg">Internal error message</param>
        public void MakeStatus(Exception ex, bool success = false, int code = (int)ApiResultStatusCode.InternalError, string msg = "Erreur, veuillez réessayer plus tard.")
        {
            Status = new APIStatus(ex, success, code, msg);
        }

        /// <summary>
        /// Default constructor (when OK, without data)
        /// </summary>
        public APIResult()
        {
            Data = new object();
            MakeStatus(true, 200, string.Empty, string.Empty);
        }

        /// <summary>
        /// Custom constructor (when OK, with data)
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="success">Success</param>
        /// <param name="code">Code</param>
        /// <param name="msg">Message</param>
        /// <param name="error">Error</param>
        public APIResult(object data, bool success = true, int code = 200, string msg = "", string error = "")
        {
            if (data == null)
            {
                Data = new object();
            }
            else
            {
                Data = data;
            }
            MakeStatus(success, code, msg, error);
        }

        /// <summary>
        /// Custom constructor (internal error status, with data)
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="ex">Exception</param>
        /// <param name="code">Code</param>
        /// <param name="msg">Message</param>
        /// <param name="success">Success</param>
        public APIResult(object data, Exception ex, int code = (int)ApiResultStatusCode.InternalError, string msg = "Erreur, veuillez réessayer plus tard.", bool success = false)
        {
            if (data == null)
            {
                Data = new object();
            }
            else
            {
                Data = data;
            }
            MakeStatus(ex, success, code, msg);
        }

        /// <summary>
        /// Custom constructor (internal error status, without data)
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="code">Code</param>
        /// <param name="msg">Message</param>
        /// <param name="success">Success</param>
        public APIResult(Exception ex, int code = (int)ApiResultStatusCode.InternalError, string msg = "Erreur, veuillez réessayer plus tard.", bool success = false)
        {
            Data = new object();
            MakeStatus(ex, success, code, msg);
        }
    }
}