using System.ComponentModel;
using System.Xml.Serialization;

namespace Couriers.Speedex
{
    /// <summary>
    /// The internal response model for the credentials
    /// </summary>
    [XmlRoot("CreateSession", Namespace = XmlNamespaces.DefaultNamespace)]
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
        /// Default constructor
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
        public static CredentialsInternalRequestModel FromRequestModel(SpeedexCredentials model) => new CredentialsInternalRequestModel()
        {
            Password = model.Password,
            Username = model.Username
        };

        #endregion
    }
}
