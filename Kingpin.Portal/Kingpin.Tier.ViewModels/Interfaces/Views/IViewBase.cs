﻿using System;

namespace Kingpin.Tier.ViewModels.Interfaces.Views
{
    /// <summary>
    /// Represents a <see cref="IViewBase"/> interface
    /// </summary>
    public interface IViewBase
    {
        /// <summary>
        /// Gets or Sets <see cref="LastModified"/>
        /// </summary>
        DateTime LastModified { get; set; }
    }
}
