﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OsmSharp.UI.Map.Styles.MapCSS.v0_2.Domain;

namespace OsmSharp.UI.Map.Styles.MapCSS.v0_2.Domain
{
    /// <summary>
    /// Strongly typed MapCSS v0.2 Declaration class.
    /// </summary>
    public class DeclarationFontVariant : Declaration<QualifierFontVariantEnum, FontVariantEnum>
    {

    }

    /// <summary>
    /// Strongly typed MapCSS v0.2 Declaration class.
    /// </summary>
    public enum QualifierFontVariantEnum
    {
        /// <summary>
        /// Font variant.
        /// </summary>
        FontVariant
    }

    /// <summary>
    /// Strongly typed MapCSS v0.2 Declaration class.
    /// </summary>
    public enum FontVariantEnum
    {
        /// <summary>
        /// Small caps.
        /// </summary>
        SmallCaps,
        /// <summary>
        /// Normal.
        /// </summary>
        Normal
    }
}
