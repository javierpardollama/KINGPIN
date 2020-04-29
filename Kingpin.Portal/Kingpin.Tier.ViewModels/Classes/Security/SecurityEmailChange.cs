﻿using Kingpin.Tier.ViewModels.Classes.Views;

namespace Kingpin.Tier.ViewModels.Classes.Security
{
    /// <summary>
    /// Represents a <see cref="SecurityEmailChange"/> class
    /// </summary>
    public class SecurityEmailChange
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="SecurityEmailChange"/>
        /// </summary>
        public SecurityEmailChange()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUser"/>
        /// </summary>
        public virtual ViewApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="NewEmail"/>
        /// </summary>
        public string NewEmail { get; set; }
    }
}
