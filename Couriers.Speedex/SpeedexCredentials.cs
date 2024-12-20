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
            ArgumentException.ThrowIfNullOrWhiteSpace(username);

            ArgumentException.ThrowIfNullOrWhiteSpace(password);

            ArgumentException.ThrowIfNullOrWhiteSpace(agreementCode);

            ArgumentException.ThrowIfNullOrWhiteSpace(customerCode);

            if (agreementCode.Length > SpeedexConstants.MaximumAgreementCodeLength)
                throw new InvalidOperationException($"The '{nameof(agreementCode)}' is not a valid agreement code. The maximum length for a agreement code field is {SpeedexConstants.MaximumAgreementCodeLength}.");

            if (customerCode.Length > SpeedexConstants.MaximumCustomerCodeLength)
                throw new InvalidOperationException($"The '{nameof(customerCode)}' is not a valid customer code. The maximum length for a customer code field is {SpeedexConstants.MaximumCustomerCodeLength}.");

            Username = username;

            Password = password;

            AgreementCode = agreementCode;

            CustomerCode = customerCode;
        }

        #endregion
    }
}
