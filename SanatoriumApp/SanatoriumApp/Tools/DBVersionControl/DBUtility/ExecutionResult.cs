using System;

namespace DBVersionControl.DBUtility
{
    public class ExecutionResult
    {
        /// <summary>
        /// Single instance for success
        /// </summary>
        private static readonly ExecutionResult _successfulResult = new ExecutionResult();

        /// <summary>
        /// Constructor for success
        /// </summary>
        private ExecutionResult()
        {
            IsSuccessful = true;
        }

        /// <summary>
        /// Constructor for failure
        /// </summary>
        /// <param name="statement">Statement that caused error</param>
        /// <param name="exception">Exception</param>
        public ExecutionResult(string statement, Exception exception)
        {
            IsSuccessful = false;
            Statement = statement;
            Exception = exception;
        }

        /// <summary>
        /// Returns flag that indicates whether update was successful
        /// </summary>
        public bool IsSuccessful { get; private set; }

        /// <summary>
        /// Statement that caused error (in case of failure)
        /// </summary>
        public string Statement { get; private set; }

        /// <summary>
        /// Exception (in case of failure)
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Holds number of version where update failure occurs 
        /// </summary>
        public string FinalVersion { get; set; }

        /// <summary>
        /// Successful result
        /// </summary>
        /// <returns>Returns successful result instance</returns>
        public static ExecutionResult SuccessfulResult
        {
            get
            {
                return _successfulResult;
            }
        }
    }
}