// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.Owin.Security
{
    /// <summary>
    /// Base Options for all authentication middleware
    /// </summary>
    public abstract class AuthenticationOptions
    {
        private string _authenticationType;

        /// <summary>
        /// Initialize properties of AuthenticationOptions base class
        /// </summary>
        /// <param name="authenticationType">Assigned to the AuthenticationType property</param>
        protected AuthenticationOptions(string authenticationType)
        {
            Description = new AuthenticationDescription();
            AuthenticationType = authenticationType;
            AuthenticationMode = AuthenticationMode.Active;
        }

        /// <summary>
        /// The AuthenticationType in the options corresponds to the IIdentity AuthenticationType property. A different
        /// value may be assigned in order to use the same authentication middleware type more than once in a pipeline.
        /// </summary>
        public string AuthenticationType
        {
            get { return _authenticationType; }
            set
            {
                _authenticationType = value;
                Description.AuthenticationType = value;
            }
        }

        /// <summary>
        /// If Active the authentication middleware alter the request user coming in and
        /// alter 401 Unauthorized responses going out. If Passive the authentication middleware will only provide
        /// identity and alter responses when explicitly indicated by the AuthenticationType.
        /// </summary>
        public AuthenticationMode AuthenticationMode { get; set; }

        /// <summary>
        /// Additional information about the authentication type which is made available to the application.
        /// </summary>
        public AuthenticationDescription Description { get; set; }
    }
}
