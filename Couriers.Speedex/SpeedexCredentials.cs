using System;
using System.Diagnostics.CodeAnalysis;

namespace Couriers.Speedex
{
    /// <summary>
    /// The credentials used of the accessing the Speedex web service
    /// </summary>
    public sealed record SpeedexCredentials
    {
        #region Public Properties

        /// <summary>
        /// The username
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// The password
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// The agreement code
        /// </summary>
        public string AgreementCode { get; }

        /// <summary>
        /// The customer code
        /// </summary>
        public string CustomerCode { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <param name="agreementCode">The agreement code provided by Speedex</param>
        /// <param name="customerCode">The customer code provided by Speedex</param>
        public SpeedexCredentials([NotNull] string username, [NotNull] string password, [NotNull] string agreementCode, [NotNull] string customerCode) : base()
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username, nameof(username));

            ArgumentException.ThrowIfNullOrWhiteSpace(password, nameof(password));

            ArgumentException.ThrowIfNullOrWhiteSpace(agreementCode, nameof(agreementCode));

            ArgumentException.ThrowIfNullOrWhiteSpace(customerCode, nameof(customerCode));

            Username = username;

            Password = password;

            AgreementCode = agreementCode;

            CustomerCode = customerCode;
        }

        #endregion
    }
}
