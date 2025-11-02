using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Couriers.Speedex.InternalModels.RequestModels
{
    /// <summary>
    /// The internal response model for the credentials
    /// </summary>
    [XmlRoot("CreateSession", Namespace = SpeedexXmlNamespaces.DefaultNamespace)]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class CredentialsInternalRequestModel
    {
        #region Public Properties

        /// <summary>
        /// The username
        /// </summary>
        [XmlElement("username")]
        public string? Username { get; set; }

        /// <summary>
        /// The password
        /// </summary>
        [XmlElement("password")]
        public string? Password { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="CredentialsInternalRequestModel"/>
        /// </summary>
        public CredentialsInternalRequestModel() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and return the <see cref="CredentialsInternalRequestModel"/> from the <see cref="SpeedexCredentials"/>
        /// </summary>
        /// <param name="model">The request model</param>
        /// <returns></returns>
        public static CredentialsInternalRequestModel FromRequestModel([NotNull] SpeedexCredentials model)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(model);
#else
            if (model is null)
                throw new ArgumentNullException(nameof(model));
#endif

            return new()
            {
                Password = model.Password,
                Username = model.Username
            };
        }

        #endregion
    }
}
