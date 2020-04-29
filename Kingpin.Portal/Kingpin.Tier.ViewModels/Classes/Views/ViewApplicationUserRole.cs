using System;
using System.Xml.Serialization;

using Kingpin.Tier.ViewModels.Interfaces.Views;

namespace Kingpin.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewApplicationUserRole"/> class. Implements <see cref="IViewKey"/>, <see cref="IViewBase"/>
    /// </summary>
    [XmlRoot("application-user-role")]
    public class ViewApplicationUserRole : IViewBase, IViewKey
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ViewApplicationUserRole"/>
        /// </summary>
        public ViewApplicationUserRole()
        {
        }

        /// <summary>
        /// Gets or Sets <see cref="Id"/>
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="LastModified"/>
        /// </summary>
        [XmlElement("last-modified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationRole"/>
        /// </summary>
        [XmlElement("application-role")]
        public virtual ViewApplicationRole ApplicationRole { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="ApplicationUser"/>
        /// </summary>
        [XmlElement("application-user")]
        public virtual ViewApplicationUser ApplicationUser { get; set; }
    }
}
